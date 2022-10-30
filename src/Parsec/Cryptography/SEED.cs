namespace Parsec.Cryptography;

/// <summary>
/// Class that implements the methods needed to encrypt and decrypt files which use the KISA SEED encryption algorithm.
/// For more information visit <a href="https://en.wikipedia.org/wiki/SEED">this link</a>.
/// </summary>
public static class Seed
{
    private static uint GetSeed(uint val)
    {
        return SeedConstants.SS[0, (byte)val] ^
               SeedConstants.SS[1, (byte)(val >> 8)] ^
               SeedConstants.SS[2, (byte)(val >> 16)] ^
               SeedConstants.SS[3, (byte)(val >> 24)];
    }

    public static uint ByteArrayToUInt32(byte[] array, uint offset)
    {
        uint value = ((uint)array[offset] << 24) | ((uint)array[offset + 1] << 16) | ((uint)array[offset + 2] << 8) | array[offset + 3];

        return value;
    }

    private static void UInt32ToByteArray(uint input, byte[] output, uint offset)
    {
        output[offset] = (byte)(input >> 24);
        output[offset + 1] = (byte)(input >> 16);
        output[offset + 2] = (byte)(input >> 8);
        output[offset + 3] = (byte)input;
    }

    private static uint LeftRotation(uint x, int n)
    {
        uint x1 = x << n;
        uint x2 = x >> (32 - n);
        return x1 | x2;
    }

    public static void EndiannessSwap(ref uint value)
    {
        uint value1 = LeftRotation(value, 8) & 0x00ff00ff;
        uint value2 = LeftRotation(value, 24) & 0xff00ff00;
        value = value1 | value2;
    }

    private static void SeedRound(ref uint L0, ref uint L1, uint R0, uint R1, byte[] K, uint offset)
    {
        uint K0 = ByteArrayToUInt32(K, offset * 4 + 0);
        uint K1 = ByteArrayToUInt32(K, (offset + 1) * 4);

        EndiannessSwap(ref K0);
        EndiannessSwap(ref K1);

        uint T0 = R0 ^ K0;
        uint T1 = R1 ^ K1;
        T1 ^= T0;
        T1 = GetSeed(T1);
        T0 += T1;
        T0 = GetSeed(T0);
        T1 += T0;
        T1 = GetSeed(T1);
        T0 += T1;
        L0 ^= T0;
        L1 ^= T1;
    }

    public static void DecryptChunk(byte[] input, out byte[] output)
    {
        uint L0 = ByteArrayToUInt32(input, 0);
        uint L1 = ByteArrayToUInt32(input, 4);
        uint R0 = ByteArrayToUInt32(input, 8);
        uint R1 = ByteArrayToUInt32(input, 12);
        byte[] roundKey = SeedConstants.Key;

        output = new byte[input.Length];

        SeedRound(ref L0, ref L1, R0, R1, roundKey, 30);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 28);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 26);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 24);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 22);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 20);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 18);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 16);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 14);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 12);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 10);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 8);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 6);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 4);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 2);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 0);

        UInt32ToByteArray(R0, output, 0);
        UInt32ToByteArray(R1, output, 4);
        UInt32ToByteArray(L0, output, 8);
        UInt32ToByteArray(L1, output, 12);
    }

    public static void EncryptChunk(byte[] input, out byte[] output)
    {
        uint L0 = ByteArrayToUInt32(input, 0);
        uint L1 = ByteArrayToUInt32(input, 4);
        uint R0 = ByteArrayToUInt32(input, 8);
        uint R1 = ByteArrayToUInt32(input, 12);
        byte[] roundKey = SeedConstants.Key;

        output = new byte[input.Length];

        SeedRound(ref L0, ref L1, R0, R1, roundKey, 0);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 2);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 4);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 6);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 8);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 10);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 12);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 14);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 16);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 18);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 20);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 22);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 24);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 26);
        SeedRound(ref L0, ref L1, R0, R1, roundKey, 28);
        SeedRound(ref R0, ref R1, L0, L1, roundKey, 30);

        UInt32ToByteArray(R0, output, 0);
        UInt32ToByteArray(R1, output, 4);
        UInt32ToByteArray(L0, output, 8);
        UInt32ToByteArray(L1, output, 12);
    }
}
