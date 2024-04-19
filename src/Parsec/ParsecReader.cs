using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;
using Parsec.Shaiya.Data;

namespace Parsec;

public static class ParsecReader
{
    /// <summary>
    /// Reads a shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T FromFile<T>(string path, Episode episode = Episode.EP5, Encoding? encoding = null) where T : FileBase, new()
    {
        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        return FileBase.ReadFromFile<T>(path, serializationOptions);
    }

    /// <summary>
    /// Reads a shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    public static Task<T> FromFileAsync<T>(string path, Episode episode = Episode.EP5, Encoding? encoding = null) where T : FileBase, new()
    {
        return Task.FromResult(FromFile<T>(path, episode, encoding));
    }

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase FromFile(string path, Type type, Episode episode = Episode.EP5, Encoding? encoding = null)
    {
        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        return FileBase.ReadFromFile(path, type, serializationOptions);
    }

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<FileBase> FromFileAsync(string path, Type type, Episode episode = Episode.EP5, Encoding? encoding = null)
    {
        return Task.FromResult(FromFile(path, type, episode, encoding));
    }

    /// <summary>
    /// Reads a shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    public static T FromBuffer<T>(string name, byte[] buffer, Episode episode = Episode.EP5, Encoding? encoding = null) where T : FileBase, new()
    {
        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        return FileBase.ReadFromBuffer<T>(name, buffer, serializationOptions);
    }

    /// <summary>
    /// Reads a shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    public static Task<T> FromBufferAsync<T>(string name, byte[] buffer, Episode episode = Episode.EP5, Encoding? encoding = null) where T : FileBase, new()
    {
        return Task.FromResult(FromBuffer<T>(name, buffer, episode));
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
    public static FileBase FromBuffer(string name, byte[] buffer, Type type, Episode episode = Episode.EP5, Encoding? encoding = null)
    {
        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        return FileBase.ReadFromBuffer(name, buffer, type, serializationOptions);
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<FileBase> FromBufferAsync(string name, byte[] buffer, Type type, Episode episode = Episode.EP5, Encoding? encoding = null)
    {
        return Task.FromResult(FromBuffer(name, buffer, type, episode, encoding));
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="path">Path to json file</param>
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static T FromJsonFile<T>(string path, Encoding? encoding = null) where T : FileBase
    {
        return (T)FromJsonFile(path, typeof(T), encoding);
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="path">Path to json file</param>
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    public static Task<T> FromJsonFileAsync<T>(string path, Encoding? encoding = null) where T : FileBase
    {
        return Task.FromResult(FromJsonFile<T>(path, encoding));
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="path">Path to json file</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static FileBase FromJsonFile(string path, Type type, Encoding? encoding = null)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        if (!File.Exists(path))
            throw new FileNotFoundException($"File ${path} not found");

        if (Path.GetExtension(path) != ".json")
            throw new FileLoadException("The provided file to deserialize must be a valid json file");

        encoding ??= Encoding.ASCII;

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        var jsonContent = File.ReadAllText(path, encoding);
        var deserializedObject = JsonSerializer.Deserialize(jsonContent, type, options);

        if (deserializedObject == null)
        {
            throw new SerializationException("The provided file to deserialize is not a valid json file");
        }

        var fileBase = (FileBase)deserializedObject;
        fileBase.Encoding = encoding;

        return fileBase;
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="path">Path to json file</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    public static Task<FileBase> FromJsonFileAsync(string path, Type type, Encoding? encoding = null)
    {
        return Task.FromResult(FromJsonFile(path, type, encoding));
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="name">Instance name</param>
    /// <param name="jsonText">json text</param>
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static T FromJson<T>(string name, string jsonText, Encoding? encoding = null) where T : FileBase
    {
        return (T)FromJson(name, jsonText, typeof(T), encoding);
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="name">Instance name</param>
    /// <param name="jsonText">json text</param>
    /// <param name="encoding">String encoding</param>
    /// <typeparam name="T"><see cref="FileBase"/> type</typeparam>
    public static Task<T> FromJsonAsync<T>(string name, string jsonText, Encoding? encoding = null) where T : FileBase
    {
        return Task.FromResult(FromJson<T>(name, jsonText, encoding));
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="name">Instance name</param>
    /// <param name="jsonText">json text</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    /// <returns><see cref="FileBase"/> instance</returns>
    public static FileBase FromJson(string name, string jsonText, Type type, Encoding? encoding = null)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        encoding ??= Encoding.ASCII;

        var deserializedObject = JsonSerializer.Deserialize(jsonText, type);

        if (deserializedObject == null)
        {
            throw new SerializationException("The provided file to deserialize is not a valid json file");
        }

        var fileBase = (FileBase)deserializedObject;
        fileBase.Encoding = encoding;
        fileBase.Path = name;
        return fileBase;
    }

    /// <summary>
    /// Reads a shaiya file format from a json file
    /// </summary>
    /// <param name="name">Instance name</param>
    /// <param name="jsonText">json text</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="encoding">String encoding</param>
    public static Task<FileBase> FromJsonAsync(string name, string jsonText, Type type, Encoding? encoding = null)
    {
        return Task.FromResult(FromJson(name, jsonText, type, encoding));
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static T FromData<T>(Data data, SFile file, Episode episode = Episode.EP5, Encoding? encoding = null) where T : FileBase, new()
    {
        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        return FileBase.ReadFromData<T>(data, file, serializationOptions);
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<T> FromDataAsync<T>(Data data, SFile file, Episode episode = Episode.EP5, Encoding? encoding = null) where T : FileBase, new()
    {
        return Task.FromResult(FromData<T>(data, file, episode, encoding));
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    /// <returns>FileBase instance</returns>
    public static FileBase FromData(Data data, SFile file, Type type, Episode episode = Episode.EP5, Encoding? encoding = null)
    {
        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        return FileBase.ReadFromData(data, file, type, serializationOptions);
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="episode">File episode</param>
    /// <param name="encoding">File encoding</param>
    public static Task<FileBase> FromDataAsync(Data data, SFile file, Type type, Episode episode = Episode.EP5, Encoding? encoding = null)
    {
        return Task.FromResult(FromData(data, file, type, episode, encoding));
    }
}
