using Parsec.Shaiya.Core;

namespace Parsec.Readers
{
    public static class Reader
    {
        /// <summary>
        /// Reads the shaiya file format from a file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="options">Array of reading options</param>
        /// <typeparam name="T">Shaiya File Format Type</typeparam>
        /// <returns>T instance</returns>
        public static T ReadFromFile<T>(string path, params object[] options) where T : FileBase, new() => FileBase.ReadFromFile<T>(path, options);

        /// <summary>
        /// Reads the shaiya file format from a buffer (byte array)
        /// </summary>
        /// <param name="name">File name</param>
        /// <param name="buffer">File buffer</param>
        /// <param name="options">Array of reading options</param>
        /// <typeparam name="T">Shaiya File Format Type</typeparam>
        /// <returns>T instance</returns>
        public static T ReadFromBuffer<T>(string name, byte[] buffer, params object[] options) where T : FileBase, new() => FileBase.ReadFromBuffer<T>(name, buffer, options);
    }
}
