namespace Parsec.Shaiya.Core
{
    public interface IFileBase
    {
        /// <summary>
        /// Reads and parses the file
        /// </summary>
        void Read();

        /// <summary>
        /// Writes the file to its original format
        /// </summary>
        void Write(string path);
    }
}
