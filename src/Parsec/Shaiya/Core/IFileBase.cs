namespace Parsec.Shaiya.Core
{
    public interface IFileBase : IBinary
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
    }
}
