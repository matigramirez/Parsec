using System;
using Parsec.Shaiya;

namespace Parsec.Sample.SData
{
    class Program
    {
        static void Main(string[] args)
        {
            var npcQuest = new NpcQuest("NpcQuest.SData");

            npcQuest.SaveDecrypted("NpcQuest.decrypted.SData");
            npcQuest.SaveEncrypted("NpcQuest.encrypted.SData");

            npcQuest.Read();

            // foreach (var merchant in npcQuest.Merchants)
            // {
            //     Console.WriteLine(merchant.Name);
            // }

            foreach (var gatekeeper in npcQuest.GateKeepers)
            {
                Console.WriteLine(gatekeeper.Name);
            }
        }
    }
}
