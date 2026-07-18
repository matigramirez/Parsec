using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak.Physics;

/// <summary>
/// References a mesh by its table identifier and fixed-width filename.
/// </summary>
public sealed class PcMeshReference : ISerializable
{
    public const int FileNameBufferSize = 128;
    public const int SerializedSize = sizeof(int) + FileNameBufferSize;

    public int Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// Bytes from the first null terminator to the end of the 128-byte filename buffer.
    /// Keeping this tail allows buffers initialized with non-zero padding to round-trip exactly.
    /// When the filename is changed, an incompatible tail is replaced with null padding.
    /// </summary>
    public byte[] FileNamePadding { get; set; } = Array.Empty<byte>();

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt32();

        var buffer = binaryReader.ReadBytes(FileNameBufferSize);
        if (buffer.Length != FileNameBufferSize)
        {
            throw new EndOfStreamException("The .PC mesh filename buffer is truncated.");
        }

        var terminatorIndex = Array.IndexOf(buffer, (byte)0);
        if (terminatorIndex < 0)
        {
            terminatorIndex = FileNameBufferSize;
        }

        FileName = binaryReader.SerializationOptions.Encoding.GetString(buffer, 0, terminatorIndex);

        FileNamePadding = new byte[FileNameBufferSize - terminatorIndex];
        Buffer.BlockCopy(buffer, terminatorIndex, FileNamePadding, 0, FileNamePadding.Length);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        if (FileName.IndexOf('\0') >= 0)
        {
            throw new InvalidDataException("A .PC mesh filename cannot contain a null character.");
        }

        var fileNameBytes = binaryWriter.SerializationOptions.Encoding.GetBytes(FileName);
        if (fileNameBytes.Length > FileNameBufferSize)
        {
            throw new InvalidDataException($"A .PC mesh filename cannot exceed {FileNameBufferSize} bytes.");
        }

        binaryWriter.Write(Id);
        binaryWriter.Write(fileNameBytes);

        var remainingByteCount = FileNameBufferSize - fileNameBytes.Length;
        if (remainingByteCount == 0)
        {
            return;
        }

        if (FileNamePadding.Length == remainingByteCount && FileNamePadding[0] == 0)
        {
            binaryWriter.Write(FileNamePadding);
        }
        else
        {
            binaryWriter.Write(new byte[remainingByteCount]);
        }
    }
}
