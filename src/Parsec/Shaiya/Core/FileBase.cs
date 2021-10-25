using Parsec.Helpers;
using Parsec.Readers;

namespace Parsec.Shaiya.Core
{
    public abstract class FileBase : IFileBase
    {
        protected readonly ShaiyaBinaryReader _binaryReader;

        protected byte[] Buffer => _binaryReader.Buffer;

        public string Path { get; set; }

        public FileBase(string path)
        {
            Path = path;
            _binaryReader = new ShaiyaBinaryReader(path);
        }

        public abstract void Read();

        protected void ResetCursor() =>
            _binaryReader.SetPosition(0);
    }
}
