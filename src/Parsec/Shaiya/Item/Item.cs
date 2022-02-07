using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using ServiceStack;

namespace Parsec.Shaiya.Item
{
    public class Item : SData.SData, IJsonReadable, ICsv
    {
        public int MaxType { get; set; }
        public List<Type> Types { get; } = new();

        [JsonIgnore]
        public Dictionary<(byte type, byte typeId), ItemDefinition> ItemIndex = new();

        public override void Read(params object[] options)
        {
            MaxType = _binaryReader.Read<int>();

            for (int i = 0; i < MaxType; i++)
            {
                var type = new Type(_binaryReader, ItemIndex);
                Types.Add(type);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(MaxType.GetBytes());

            foreach (var type in Types)
                buffer.AddRange(type.GetBytes());

            return buffer.ToArray();
        }

        /// <inheritdoc />
        public void ExportCSV(string path)
        {
            var csv = ItemIndex.Values.ToList().ToCsv();
            FileHelper.WriteFile(path, csv.GetBytes());
        }

        /// <summary>
        /// Reads the Item.SData format from a csv file
        /// </summary>
        /// <param name="path">csv file path</param>
        /// <returns><see cref="Item"/> instance</returns>
        public static Item ReadFromCSV(string path)
        {
            // Read all item definitions from csv file
            var itemDefinitions = File.ReadAllText(path).FromCsv<List<ItemDefinition>>();

            // Create Item.SData instance
            var item = new Item
            {
                MaxType = itemDefinitions.Max(x => x.Type),
                ItemIndex = itemDefinitions.ToDictionary(itemDef => (itemDef.Type, itemDef.TypeId))
            };

            // Group items by Type
            var groupedItems = itemDefinitions.GroupBy(x => x.Type);

            foreach (var typeGroup in groupedItems)
            {
                var maxTypeId = typeGroup.Max(x => x.TypeId);

                var type = new Type(maxTypeId, typeGroup.ToList());
                item.Types.Add(type);
            }

            return item;
        }
    }
}
