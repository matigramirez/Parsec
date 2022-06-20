namespace Parsec.Shaiya.Core;

public interface IBinary
{
    /// <summary>
    /// Serializes the file into a byte array
    /// </summary>
    /// <param name="options">Extra options</param>
    IEnumerable<byte> GetBytes(params object[] options);
}
