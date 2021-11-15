using System;
using Parsec.Shaiya;
using Parsec.Shaiya.GUILDHOUSE;
using Parsec.Shaiya.NPCQUEST;

namespace Parsec.Sample.SData
{
    class Program
    {
        static void Main(string[] args)
        {
            var npcQuest = new NpcQuest("NpcQuest.SData");

            npcQuest.ExportDecrypted("NpcQuest.decrypted.SData");
            npcQuest.ExportEncrypted("NpcQuest.encrypted.SData");

            npcQuest.Read();

            Console.WriteLine($"Merchant Count: {npcQuest.Merchants.Count}");
            Console.WriteLine($"GateKeeper Count: {npcQuest.GateKeepers.Count}");
            npcQuest.ExportJson("NpcQuest.json");

            var guildHouse = new GuildHouse("GuildHouse.SData");
            guildHouse.Read();
            guildHouse.ExportJson("GuildHouse.json");
        }
    }
}
