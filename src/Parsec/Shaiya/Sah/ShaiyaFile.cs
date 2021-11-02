namespace Parsec.Shaiya.SAH
{
    public class ShaiyaFile
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name;

        /// <summary>
        /// The offset in data.saf where the file is located
        /// </summary>
        public long Offset;

        /// <summary>
        /// The length of the file in kbs
        /// </summary>
        public int Length;

        /// <summary>
        /// The file version -- not used by the game so this value doesn't really matter
        /// </summary>
        public int Version;

        /// <summary>
        /// The relative path to the file
        /// </summary>
        public string RelativePath;

        /// <summary>
        /// The directory in which the file is
        /// </summary>
        public ShaiyaFolder ParentFolder;

        public ShaiyaFile(ShaiyaFolder parentFolder)
        {
            ParentFolder = parentFolder;
        }

        public ShaiyaFile(string name, long offset, int length, ShaiyaFolder folder) : this(folder)
        {
            Name = name;
            Offset = offset;
            Length = length;
            Version = 0;
        }
    }
}
