using System.Runtime.InteropServices;

namespace Parsec.External
{
    public static class ShaiyaCrypt
    {
        [DllImport("cryptography.dll")]
        public static extern uint encrypt(byte[] fdata, uint fsize);

        [DllImport("cryptography.dll")]
        public static extern uint decrypt(byte[] fdata, uint fsize);
    }
}
