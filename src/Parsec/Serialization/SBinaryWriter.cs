using System.Text;
using Parsec.Shaiya.Core;

namespace Parsec.Serialization;

public class SBinaryWriter : IDisposable
{
    private readonly BinaryWriter _binaryWriter;
    public readonly BinarySerializationOptions SerializationOptions;

    public SBinaryWriter(Stream stream, BinarySerializationOptions serializationOptions)
    {
        _binaryWriter = new BinaryWriter(stream);
        SerializationOptions = serializationOptions;
    }

    public SBinaryWriter(FileStream fileStream, BinarySerializationOptions serializationOptions) : this((Stream)fileStream, serializationOptions)
    {
    }

    public SBinaryWriter(MemoryStream memoryStream, BinarySerializationOptions serializationOptions) : this((Stream)memoryStream, serializationOptions)
    {
    }

    public SBinaryWriter(string filePath, BinarySerializationOptions serializationOptions)
    {
        var fileStream = File.OpenWrite(filePath);
        _binaryWriter = new BinaryWriter(fileStream);
        SerializationOptions = serializationOptions;
    }

    public void Write(byte value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(sbyte value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(bool value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(short value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(ushort value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(int value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(uint value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(long value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(ulong value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(float value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(double value)
    {
        _binaryWriter.Write(value);
    }

    public void Write(byte[] bytes)
    {
        _binaryWriter.Write(bytes);
    }

    public void Write(string str, bool isLengthPrefixed = true, bool includeStringTerminator = true)
    {
        Write(str, SerializationOptions.Encoding, isLengthPrefixed, includeStringTerminator);
    }

    public void Write(string str, Encoding encoding, bool isLengthPrefixed = true, bool includeStringTerminator = true)
    {
        var finalStr = includeStringTerminator ? str + '\0' : str;

        if (isLengthPrefixed)
        {
            Write(finalStr.Length);
        }

        Write(encoding.GetBytes(finalStr));
    }

    public void Write(ISerializable serializable)
    {
        serializable.Write(this);
    }

    public void Write(IList<ISerializable> list, bool lengthPrefixed = true)
    {
        if (lengthPrefixed)
        {
            Write(list.Count);
        }

        foreach (var item in list)
        {
            Write(item);
        }
    }

    public void Dispose()
    {
        _binaryWriter.Dispose();
    }
}
