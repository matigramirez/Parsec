using System.Text;
using Parsec.Shaiya.Core;

namespace Parsec.Serialization;

/// <summary>
/// A binary reader made specifically to read Shaiya file formats
/// </summary>
public sealed class SBinaryReader : IDisposable
{
    private BinaryReader _binaryReader;
    public readonly BinarySerializationOptions SerializationOptions;

    public long StreamLength => _binaryReader.BaseStream.Length;

    public SBinaryReader(Stream stream, BinarySerializationOptions serializationOptions)
    {
        _binaryReader = new BinaryReader(stream);
        SerializationOptions = serializationOptions;
    }

    public SBinaryReader(FileStream fileStream, BinarySerializationOptions serializationOptions) : this((Stream)fileStream, serializationOptions)
    {
    }

    public SBinaryReader(MemoryStream memoryStream, BinarySerializationOptions serializationOptions) : this((Stream)memoryStream, serializationOptions)
    {
    }

    public SBinaryReader(string filePath, BinarySerializationOptions serializationOptions)
    {
        var fileStream = File.OpenRead(filePath);
        _binaryReader = new BinaryReader(fileStream);
        SerializationOptions = serializationOptions;
    }

    public SBinaryReader(byte[] buffer, BinarySerializationOptions serializationOptions)
    {
        var memoryStream = new MemoryStream(buffer);
        _binaryReader = new BinaryReader(memoryStream);
        SerializationOptions = serializationOptions;
    }

    public void ResetBuffer(byte[] buffer)
    {
        _binaryReader.Dispose();
        var memoryStream = new MemoryStream(buffer);
        _binaryReader = new BinaryReader(memoryStream);
    }

    public long Length => _binaryReader.BaseStream.Length;

    /// <summary>
    /// Reads a byte (unsigned)
    /// </summary>
    public byte ReadByte()
    {
        return _binaryReader.ReadByte();
    }

    /// <summary>
    /// Reads a signed byte (sbyte)
    /// </summary>
    public sbyte ReadSByte()
    {
        return _binaryReader.ReadSByte();
    }

    /// <summary>
    /// Reads a number of bytes
    /// </summary>
    /// <param name="count">Number of bytes to read</param>
    public byte[] ReadBytes(int count)
    {
        return _binaryReader.ReadBytes(count);
    }

    /// <summary>
    /// Reads a boolean value
    /// </summary>
    public bool ReadBool()
    {
        return _binaryReader.ReadBoolean();
    }

    /// <summary>
    /// Reads a char value
    /// </summary>
    public char ReadChar()
    {
        return _binaryReader.ReadChar();
    }

    /// <summary>
    /// Reads a signed short value (int16)
    /// </summary>
    public short ReadInt16()
    {
        return _binaryReader.ReadInt16();
    }

    /// <summary>
    /// Reads an unsigned short value (uint16)
    /// </summary>
    public ushort ReadUInt16()
    {
        return _binaryReader.ReadUInt16();
    }

    /// <summary>
    /// Reads a signed int value (int32)
    /// </summary>
    public int ReadInt32()
    {
        return _binaryReader.ReadInt32();
    }

    /// <summary>
    /// Reads an unsigned int value (uint32)
    /// </summary>
    public uint ReadUInt32()
    {
        return _binaryReader.ReadUInt32();
    }

    /// <summary>
    /// Reads a signed long (int64) value
    /// </summary>
    public long ReadInt64()
    {
        return _binaryReader.ReadInt64();
    }

    /// <summary>
    /// Reads an unsigned long (uint64) value
    /// </summary>
    public ulong ReadUInt64()
    {
        return _binaryReader.ReadUInt64();
    }

    /// <summary>
    /// Reads a float (single) value
    /// </summary>
    public float ReadSingle()
    {
        return _binaryReader.ReadSingle();
    }

    /// <summary>
    /// Reads a double value
    /// </summary>
    public double ReadDouble()
    {
        return _binaryReader.ReadDouble();
    }

    /// <summary>
    /// Reads a length-fixed string with the specified encoding
    /// </summary>
    /// <param name="encoding">The <see cref="Encoding"/> to be used</param>
    /// <param name="length">The length of the string</param>
    /// <param name="removeStringTerminator"></param>
    public string ReadString(Encoding encoding, int length, bool removeStringTerminator = true)
    {
        if (length <= 0)
        {
            return string.Empty;
        }

        // If encoding is UTF16, length needs to be doubled, since UTF16 uses 2 bytes per character
        if (encoding.Equals(Encoding.Unicode))
        {
            length *= 2;
        }

        var stringBytes = ReadBytes(length);
        var str = encoding.GetString(stringBytes, 0, length);

        if (removeStringTerminator && str.Length > 1 && str[str.Length - 1] == '\0')
        {
            str = str.Trim('\0');
        }

        if (str == "\0")
        {
            str = string.Empty;
        }

        return str;
    }

    /// <summary>
    /// Reads a variable string which has its length prefixed with little endian encoding.
    /// </summary>
    /// <param name="encoding">The <see cref="Encoding"/> to be used</param>
    /// <param name="removeStringTerminator">Indicates whether the string terminator (\0) should be removed or not</param>
    public string ReadString(Encoding encoding, bool removeStringTerminator = true)
    {
        int length = ReadInt32();
        return ReadString(encoding, length, removeStringTerminator);
    }

    /// <summary>
    /// Reads length-fixed string using the encoding specified on the serialization options
    /// </summary>
    /// <param name="removeStringTerminator">Indicates whether the string terminator (\0) should be removed or not</param>
    public string ReadString(bool removeStringTerminator = true)
    {
        return ReadString(SerializationOptions.Encoding, removeStringTerminator);
    }

    /// <summary>
    /// Reads length-fixed string using the encoding specified on the serialization options
    /// </summary>
    /// <param name="length">The string's length</param>
    public string ReadString(int length)
    {
        return ReadString(SerializationOptions.Encoding, length);
    }

    /// <summary>
    /// Resets the reading offset
    /// </summary>
    public void ResetOffset()
    {
        _binaryReader.BaseStream.Position = 0;
    }

    /// <summary>
    /// Sets the cursor to the current position + the specified number of bytes to skip
    /// </summary>
    /// <param name="count">Number of bytes to skip</param>
    public void Skip(int count)
    {
        _binaryReader.BaseStream.Position += count;
    }

    public byte[] ReadAllBytes()
    {
        if (_binaryReader.BaseStream is MemoryStream memoryStream)
        {
            return memoryStream.ToArray();
        }

        using var tempMemoryStream = new MemoryStream();
        _binaryReader.BaseStream.CopyTo(tempMemoryStream);
        return tempMemoryStream.ToArray();
    }

    public T Read<T>() where T : ISerializable, new()
    {
        var instance = new T();
        instance.Read(this);
        return instance;
    }

    public IList<T> ReadList<T>(int count) where T : ISerializable, new()
    {
        var list = new List<T>();

        for (var i = 0; i < count; i++)
        {
            var item = Read<T>();
            list.Add(item);
        }

        return list;
    }

    public IList<T> ReadList<T>() where T : ISerializable, new()
    {
        var count = ReadInt32();
        return ReadList<T>(count);
    }

    public void Dispose()
    {
        _binaryReader.Dispose();
    }
}
