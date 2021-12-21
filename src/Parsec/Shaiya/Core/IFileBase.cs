namespace Parsec.Shaiya.Core
{
    public interface IFileBase
    {
        /// <summary>
        /// Reads and parses the file
        /// </summary>
        /// <param name="options">Reading options</param>
        void Read(params object[] options);

        /// <summary>
        /// Writes the file to its original format
        /// </summary>
        /// <param name="path">Path where to write the file</param>
        /// <param name="options">Extra options</param>
        void Write(string path, params object[] options);

        /// <summary>
        /// Serializes the file into a byte array
        /// </summary>
        /// <param name="options">Extra options</param>
        byte[] GetBytes(params object[] options);
    }
}
