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

        /// <summary>
        /// The file's byte array
        /// </summary>
        protected byte[] Buffer => _binaryReader.Buffer;

        /// <summary>
        /// Full path to the file
        /// </summary>
        [JsonIgnore]
        public string Path { get; set; }

        /// <summary>
        /// Plain file name
        /// </summary>
        [JsonIgnore]
        public string FileName => Path.Split('/', '\\').LastOrDefault();

        /// <summary>
        /// File name without the extension (.xx)
        /// </summary>
        [JsonIgnore]
        public string FileNameWithoutExtension => FileName.Split('.').FirstOrDefault();

        public FileBase(string path)
        {
            Path = path;
            _binaryReader = new ShaiyaBinaryReader(path);
        }

        /// <inheritdoc/>
        public abstract void Read();

        /// <inheritdoc/>
        public virtual void Export(string path) =>
            FileHelper.WriteFile(path, Encoding.ASCII.GetBytes(JsonSerialize(this)));

        /// <inheritdoc/>
        public void Export(string path, IEnumerable<string> ignoredPropertyNames) =>
            FileHelper.WriteFile(path, Encoding.ASCII.GetBytes(JsonSerialize(this, ignoredPropertyNames)));

        /// <inheritdoc/>
        public virtual string JsonSerialize(FileBase obj) => JsonConvert.SerializeObject(obj);

        /// <inheritdoc/>
        public virtual string JsonSerialize(FileBase obj, IEnumerable<string> ignoredPropertyNames)
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
