using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
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
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T ReadFromFile<T>(string path, Episode episode = Episode.EP5, Encoding encoding = null) where T : FileBase, new() =>
        FileBase.ReadFromFile<T>(path, episode, encoding);

    /// <summary>
    /// Reads a shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    public static Task<T> ReadFromFileAsync<T>(string path, Episode episode = Episode.EP5, Encoding encoding = null)
        where T : FileBase, new() =>
        Task.FromResult(ReadFromFile<T>(path, episode, encoding));

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromFile(string path, Type type, Episode episode = Episode.EP5, Encoding encoding = null) =>
        FileBase.ReadFromFile(path, type, episode, encoding);

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<FileBase> ReadFromFileAsync(string path, Type type, Episode episode = Episode.EP5, Encoding encoding = null) =>
        Task.FromResult(ReadFromFile(path, type, episode, encoding));

    /// <summary>
    /// Reads a shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T ReadFromBuffer<T>(string name, byte[] buffer, Episode episode = Episode.EP5, Encoding encoding = null)
        where T : FileBase, new() =>
        FileBase.ReadFromBuffer<T>(name, buffer, episode, encoding);


    /// <summary>
    /// Reads a shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    public static Task<T> ReadFromBufferAsync<T>(string name, byte[] buffer, Episode episode = Episode.EP5, Encoding encoding = null)
        where T : FileBase, new() =>
        Task.FromResult(ReadFromBuffer<T>(name, buffer, episode));

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromBuffer(string name, byte[] buffer, Type type, Episode episode = Episode.EP5, Encoding encoding = null) =>
        FileBase.ReadFromBuffer(name, buffer, type, episode, encoding);

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<FileBase> ReadFromBufferAsync(string name, byte[] buffer, Type type, Episode episode = Episode.EP5,
        Encoding encoding = null) =>
        Task.FromResult(ReadFromBuffer(name, buffer, type, episode, encoding));

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
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    public static Task<T> ReadFromJsonFileAsync<T>(string path, Encoding encoding = null) where T : FileBase =>
        Task.FromResult(ReadFromJsonFile<T>(path, encoding));

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

        encoding ??= Encoding.ASCII;

        string jsonContent = File.ReadAllText(path, encoding);
        var deserializedObject = (FileBase)JsonConvert.DeserializeObject(jsonContent, type);

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
    /// <param name="path">Path to json file</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    public static Task<FileBase> ReadFromJsonFileAsync(string path, Type type, Encoding encoding = null) =>
        Task.FromResult(ReadFromJsonFile(path, type, encoding));

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
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    public static Task<T> ReadFromJsonAsync<T>(string name, string jsonText, Encoding encoding = null) where T : FileBase
        => Task.FromResult(ReadFromJson<T>(name, jsonText, encoding));

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

        encoding ??= Encoding.ASCII;

        var deserializedObject = (FileBase)JsonConvert.DeserializeObject(jsonText, type);
        if (deserializedObject == null)
            return null;

        deserializedObject.Encoding = encoding;
        deserializedObject.Path = name;
        return deserializedObject;
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="name">Instance name</param>
    /// <param name="jsonText">json text</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    public static Task<FileBase> ReadFromJsonAsync(string name, string jsonText, Type type, Encoding encoding = null) =>
        Task.FromResult(ReadFromJson(name, jsonText, type, encoding));

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static T ReadFromData<T>(Data data, SFile file, Episode episode = Episode.EP5, Encoding encoding = null)
        where T : FileBase, new() =>
        FileBase.ReadFromData<T>(data, file, episode, encoding);

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<T> ReadFromDataAsync<T>(Data data, SFile file, Episode episode = Episode.EP5, Encoding encoding = null)
        where T : FileBase, new() =>
        Task.FromResult(ReadFromData<T>(data, file, episode, encoding));

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase ReadFromData(Data data, SFile file, Type type, Episode episode = Episode.EP5, Encoding encoding = null) =>
        FileBase.ReadFromData(data, file, type, episode, encoding);

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<FileBase> ReadFromDataAsync(Data data, SFile file, Type type, Episode episode = Episode.EP5,
        Encoding encoding = null) =>
        Task.FromResult(ReadFromData(data, file, type, episode, encoding));
}
