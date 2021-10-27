using Parsec.Shaiya.KILLSTATUS;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var killStatus = new KillStatus("KillStatus.SData");
            killStatus.Read();
            killStatus.Export("KillStatus.json", enumFriendly: true);
        }
    }
}
