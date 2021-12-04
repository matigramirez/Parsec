using System;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.GUILDHOUSE;
using Parsec.Shaiya.Item;
using Parsec.Shaiya.NPCQUEST;
using Parsec.Shaiya.SDATA;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region NpcQuest

            var npcQuest = new NpcQuest("NpcQuest.EP5.SData", Format.EP5);
            npcQuest.Read();

            Console.WriteLine($"Merchant Count: {npcQuest.Merchants.Count}");
            Console.WriteLine($"GateKeeper Count: {npcQuest.Gatekeepers.Count}");
            Console.WriteLine($"Quest Count: {npcQuest.Quests.Count}");
            npcQuest.ExportJson("NpcQuest.json");

            var encryptedBytes = SData.Encrypt(npcQuest.Buffer);
            FileHelper.WriteFile("NpcQuest.SData.Encrypted", encryptedBytes);

            var decryptedBytes = SData.Decrypt(npcQuest.Buffer);
            FileHelper.WriteFile("NpcQuest.SData.Decrypted", decryptedBytes);

            #endregion

            #region GuildHouse

            var guildHouse = new GuildHouse("GuildHouse.SData");
            guildHouse.Read();
            guildHouse.ExportJson("GuildHouse.json");

            #endregion

            #region Item

            var item = new Item("Item.SData");
            item.Read();
            var encryptedBuffer = SData.Encrypt(item.Buffer);
            FileHelper.WriteFile("Item.SData.Encrypted", encryptedBuffer);

            #endregion
        }
    }
}
