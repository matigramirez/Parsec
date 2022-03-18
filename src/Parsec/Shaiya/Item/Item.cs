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
        public ItemFormat Format { get; set; } = ItemFormat.EP5;
        public int MaxType { get; set; }
        public List<Type> Types { get; } = new();

        [JsonIgnore]
        public Dictionary<(byte type, byte typeId), IItemDefinition> ItemIndex = new();

        public override void Read(params object[] options)
        {
            if (options.Length > 0)
                Format = (ItemFormat)options[0];

            MaxType = _binaryReader.Read<int>();

            for (int i = 0; i < MaxType; i++)
            {
                var type = new Type(_binaryReader, Format, ItemIndex);
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
            string csv;

            switch (Format)
            {
                case ItemFormat.EP5:
                default:
                    csv = ItemIndex.Values.ToList().ConvertTo<List<ItemDefinitionEp5>>().ToCsv();
                    break;
                case ItemFormat.EP6:
                    csv = ItemIndex.Values.ToList().ConvertTo<List<ItemDefinitionEp6>>().ToCsv();
                    break;
            }

            FileHelper.WriteFile(path, csv.GetBytes());
        }

        /// <summary>
        /// Reads the Item.SData format from a csv file
        /// </summary>
        /// <param name="path">csv file path</param>
        /// <param name="format">The Item.SData format</param>
        /// <returns><see cref="Item"/> instance</returns>
        public static Item ReadFromCSV(string path, ItemFormat format)
        {
            // Create Item.SData instance
            var item = new Item();

            // Read all item definitions from csv file
            switch (format)
            {
                case ItemFormat.EP5:
                default:
                {
                    var itemDefinitions = File.ReadAllText(path).FromCsv<List<ItemDefinitionEp5>>();
                    var genericItemDefinitions = itemDefinitions.Cast<IItemDefinition>().ToList();
                    item.MaxType = itemDefinitions.Max(x => x.Type);
                    var itemIndex = genericItemDefinitions.ToDictionary(itemDef => (itemDef.Type, itemDef.TypeId));
                    item.ItemIndex = itemIndex;
                    break;
                }
                case ItemFormat.EP6:
                {
                    var itemDefinitions = File.ReadAllText(path).FromCsv<List<ItemDefinitionEp6>>();
                    var genericItemDefinitions = itemDefinitions.Cast<IItemDefinition>().ToList();
                    item.MaxType = itemDefinitions.Max(x => x.Type);
                    var itemIndex = genericItemDefinitions.ToDictionary(itemDef => (itemDef.Type, itemDef.TypeId));
                    item.ItemIndex = itemIndex;
                    break;
                }
            }

            // Group items by Type
            var groupedItems = item.ItemIndex.Values.GroupBy(x => x.Type);

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
