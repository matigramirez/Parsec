using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Readers;

namespace Parsec.Shaiya.Core
{
    public abstract class FileBase : IFileBase, IExportable, IJsonable<FileBase>
    {
        protected readonly ShaiyaBinaryReader _binaryReader;

        protected byte[] Buffer => _binaryReader.Buffer;

        [JsonIgnore]
        public string Path { get; set; }

        [JsonIgnore]
        public string FileName => Path.Split('/', '\\').LastOrDefault();

        [JsonIgnore]
        public string FileNameWithoutExtension => FileName.Split('.').FirstOrDefault();

        public FileBase(string path)
        {
            Path = path;
            _binaryReader = new ShaiyaBinaryReader(path);
        }

        public abstract void Read();

        protected void ResetCursor() =>
            _binaryReader.SetOffset(0);

        public virtual void Export(string path) =>
            FileHelper.WriteFile(path, Encoding.ASCII.GetBytes(JsonSerialize(this)));

        public void Export(string path, IEnumerable<string> ignoredPropertyNames) =>
            FileHelper.WriteFile(path, Encoding.ASCII.GetBytes(JsonSerialize(this, ignoredPropertyNames)));

        public virtual string JsonSerialize(FileBase obj) => JsonConvert.SerializeObject(obj);

        public string JsonSerialize(FileBase obj, IEnumerable<string> ignoredPropertyNames)
        {
            // Create settings with contract resolver to ignore certain properties
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new IgnorePropertiesResolver(ignoredPropertyNames)
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
