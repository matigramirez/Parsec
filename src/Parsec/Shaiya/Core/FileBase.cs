using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Readers;

namespace Parsec.Shaiya.Core
{
    public abstract class FileBase : IFileBase, IExportable<FileBase>
    {
        [JsonIgnore]
        protected ShaiyaBinaryReader _binaryReader;

        /// <summary>
        /// The file's byte array
        /// </summary>
        protected byte[] Buffer => _binaryReader.Buffer;

        /// <summary>
        /// Full path to the file
        /// </summary>
        [JsonIgnore]
        public string Path { get; set; } = "";

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

        [JsonConstructor]
        public FileBase()
        {
        }

        /// <inheritdoc/>
        public virtual void Read() =>
            throw new NotImplementedException("Reading hasn't been implemented yet for this format.");

        /// <inheritdoc />
        public abstract void Write(string path);

        /// <inheritdoc/>
        public void ExportJson(string path, IEnumerable<string> ignoredPropertyNames = null, bool enumFriendly = false, bool ignoreDefaults = false) =>
            FileHelper.WriteFile(path, Encoding.ASCII.GetBytes(JsonSerialize(this, ignoredPropertyNames, enumFriendly, ignoreDefaults)));

        /// <inheritdoc/>
        public virtual string JsonSerialize(FileBase obj, IEnumerable<string> ignoredPropertyNames = null, bool enumFriendly = false, bool ignoreDefaults = false)
        {
            // Create settings with contract resolver to ignore certain properties
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new PropertyFilterCamelCaseResolver(ignoredPropertyNames),
                DefaultValueHandling = ignoreDefaults ? DefaultValueHandling.Ignore : DefaultValueHandling.Include
            };

            // Add enum to string converter
            if(enumFriendly)
                settings.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
