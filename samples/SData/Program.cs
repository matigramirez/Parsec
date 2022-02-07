using System;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Readers;
using Parsec.Shaiya.Cash;
using Parsec.Shaiya.DualLayerClothes;
using Parsec.Shaiya.GuildHouse;
using Parsec.Shaiya.KillStatus;
using Parsec.Shaiya.NpcQuest;
using Parsec.Shaiya.SData;
using Parsec.Shaiya.SetItem;
using Item = Parsec.Shaiya.Item.Item;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region NpcQuest

            var npcQuest = Reader.ReadFromFile<NpcQuest>("NpcQuest.EP5.SData", Format.EP5);

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

            var guildHouse = Reader.ReadFromFile<GuildHouse>("GuildHouse.SData");
            guildHouse.ExportJson("GuildHouse.json");

            #endregion

            #region Item

            var item = Reader.ReadFromFile<Item>("Item.SData");
            item.WriteEncrypted("Item.encrypted.SData");

            // Export as csv
            item.ExportCSV("Item.csv");

            #endregion

            #region Cash

            var cash = Reader.ReadFromFile<Cash>("Cash.SData");
            cash.ExportJson("Cash.json");

            #endregion

            #region KillStatus

            var killStatus = Reader.ReadFromFile<KillStatus>("KillStatus.SData");
            killStatus.ExportJson("KillStatus.json");

            #endregion

            #region DualLayerClothes

            var dualLayerClothes = Reader.ReadFromFile<DualLayerClothes>("DualLayerClothes.SData");
            dualLayerClothes.ExportJson("DualLayerClothes.json");

            #endregion

            #region SetItem

            var setItem = Reader.ReadFromFile<SetItem>("SetItem.SData");
            setItem.ExportJson("SetItem.json");

            #endregion
        }
    }
}
