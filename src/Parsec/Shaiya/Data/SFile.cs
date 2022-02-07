using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Data
{
    [DataContract]
    public class SFile : IBinary
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
        public SFolder ParentFolder;

        [JsonConstructor]
        public SFile()
        {
        }

        public SFile(SFolder parentFolder)
        {
            ParentFolder = parentFolder;
        }

        public SFile(string name, long offset, int length, SFolder folder) : this(folder)
        {
            Name = name;
            Offset = offset;
            Length = length;
            Version = 0;
        }

        public SFile(SBinaryReader binaryReader, SFolder folder, Dictionary<string, SFile> fileIndex) : this(folder)
        {
            Name = binaryReader.ReadString();
            Offset = binaryReader.Read<long>();
            Length = binaryReader.Read<int>();
            Version = binaryReader.Read<int>();

            // Write folder's relative path based on parent folder
            RelativePath = ParentFolder == null || ParentFolder.Name == ""
                ? Name
                : string.Join("/", folder.RelativePath, Name);

            // Add file to the sah's file dictionary
            if (!fileIndex.ContainsKey(RelativePath))
                fileIndex.Add(RelativePath, this);
            else
                // Follow castor's _pv file name ending for duplicate files
                fileIndex.Add(RelativePath + "_pv", this);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Name.GetBytes());
            buffer.AddRange(Offset.GetBytes());
            buffer.AddRange(Length.GetBytes());
            buffer.AddRange(Version.GetBytes());
            return buffer.ToArray();
        }
    }
}
