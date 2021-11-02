using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Parsec.Helpers;

namespace Parsec.Shaiya.SAH
{
    public partial class Sah
    {
        /// <summary>
        /// Saves a parsed sah file into a new file.
        /// </summary>
        /// <param name="path">Path of the file to save, including file name.</param>
        public void SaveFile(string path)
        {
            // Create byte list which will have the sah's data
            var buffer = new List<byte>();

            // Write sah signature
            buffer.AddRange(Encoding.ASCII.GetBytes("SAH"));

            // Write 4 unknown 0x00 bytes
            buffer.AddRange(new byte[4]);

            // Write total file count
            buffer.AddRange(BitConverter.GetBytes(TotalFileCount));

            // Write padding
            buffer.AddRange(new byte[40]);

            // Write root folder and all subfolders with files
            WriteFolder(RootFolder, buffer);

            // Write last 8 empty bytes
            buffer.AddRange(new byte[8]);

            // Make List<byte> an array
            byte[] bufferByteArray = buffer.ToArray();

            // Create new file and write buffer
            FileHelper.WriteFile(path, bufferByteArray);
        }

        /// <summary>
        /// Writes a folder with all its files and subfolders into a buffer.
        /// </summary>
        /// <param name="folder">Folder to write.</param>
        /// <param name="buffer">Buffer where the folder should be written.</param>
        private void WriteFolder(ShaiyaFolder folder, List<byte> buffer)
        {
            // Write folder name length + 1 for string null terminator
            int folderNameLength = string.IsNullOrEmpty(folder.Name) ? 1 : folder.Name.Length + 1;
            buffer.AddRange(BitConverter.GetBytes(folderNameLength));

            // Write folder name including string null terminator
            buffer.AddRange(Encoding.ASCII.GetBytes(folder.Name + '\0'));

            // Write file count
            buffer.AddRange(BitConverter.GetBytes(folder.Files.Count));

            // Write files
            foreach (var file in folder.Files)
            {
                WriteFile(file, buffer);
            }

            // Write subfolder count
            buffer.AddRange(BitConverter.GetBytes(folder.Subfolders.Count));

            // Recursively write subfolders
            foreach (var subfolder in folder.Subfolders)
            {
                WriteFolder(subfolder, buffer);
            }
        }

        /// <summary>
        /// Writes a file bytes into a buffer.
        /// </summary>
        /// <param name="file">File to write.</param>
        /// <param name="buffer">Buffer where file should be written.</param>
        private void WriteFile(ShaiyaFile file, List<byte> buffer)
        {
            // Write file name length including string null terminator
            buffer.AddRange(BitConverter.GetBytes(file.Name.Length + 1));

            // Write file name including string null terminator
            buffer.AddRange(Encoding.ASCII.GetBytes(file.Name + '\0'));

            // Write file offset
            buffer.AddRange(BitConverter.GetBytes(file.Offset));

            // Write file length
            buffer.AddRange(BitConverter.GetBytes(file.Length));

            // Write file version
            buffer.AddRange(BitConverter.GetBytes(file.Version));
        }
    }
}
