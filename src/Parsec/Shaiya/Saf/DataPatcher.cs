using System;
using System.IO;
using System.Linq;

namespace Parsec.Shaiya
{
    public class DataPatcher : IDisposable
    {
        /// <summary>
        /// The sah instance to be written
        /// </summary>
        private readonly Sah _sah;

        /// <summary>
        /// The update sah file to be merged
        /// </summary>
        private readonly Sah _patchSah;

        /// <summary>
        /// The binary reader instance that reads the patch saf file
        /// </summary>
        private BinaryReader _patchSafReader;

        /// <summary>
        /// The binary writer instance that writes to the saf file
        /// </summary>
        private BinaryWriter _dataSafWriter;

        public DataPatcher(Sah sah, Sah patch)
        {
            _sah = sah;
            _patchSah = patch;
        }

        /// <summary>
        /// Applies the patch sah to the data sah file.
        /// </summary>
        public void ApplyPatch()
        {
            _patchSafReader = new BinaryReader(File.OpenRead(_patchSah.SafPath));
            _dataSafWriter = new BinaryWriter(File.OpenWrite(_sah.SafPath));

            // Run the patching function
            PatchFiles();

            _patchSafReader?.Dispose();
            _dataSafWriter?.Dispose();
        }

        private void PatchFiles()
        {
            var patchFiles = _patchSah.FileIndex.Values.ToList();

            foreach (var patchFile in patchFiles)
            {
                // Check if file already exists. If it does, it needs to be replaced.
                if (_sah.FileIndex.TryGetValue(patchFile.RelativePath, out var originalFile))
                {
                    // Clear original file bytes
                    ClearBytes(originalFile.Offset, originalFile.Length);

                    // Check if original file bytes can be replaced
                    if (patchFile.Length <= originalFile.Length)
                    {
                        // Write new file at original file's offset
                        WriteFile(patchFile, originalFile.Offset);
                    }
                    else
                    {
                        // If file's size is bigger than the original file's size, append it at the end of the saf
                        AppendFile(patchFile);
                    }

                    // Replace length and offset of the file (since it's been replaced but its name is the same)
                    originalFile.Length = patchFile.Length;
                    originalFile.Offset = patchFile.Offset;
                }
                else
                {
                    // Append file at the end of the saf
                    AppendFile(patchFile);

                    // Get folder path from file path
                    var folderPath = patchFile.RelativePath.Substring(0, patchFile.RelativePath.Length - patchFile.Name.Length - 1);

                    // If folder didn't exist before, it needs to be created
                    var folder = _sah.EnsureFolderExists(folderPath);

                    folder?.Files.Add(patchFile);
                }
            }
        }

        /// <summary>
        /// Makes "0" a specific amount of bytes starting from offset through offset+length
        /// </summary>
        /// <param name="offset">Starting offset</param>
        /// <param name="length">Length</param>
        private void ClearBytes(long offset, int length)
        {
            // Set safWriter position to offset
            _dataSafWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

            // Create empty array of "length" bytes
            var bytes = new byte[length];

            _dataSafWriter.Write(bytes);
        }

        /// <summary>
        /// Writes a file at a specified offset
        /// </summary>
        /// <param name="file"></param>
        /// <param name="offset"></param>
        private void WriteFile(ShaiyaFile file, long offset)
        {
            // Set safWriter position to end of file
            _dataSafWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

            // Read file bytes
            var fileBytes = GetFileBytes(file);

            // Set file offset - shouldn't really be necessary but I'll leave it here for consistency
            file.Offset = _dataSafWriter.BaseStream.Position;

            // Store file at the offset
            _dataSafWriter.Write(fileBytes);
        }

        /// <summary>
        /// Appends a file to the end of the saf file and sets its offset field
        /// </summary>
        /// <param name="patchFile">The file to write</param>
        private void AppendFile(ShaiyaFile patchFile)
        {
            // Set safWriter position to end of file
            _dataSafWriter.BaseStream.Seek(0, SeekOrigin.End);

            // Read file bytes
            var fileBytes = GetFileBytes(patchFile);

            // Set file offset to end of saf
            patchFile.Offset = _dataSafWriter.BaseStream.Position;

            // Store file at the end of the saf file
            _dataSafWriter.Write(fileBytes);
        }

        /// <summary>
        /// Gets a file bytes from a saf file
        /// </summary>
        private byte[] GetFileBytes(ShaiyaFile file)
        {
            // Set offset to file's starting offset
            _patchSafReader.BaseStream.Seek(file.Offset, SeekOrigin.Begin);

            // Read file bytes (length bytes)
            var bytes = _patchSafReader.ReadBytes(file.Length);

            return bytes;
        }

        public void Dispose()
        {
            _patchSafReader?.Dispose();
            _dataSafWriter?.Dispose();
        }
    }
}
