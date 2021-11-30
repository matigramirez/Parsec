using Newtonsoft.Json;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD
{
    public class Wld : FileBase
    {
        /// <summary>
        /// "FLD" or "DUN" as char[4]
        /// </summary>
        public string Type { get; set; }

        #region FLD Only fields

        /// <summary>
        /// 1024 or 2048
        /// </summary>
        public int MapSize { get; set; }

        /// <summary>
        /// 0x0C0C03 bytes if mapSize is 1024, 0x301803 bytes if mapSize is 2048
        /// </summary>
        public byte[] MapHeight { get; set; }

        #endregion

        [JsonIgnore]
        public override string Extension => "wld";

        public override void Read()
        {
        }

        public override void Write(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
