using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Readers;
using Parsec.Shaiya.Data;

namespace Parsec.Shaiya.Core;

public abstract class FileBase : IFileBase, IExportable<FileBase>
{
    [JsonIgnore]
    protected SBinaryReader _binaryReader;

    /// <summary>
    /// The file's byte array
    /// </summary>
    [JsonIgnore]
    public byte[] Buffer
    {
        get => _binaryReader.Buffer;
        set => _binaryReader = new SBinaryReader(value);
    }

    /// <summary>
    /// Full path to the file
    /// </summary>
    [JsonIgnore]
    public string Path { get; set; } = "";

    [JsonIgnore]
    public abstract string Extension { get; }

    public Episode Episode { get; set; } = Episode.Unknown;

    [JsonIgnore]
    public Encoding Encoding { get; set; } = Encoding.ASCII;

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

    /// <inheritdoc/>
    public void ExportJson(string path, params string[] ignoredPropertyNames) =>
        FileHelper.WriteFile(path, Encoding.ASCII.GetBytes(JsonSerialize(this, ignoredPropertyNames)));

    /// <inheritdoc/>
    public virtual string JsonSerialize(FileBase obj, params string[] ignoredPropertyNames)
    {
        // Create settings with contract resolver to ignore certain properties
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.Include,
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
            Formatting = Formatting.Indented
        };

        // Add enum to string converter
        settings.Converters.Add(new StringEnumConverter());
        return JsonConvert.SerializeObject(obj, settings);
    }

    /// <inheritdoc/>
    public virtual void Read(params object[] options)
    {
        var type = GetType();

        // Set default version (Episode) if defined. This must be checked/set before checking the existence of the VersionPrefixedAttribute
        if (type.IsDefined(typeof(DefaultVersionAttribute)))
        {
            var defaultEpisodeAttribute = type.GetCustomAttributes<DefaultVersionAttribute>().First();
            Episode = defaultEpisodeAttribute.Episode;
        }

        // Check if version prefix could be present (eg. "ANI_V2", "MO2", "MO4", etc)
        bool isVersionPrefixed = type.IsDefined(typeof(VersionPrefixedAttribute));

        if (isVersionPrefixed)
        {
            var versionPrefixes = type.GetCustomAttributes<VersionPrefixedAttribute>();

            foreach (var versionPrefix in versionPrefixes)
            {
                object filePrefix;
                if (versionPrefix.PrefixType == typeof(string))
                {
                    filePrefix = _binaryReader.ReadString(((string)versionPrefix.Prefix).Length);
                }
                else if (versionPrefix.PrefixType.IsPrimitive)
                {
                    filePrefix = ReflectionHelper.ReadPrimitive(_binaryReader, versionPrefix.PrefixType);
                }
                else
                {
                    continue;
                }

                // If prefix matches, episode must be set and reading must continue. If it doesn't, the reading offset must be reset to the beginning of the file
                if (filePrefix.Equals(versionPrefix.Prefix))
                {
                    Episode = versionPrefix.MinEpisode;
                    break;
                }

                _binaryReader.ResetOffset();
            }
        }

        // Read all properties
        var properties = GetType().GetProperties();

        foreach (var property in properties)
        {
            // skip non ShaiyaProperty properties
            if (!property.IsDefined(typeof(ShaiyaPropertyAttribute)))
                continue;

            object value = ReflectionHelper.ReadProperty(_binaryReader, type, this, property, Episode);
            property.SetValue(this, Convert.ChangeType(value, property.PropertyType));

            // Set episode based on property
            if (property.IsDefined(typeof(EpisodeDefinerAttribute)))
            {
                var definerAttributes = property.GetCustomAttributes<EpisodeDefinerAttribute>();
                foreach (var definer in definerAttributes)
                {
                    if (value.Equals(definer.Value))
                    {
                        Episode = definer.Episode;
                    }
                }
            }
        }
    }

    /// <inheritdoc />
    public virtual void Write(string path, Episode episode = Episode.Unknown) => FileHelper.WriteFile(path, GetBytes(episode));

    /// <inheritdoc />
    public virtual IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        var type = GetType();

        // If episode wasn't explicitly set, use former episode
        if (episode == Episode.Unknown)
            episode = Episode;

        if (episode == Episode.Unknown && type.IsDefined(typeof(DefaultVersionAttribute)))
        {
            var defaultEpisodeAttribute = type.GetCustomAttributes<DefaultVersionAttribute>().FirstOrDefault();
            episode = defaultEpisodeAttribute!.Episode;
        }

        // Add version prefix if present (eg. "ANI_V2", "MO2", "MO4", etc)
        bool isVersionPrefixed = type.IsDefined(typeof(VersionPrefixedAttribute));
        if (isVersionPrefixed)
        {
            var versionPrefixes = type.GetCustomAttributes<VersionPrefixedAttribute>();

            foreach (var versionPrefix in versionPrefixes)
            {
                if ((episode == versionPrefix.MinEpisode && versionPrefix.MaxEpisode == Episode.Unknown) ||
                    (episode >= versionPrefix.MinEpisode && episode <= versionPrefix.MaxEpisode))
                {
                    if (versionPrefix.PrefixType == typeof(string))
                    {
                        buffer.AddRange(((string)versionPrefix.Prefix).GetBytes());
                    }
                    else if (versionPrefix.PrefixType.IsPrimitive)
                    {
                        buffer.AddRange(ReflectionHelper.GetPrimitiveBytes(versionPrefix.PrefixType, versionPrefix.Prefix));
                    }
                }
            }
        }

        // Get bytes for all properties
        var properties = GetType().GetProperties();
        foreach (var property in properties)
        {
            if (!property.IsDefined(typeof(ShaiyaPropertyAttribute)))
                continue;

            buffer.AddRange(ReflectionHelper.GetPropertyBytes(type, this, property, Encoding, episode));
        }

        return buffer;
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
        var binaryReader = new SBinaryReader(path);
        var instance = new T { Path = path, _binaryReader = binaryReader };

        if (instance is IEncryptable encryptableInstance)
            encryptableInstance.DecryptBuffer();

        // Parse the file
        instance.Read(options);
        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="options">Array of reading options</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T ReadFromBuffer<T>(string name, byte[] buffer, params object[] options) where T : FileBase, new()
    {
        var binaryReader = new SBinaryReader(buffer);
        var instance = new T { Path = name, _binaryReader = binaryReader };

        if (instance is IEncryptable encryptableInstance)
            encryptableInstance.DecryptBuffer();

        // Parse the file
        instance.Read(options);
        return instance;
    }

    public static T ReadFromData<T>(Data.Data data, SFile file, params object[] options) where T : FileBase, new()
    {
        if (!data.FileIndex.ContainsValue(file))
            throw new FileNotFoundException("The provided SFile instance is not part of the Data");

        return ReadFromBuffer<T>(file.Name, data.GetFileBuffer(file), options);
    }
}
