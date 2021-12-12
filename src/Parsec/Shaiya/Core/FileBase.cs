using System.Collections.Generic;
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
        [JsonIgnore]
        public byte[] Buffer
        {
            get => _binaryReader.Buffer;
            set => _binaryReader = new ShaiyaBinaryReader(value);
        }

        /// <summary>
        /// Full path to the file
        /// </summary>
        [JsonIgnore]
        public string Path { get; set; } = "";

        [JsonIgnore]
        public abstract string Extension { get; }

        /// <summary>
        /// Plain file name
        /// </summary>
        [JsonIgnore]
        public string FileName => System.IO.Path.GetFileName(Path);

        /// <summary>
        /// File name without the extension (.xx)
        /// </summary>
        [JsonIgnore]
        public string FileNameWithoutExtension => System.IO.Path.GetFileNameWithoutExtension(Path);

        public FileBase(ShaiyaBinaryReader binaryReader)
        {
        }

        [JsonConstructor]
        public FileBase()
        {
        }

        /// <summary>
        /// Reads the shaiya file format from a file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="options">Array of reading options</param>
        /// <typeparam name="T">Shaiya File Format Type</typeparam>
        /// <returns>T instance</returns>
        public static T ReadFromFile<T>(string path, params object[] options) where T : FileBase, new()
        {
            var binaryReader = new ShaiyaBinaryReader(path);
            var instance = new T()
            {
                Path = path,
                _binaryReader = binaryReader
            };

            // Parse the file
            instance.Read(options);
            return instance;
        }

        /// <summary>
        /// Reads the shaiya file format from a buffer (byte array)
        /// </summary>
        /// <param name="buffer">File buffer</param>
        /// <param name="options">Array of reading options</param>
        /// <typeparam name="T">Shaiya File Format Type</typeparam>
        /// <returns>T instance</returns>
        public static T ReadFromBuffer<T>(byte[] buffer, params object[] options) where T : FileBase, new()
        {
            var binaryReader = new ShaiyaBinaryReader(buffer);
            var instance = new T
            {
                _binaryReader = binaryReader
            };

            // Parse the file
            instance.Read(options);
            return instance;
        }

        /// <inheritdoc/>
        public abstract void Read(params object[] options);

        /// <inheritdoc />
        public abstract void Write(string path, params object[] options);

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
            if (enumFriendly)
                settings.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
