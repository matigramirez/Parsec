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
    public void WriteJson(string path, params string[] ignoredPropertyNames) =>
        FileHelper.WriteFile(path, JsonSerialize(this, ignoredPropertyNames), Encoding);

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

    /// <inheritdoc/>
    public virtual void Read()
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

            object value = ReflectionHelper.ReadProperty(_binaryReader, type, this, property, Episode, Encoding);
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

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T ReadFromFile<T>(string path, Episode episode = Episode.EP5, Encoding encoding = null) where T : FileBase, new()
    {
        var instance = new T
        {
            Path = path, _binaryReader = new SBinaryReader(path), Episode = episode, Encoding = encoding ?? Encoding.ASCII
        };

        if (instance is IEncryptable encryptableInstance)
            encryptableInstance.DecryptBuffer();

        instance.Read();
        instance._binaryReader?.Dispose();

        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromFile(string path, Type type, Episode episode = Episode.EP5, Encoding encoding = null)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        var binaryReader = new SBinaryReader(path);
        var instance = (FileBase)Activator.CreateInstance(type);
        instance.Path = path;
        instance._binaryReader = binaryReader;
        instance.Episode = episode;
        instance.Encoding = encoding ?? Encoding.ASCII;

        if (instance is IEncryptable encryptableInstance)
            encryptableInstance.DecryptBuffer();

        instance.Read();
        instance._binaryReader?.Dispose();

        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T ReadFromBuffer<T>(string name, byte[] buffer, Episode episode = Episode.EP5, Encoding encoding = null)
        where T : FileBase, new()
    {
        var instance = new T
        {
            Path = name, _binaryReader = new SBinaryReader(buffer), Episode = episode, Encoding = encoding ?? Encoding.ASCII
        };

        if (instance is IEncryptable encryptableInstance)
            encryptableInstance.DecryptBuffer();

        instance.Read();
        instance._binaryReader?.Dispose();

        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromBuffer(string name, byte[] buffer, Type type, Episode episode = Episode.EP5, Encoding encoding = null)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        var instance = (FileBase)Activator.CreateInstance(type);
        instance.Path = name;
        instance._binaryReader = new SBinaryReader(buffer);
        instance.Episode = episode;
        instance.Encoding = encoding ?? Encoding.ASCII;

        if (instance is IEncryptable encryptableInstance)
            encryptableInstance.DecryptBuffer();

        instance.Read();
        instance._binaryReader?.Dispose();

        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static T ReadFromData<T>(Data.Data data, SFile file, Episode episode = Episode.EP5, Encoding encoding = null)
        where T : FileBase, new() =>
        ReadFromBuffer<T>(file.Name, data.GetFileBuffer(file), episode, encoding);

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromData(Data.Data data, SFile file, Type type, Episode episode = Episode.EP5, Encoding encoding = null)
    {
        if (!data.FileIndex.ContainsValue(file))
            throw new FileNotFoundException("The provided SFile instance is not part of the Data");

        return ReadFromBuffer(file.Name, data.GetFileBuffer(file), type, episode, encoding);
    }
}
