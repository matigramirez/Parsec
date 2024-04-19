using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Data;

namespace Parsec.Shaiya.Core;

[JsonDerivedType(typeof(_3dc._3dc))]
[JsonDerivedType(typeof(_3dc.Static3dc))]
[JsonDerivedType(typeof(_3de._3de))]
[JsonDerivedType(typeof(_3do._3do))]
[JsonDerivedType(typeof(Alt.Alt))]
[JsonDerivedType(typeof(Ani.Ani))]
[JsonDerivedType(typeof(Cash.Cash))]
[JsonDerivedType(typeof(Cash.DBItemSellData))]
[JsonDerivedType(typeof(Cash.DBItemSellText))]
[JsonDerivedType(typeof(Cloak.ClothTexture.Ctl))]
[JsonDerivedType(typeof(Cloak.Emblem.EmblemDat))]
[JsonDerivedType(typeof(Data.Sah))]
[JsonDerivedType(typeof(Dg.Dg))]
[JsonDerivedType(typeof(DualLayerClothes.DualLayerClothes))]
[JsonDerivedType(typeof(DualLayerClothes.DBDualLayerClothesData))]
[JsonDerivedType(typeof(Eft.Eft))]
[JsonDerivedType(typeof(GuildHouse.GuildHouse))]
[JsonDerivedType(typeof(Item.Item))]
[JsonDerivedType(typeof(Item.DBItemData))]
[JsonDerivedType(typeof(Item.DBItemText))]
[JsonDerivedType(typeof(Itm.Itm))]
[JsonDerivedType(typeof(KillStatus.KillStatus))]
[JsonDerivedType(typeof(Mani.Mani))]
[JsonDerivedType(typeof(Mlt.Mlt))]
[JsonDerivedType(typeof(Mlx.Mlx))]
[JsonDerivedType(typeof(Mon.Mon))]
[JsonDerivedType(typeof(Monster.Monster))]
[JsonDerivedType(typeof(Monster.DBMonsterData))]
[JsonDerivedType(typeof(Monster.DBMonsterText))]
[JsonDerivedType(typeof(NpcQuest.NpcQuest))]
[JsonDerivedType(typeof(NpcQuest.NpcQuestTrans))]
[JsonDerivedType(typeof(NpcSkill.DBNpcSkillData))]
[JsonDerivedType(typeof(NpcSkill.DBNpcSkillText))]
[JsonDerivedType(typeof(Seff.Seff))]
[JsonDerivedType(typeof(SetItem.SetItem))]
[JsonDerivedType(typeof(SetItem.DBSetItemData))]
[JsonDerivedType(typeof(SetItem.DBSetItemText))]
[JsonDerivedType(typeof(Skill.Skill))]
[JsonDerivedType(typeof(Skill.DBSkillData))]
[JsonDerivedType(typeof(Skill.DBSkillText))]
[JsonDerivedType(typeof(Smod.Smod))]
[JsonDerivedType(typeof(Svmap.Svmap))]
[JsonDerivedType(typeof(TransformModel.DBTransformModelData))]
[JsonDerivedType(typeof(TransformModel.DBTransformWeaponModelData))]
[JsonDerivedType(typeof(Vani.Vani))]
[JsonDerivedType(typeof(Wld.Wld))]
[JsonDerivedType(typeof(Wtr.Wtr))]
[JsonDerivedType(typeof(Zon.Zon))]
public abstract class FileBase : IJsonWritable<FileBase>
{
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
    public void WriteJson(string path, params string[] ignoredPropertyNames)
    {
        File.WriteAllText(path, JsonSerialize(this, ignoredPropertyNames), Encoding);
    }

    /// <inheritdoc/>
    public virtual string JsonSerialize(FileBase obj, params string[] ignoredPropertyNames)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        return JsonSerializer.Serialize(obj, options);
    }

    protected abstract void Read(SBinaryReader binaryReader);

    protected abstract void Write(SBinaryWriter binaryWriter);

    public void Write(string path)
    {
        var serializationOptions = new BinarySerializationOptions(Episode, Encoding);
        using var binaryWriter = new SBinaryWriter(path, serializationOptions);
        Write(binaryWriter);
    }

    public void Write(string path, Episode episode, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;

        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        using var binaryWriter = new SBinaryWriter(path, serializationOptions);
        Write(binaryWriter);
    }

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="serializationOptions">Serialization options</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    internal static T ReadFromFile<T>(string path, BinarySerializationOptions serializationOptions) where T : FileBase, new()
    {
        var instance = new T { Path = path, Episode = serializationOptions.Episode, Encoding = serializationOptions.Encoding };
        using var binaryReader = new SBinaryReader(path, serializationOptions);

        if (instance is IEncryptable encryptableInstance)
        {
            encryptableInstance.DecryptBuffer(binaryReader);
        }

        instance.Read(binaryReader);
        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="serializationOptions">Serialization options</param>
    /// <returns>FileBase instance</returns>
    internal static FileBase ReadFromFile(string path, Type type, BinarySerializationOptions serializationOptions)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        var instance = (FileBase)Activator.CreateInstance(type);
        instance.Path = path;
        instance.Episode = serializationOptions.Episode;
        instance.Encoding = serializationOptions.Encoding;

        using var binaryReader = new SBinaryReader(path, serializationOptions);

        if (instance is IEncryptable encryptableInstance)
        {
            encryptableInstance.DecryptBuffer(binaryReader);
        }

        instance.Read(binaryReader);
        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="serializationOptions">Serialization options</param>
    /// <typeparam name="T">Shaiya File Format Type</typeparam>
    /// <returns>T instance</returns>
    internal static T ReadFromBuffer<T>(string name, byte[] buffer, BinarySerializationOptions serializationOptions) where T : FileBase, new()
    {
        var instance = new T { Path = name, Episode = serializationOptions.Episode, Encoding = serializationOptions.Encoding };
        using var binaryReader = new SBinaryReader(buffer, serializationOptions);

        if (instance is IEncryptable encryptableInstance)
        {
            encryptableInstance.DecryptBuffer(binaryReader);
        }

        instance.Read(binaryReader);
        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array)
    /// </summary>
    /// <param name="name">File name</param>
    /// <param name="buffer">File buffer</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="serializationOptions">Serialization options</param>
    /// <returns>FileBase instance</returns>
    internal static FileBase ReadFromBuffer(string name, byte[] buffer, Type type, BinarySerializationOptions serializationOptions)
    {
        if (!type.GetBaseClassesAndInterfaces().Contains(typeof(FileBase)))
            throw new ArgumentException("Type must be a child of FileBase");

        var instance = (FileBase)Activator.CreateInstance(type);
        instance.Path = name;
        instance.Episode = serializationOptions.Episode;
        instance.Encoding = serializationOptions.Encoding;

        using var binaryReader = new SBinaryReader(buffer, serializationOptions);

        if (instance is IEncryptable encryptableInstance)
        {
            encryptableInstance.DecryptBuffer(binaryReader);
        }

        instance.Read(binaryReader);
        return instance;
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="serializationOptions">Serialization options</param>
    /// <returns>FileBase instance</returns>
    internal static T ReadFromData<T>(Data.Data data, SFile file, BinarySerializationOptions serializationOptions) where T : FileBase, new()
    {
        return ReadFromBuffer<T>(file.Name, data.GetFileBuffer(file), serializationOptions);
    }

    /// <summary>
    /// Reads the shaiya file format from a buffer (byte array) within a <see cref="Data"/> instance
    /// </summary>
    /// <param name="data"><see cref="Data"/> instance</param>
    /// <param name="file"><see cref="SFile"/> instance</param>
    /// <param name="type">FileBase child type to be read</param>
    /// <param name="serializationOptions"></param>
    /// <returns>FileBase instance</returns>
    internal static FileBase ReadFromData(Data.Data data, SFile file, Type type, BinarySerializationOptions serializationOptions)
    {
        if (!data.FileIndex.ContainsValue(file))
            throw new FileNotFoundException("The provided SFile instance is not part of the Data");

        return ReadFromBuffer(file.Name, data.GetFileBuffer(file), type, serializationOptions);
    }

    public IEnumerable<byte> GetBytes()
    {
        var serializationOptions = BinarySerializationOptions.Default;
        return GetBytes(serializationOptions);
    }

    public IEnumerable<byte> GetBytes(Episode episode, Encoding? encoding = null)
    {
        var serializationOptions = new BinarySerializationOptions(episode, encoding);
        return GetBytes(serializationOptions);
    }

    public IEnumerable<byte> GetBytes(BinarySerializationOptions serializationOptions)
    {
        using var memoryStream = new MemoryStream();
        using var binaryWriter = new SBinaryWriter(memoryStream, serializationOptions);
        Write(binaryWriter);
        return memoryStream.ToArray();
    }
}
