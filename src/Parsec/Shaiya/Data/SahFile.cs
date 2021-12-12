using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Data
{
    [DataContract]
    public class SahFile : IBinary
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        [DataMember]
        public string Name;

        /// <summary>
        /// The offset in data.saf where the file is located
        /// </summary>
        [DataMember]
        public long Offset;

        /// <summary>
        /// The length of the file in kbs
        /// </summary>
        [DataMember]
        public int Length;

        /// <summary>
        /// The file version -- not used by the game so this value doesn't really matter
        /// </summary>
        [DataMember]
        public int Version;

        /// <summary>
        /// The relative path to the file
        /// </summary>
        public string RelativePath;

        /// <summary>
        /// The directory in which the file is
        /// </summary>
        public SahFolder ParentFolder;

        [JsonConstructor]
        public SahFile()
        {
        }

        public SahFile(SahFolder parentFolder)
        {
            ParentFolder = parentFolder;
        }

        public SahFile(ShaiyaBinaryReader binaryReader, SahFolder folder, Dictionary<string, SahFile> fileIndex) : this(folder)
        {
            Name = binaryReader.ReadString();
            Offset = binaryReader.Read<long>();
            Length = binaryReader.Read<int>();
            Version = binaryReader.Read<int>();

            // Write folder's relative path based on parent folder
            RelativePath = ParentFolder == null ? Name : System.IO.Path.Combine(folder.RelativePath, Name);

            // Add file to the sah's file dictionary
            if (!fileIndex.ContainsKey(RelativePath))
                fileIndex.Add(RelativePath, this);
            else
                // Follow castor's _pv file name ending for duplicate files
                fileIndex.Add(RelativePath + "_pv", this);
        }

        public SahFile(string name, long offset, int length, SahFolder folder) : this(folder)
        {
            Name = name;
            Offset = offset;
            Length = length;
            Version = 0;
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            // Write file name length including string null terminator
            buffer.AddRange(BitConverter.GetBytes(Name.Length + 1));

            // Write file name including string null terminator
            buffer.AddRange(Encoding.ASCII.GetBytes(Name + '\0'));

            // Write file offset
            buffer.AddRange(BitConverter.GetBytes(Offset));

            // Write file length
            buffer.AddRange(BitConverter.GetBytes(Length));

            // Write file version
            buffer.AddRange(BitConverter.GetBytes(Version));

            return buffer.ToArray();
        }
    }
}
