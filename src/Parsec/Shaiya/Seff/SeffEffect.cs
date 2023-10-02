using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Seff;

public sealed class SeffEffect
{
    [JsonConstructor]
    public SeffEffect()
    {
    }

    public SeffEffect(SBinaryReader binaryReader, int format)
    {
        ParticleCount = binaryReader.Read<uint>();
        ParticleVelocity = binaryReader.Read<float>();
        TextureBlendMode = binaryReader.Read<uint>();
        StartPositionMultiplier = binaryReader.Read<uint>();
        ParticleLifetime = binaryReader.Read<uint>();
        Unknown6 = binaryReader.Read<float>();
        TextureFileName = binaryReader.ReadString(Encoding.Unicode);
        Red = binaryReader.Read<byte>();
        Green = binaryReader.Read<byte>();
        Blue = binaryReader.Read<byte>();
        ParticleStartPosition = new Vector3(binaryReader);
        Unknown10 = binaryReader.Read<float>();
        ParticleStartSize = binaryReader.Read<float>();
        IsVisible = binaryReader.Read<bool>();

        Unknown12 = binaryReader.Read<float>();

        if (format > 2)
            RotateWithStretchMultiplier = binaryReader.Read<float>();

        if (format > 3)
            VelocityMultiplier = binaryReader.Read<float>();

        if (format > 5)
            Unknown15 = binaryReader.Read<uint>();
    }

    public uint ParticleCount { get; set; }
    public float ParticleVelocity { get; set; }
    /// <summary>
    /// Supported values are 0-3. 0 appears to be Normal. To-do: enumeration.
    /// https://en.wikipedia.org/wiki/Blend_modes
    /// </summary>
    public uint TextureBlendMode { get; set; }
    /// <summary>
    /// Supported values are 0-9.
    /// </summary>
    public uint StartPositionMultiplier { get; set; }
    /// <summary>
    /// Milliseconds
    /// </summary>
    public uint ParticleLifetime { get; set; }
    public float Unknown6 { get; set; }
    public string TextureFileName { get; set; } = string.Empty;
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }
    public Vector3 ParticleStartPosition { get; set; }
    public float Unknown10 { get; set; }
    public float ParticleStartSize { get; set; }
    public bool IsVisible { get; set; }
    public float Unknown12 { get; set; }
    public float RotateWithStretchMultiplier { get; set; }
    public float VelocityMultiplier { get; set; }
    public uint Unknown15 { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        int format = 0;

        if (options.Length > 0)
            format = (int)options[0];

        var buffer = new List<byte>();

        buffer.AddRange(ParticleCount.GetBytes());
        buffer.AddRange(ParticleVelocity.GetBytes());
        buffer.AddRange(TextureBlendMode.GetBytes());
        buffer.AddRange(StartPositionMultiplier.GetBytes());
        buffer.AddRange(ParticleLifetime.GetBytes());
        buffer.AddRange(Unknown6.GetBytes());

        buffer.AddRange(TextureFileName.GetLengthPrefixedBytes(Encoding.Unicode, false));

        buffer.Add(Red);
        buffer.Add(Green);
        buffer.Add(Blue);

        buffer.AddRange(ParticleStartPosition.GetBytes());
        buffer.AddRange(Unknown10.GetBytes());
        buffer.AddRange(ParticleStartSize.GetBytes());

        buffer.Add(Convert.ToByte(IsVisible));

        buffer.AddRange(Unknown12.GetBytes());

        if (format > 2)
            buffer.AddRange(RotateWithStretchMultiplier.GetBytes());

        if (format > 3)
            buffer.AddRange(VelocityMultiplier.GetBytes());

        if (format > 5)
            buffer.AddRange(Unknown15.GetBytes());

        return buffer;
    }
}
