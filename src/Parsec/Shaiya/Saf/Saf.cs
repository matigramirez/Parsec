using Parsec.Shaiya.SAH;

namespace Parsec.Shaiya.SAF
{
    public partial class Saf
    {
        /// <summary>
        /// The sah file that corresponds to this saf
        /// </summary>
        private Sah _sah;

        public Saf(Sah sah)
        {
            _sah = sah;
        }
    }
}
