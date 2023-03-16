using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Shaiya.Core;
using Parsec.Shaiya.Data;

namespace Parsec;

public static class Reader
{
    /// <summary>
    /// Reads a shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="options">Array of reading options</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T ReadFromFile<T>(string path, params object[] options) where T : FileBase, new() =>
        FileBase.ReadFromFile<T>(path, options);

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="options">Array of reading options</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromFile(string path, Type type, params object[] options) =>
        FileBase.ReadFromFile(path, type, options);

    /// <summary>
    /// Reads a shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="options">Array of reading options</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T ReadFromBuffer<T>(string name, byte[] buffer, params object[] options) where T : FileBase, new() =>
        FileBase.ReadFromBuffer<T>(name, buffer, options);

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="options">Array of reading options</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromBuffer(string name, byte[] buffer, Type type, params object[] options) =>
        FileBase.ReadFromBuffer(name, buffer, type);

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="path">Path to json file</param>
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static T ReadFromJsonFile<T>(string path, Encoding encoding = null) where T : FileBase =>
        (T)ReadFromJsonFile(path, typeof(T), encoding);

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="path">Path to json file</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static FileBase ReadFromJsonFile(string path, Type type, Encoding encoding = null)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        if (!FileHelper.FileExists(path))
            throw new FileNotFoundException($"File ${path} not found");

        if (Path.GetExtension(path) != ".json")
            throw new FileLoadException("The provided file to deserialize must be a valid json file");

        // Set default encoding
        encoding ??= Encoding.ASCII;

        // Read json file content
        string jsonContent = File.ReadAllText(path, encoding);
        // Deserialize into FileBase
        var deserializedObject = (FileBase)JsonConvert.DeserializeObject(jsonContent, type);
        // Get file name without the ".json" extension
        string fileNameWithoutJsonExtension = Path.GetFileNameWithoutExtension(path);

        if (deserializedObject == null)
            return null;

        deserializedObject.Encoding = encoding;
        string objectExtension = deserializedObject.Extension;
        if (Path.GetExtension(fileNameWithoutJsonExtension) != objectExtension)
            deserializedObject.Path = $"{fileNameWithoutJsonExtension}.{objectExtension}";

        return deserializedObject;
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="name">Instance name</param>
    /// <param name="jsonText">json text</param>
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static T ReadFromJson<T>(string name, string jsonText, Encoding encoding = null) where T : FileBase
        => (T)ReadFromJson(name, jsonText, typeof(T), encoding);

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="name">Instance name</param>
    /// <param name="jsonText">json text</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static FileBase ReadFromJson(string name, string jsonText, Type type, Encoding encoding = null)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        // Set default encoding
        encoding ??= Encoding.ASCII;

        // Deserialize into FileBase
        var deserializedObject = (FileBase)JsonConvert.DeserializeObject(jsonText, type);
        if (deserializedObject == null)
            return null;

        deserializedObject.Encoding = encoding;
        deserializedObject.Path = name;
        return deserializedObject;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="options">Array of reading options</param>
    /// <returns>FileBase instance</returns>
    public static T ReadFromData<T>(Data data, SFile file, params object[] options) where T : FileBase, new() =>
        FileBase.ReadFromData<T>(data, file, options);

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="options">Array of reading options</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromData(Data data, SFile file, Type type, params object[] options) =>
        FileBase.ReadFromData(data, file, type, options);
}
