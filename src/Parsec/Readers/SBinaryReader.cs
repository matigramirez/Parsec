using System.Text;
using Parsec.Extensions;

namespace Parsec.Readers;

/// <summary>
/// A binary reader made specifically to read Shaiya file formats
/// </summary>
public sealed class SBinaryReader
{
    /// <summary>
    /// The binary reader's data buffer
    /// </summary>
    public byte[] Buffer { get; }

    /// <summary>
    /// The binary reader's current reading position
    /// </summary>
    public int Offset { get; private set; }

    public SBinaryReader(string filePath)
    {
        using var binaryReader = new BinaryReader(File.OpenRead(filePath));
        Buffer = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
    }

    public SBinaryReader(byte[] buffer)
    {
        Buffer = buffer;
    }

    /// <summary>
    /// Reads a generic type from the byte buffer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>Read value</returns>
    /// <exception cref="NotSupportedException">When the provided type is not supported</exception>
    public T Read<T>()
    {
        var type = Type.GetTypeCode(typeof(T));

        object value = type switch
        {
            TypeCode.Byte    => ReadByte(),
            TypeCode.SByte   => ReadSByte(),
            TypeCode.Char    => ReadChar(),
            TypeCode.Boolean => ReadBoolean(),
            TypeCode.Int16   => ReadInt16(),
            TypeCode.UInt16  => ReadUInt16(),
            TypeCode.Int32   => ReadInt32(),
            TypeCode.UInt32  => ReadUInt32(),
            TypeCode.Int64   => ReadInt64(),
            TypeCode.UInt64  => ReadUInt64(),
            TypeCode.Single  => ReadFloat(),
            TypeCode.Double  => ReadDouble(),
            _                => throw new NotSupportedException()
        };

        return (T)value;
    }

    /// <summary>
    /// Reads a value from the byte buffer based on its <see cref="Type"/>
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of the value to be read</param>
    /// <returns>Read value as an object</returns>
    /// <exception cref="NotSupportedException">When the provided <see cref="Type"/> is not supported</exception>
    public object Read(Type type)
    {
        var typeCode = Type.GetTypeCode(type);

        object value = typeCode switch
        {
            TypeCode.Byte    => ReadByte(),
            TypeCode.SByte   => ReadSByte(),
            TypeCode.Char    => ReadChar(),
            TypeCode.Boolean => ReadBoolean(),
            TypeCode.Int16   => ReadInt16(),
            TypeCode.UInt16  => ReadUInt16(),
            TypeCode.Int32   => ReadInt32(),
            TypeCode.UInt32  => ReadUInt32(),
            TypeCode.Int64   => ReadInt64(),
            TypeCode.UInt64  => ReadUInt64(),
            TypeCode.Single  => ReadFloat(),
            TypeCode.Double  => ReadDouble(),
            _                => throw new NotSupportedException()
        };

        return value;
    }

    /// <summary>
    /// Reads a byte (unsigned)
    /// </summary>
    public byte ReadByte()
    {
        byte result = Buffer[Offset];
        Offset += sizeof(byte);
        return result;
    }

    /// <summary>
    /// Reads a signed byte (sbyte)
    /// </summary>
    public sbyte ReadSByte()
    {
        sbyte result = Convert.ToSByte(Buffer[Offset]);
        Offset += sizeof(sbyte);
        return result;
    }

    /// <summary>
    /// Reads a number of bytes
    /// </summary>
    /// <param name="count">Number of bytes to read</param>
    public byte[] ReadBytes(int count)
    {
        byte[] result = Buffer.SubArray(Offset, count);
        Offset += count;
        return result;
    }

    /// <summary>
    /// Reads a boolean value
    /// </summary>
    public bool ReadBoolean()
    {
        bool result = Convert.ToBoolean(Buffer[Offset]);
        Offset += sizeof(bool);
        return result;
    }

    /// <summary>
    /// Reads a char value
    /// </summary>
    public char ReadChar()
    {
        char result = Convert.ToChar(Buffer[Offset]);
        Offset += sizeof(char);
        return result;
    }

    /// <summary>
    /// Reads a signed short value (int16)
    /// </summary>
    public short ReadInt16()
    {
        short result = BitConverter.ToInt16(Buffer, Offset);
        Offset += sizeof(short);
        return result;
    }

    /// <summary>
    /// Reads an unsigned short value (uint16)
    /// </summary>
    public ushort ReadUInt16()
    {
        ushort result = BitConverter.ToUInt16(Buffer, Offset);
        Offset += sizeof(ushort);
        return result;
    }

    /// <summary>
    /// Reads a signed int value (int32)
    /// </summary>
    public int ReadInt32()
    {
        int result = BitConverter.ToInt32(Buffer, Offset);
        Offset += sizeof(int);
        return result;
    }

    /// <summary>
    /// Reads an unsigned int value (uint32)
    /// </summary>
    public uint ReadUInt32()
    {
        uint result = BitConverter.ToUInt32(Buffer, Offset);
        Offset += sizeof(uint);
        return result;
    }

    /// <summary>
    /// Reads a signed long (int64) value
    /// </summary>
    public long ReadInt64()
    {
        long result = BitConverter.ToInt64(Buffer, Offset);
        Offset += sizeof(long);
        return result;
    }

    /// <summary>
    /// Reads an unsigned long (uint64) value
    /// </summary>
    public ulong ReadUInt64()
    {
        ulong result = BitConverter.ToUInt64(Buffer, Offset);
        Offset += sizeof(ulong);
        return result;
    }

    /// <summary>
    /// Reads a float (single) value
    /// </summary>
    public float ReadFloat()
    {
        float result = BitConverter.ToSingle(Buffer, Offset);
        Offset += sizeof(float);
        return result;
    }

    /// <summary>
    /// Reads a double value
    /// </summary>
    public double ReadDouble()
    {
        double result = BitConverter.ToDouble(Buffer, Offset);
        Offset += sizeof(double);
        return result;
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
            return string.Empty;

        // If encoding is UTF16, length needs to be doubled, since UTF16 uses 2 bytes per character
        if (encoding.Equals(Encoding.Unicode))
            length *= 2;

        string str = encoding.GetString(Buffer, Offset, length);

        Offset += length;

        if (removeStringTerminator && str.Length > 1 && str[str.Length - 1] == '\0')
            str = str.Trim('\0');

        if (str == "\0")
            str = string.Empty;

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
    /// Reads length-fixed string with ASCII encoding
    /// </summary>
    /// <param name="removeStringTerminator">Indicates whether the string terminator (\0) should be removed or not</param>
    public string ReadString(bool removeStringTerminator = true) => ReadString(Encoding.ASCII, removeStringTerminator);

    /// <summary>
    /// Reads length-fixed string with ASCII encoding
    /// </summary>
    /// <param name="length">The string's length</param>
    public string ReadString(int length) => ReadString(Encoding.ASCII, length);

    /// <summary>
    /// Resets the reading offset
    /// </summary>
    public void ResetOffset() => Offset = 0;

    /// <summary>
    /// Sets the cursor to the current position + the specified number of bytes to skip
    /// </summary>
    /// <param name="count">Number of bytes to skip</param>
    public void Skip(int count) => Offset += count;
}
