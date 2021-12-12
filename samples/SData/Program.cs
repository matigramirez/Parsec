using System;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Cash;
using Parsec.Shaiya.DualLayerClothes;
using Parsec.Shaiya.GuildHouse;
using Parsec.Shaiya.KillStatus;
using Parsec.Shaiya.NpcQuest;
using Parsec.Shaiya.SData;
using Parsec.Shaiya.SetItem;
using static Parsec.Shaiya.Core.FileBase;
using Item = Parsec.Shaiya.Item.Item;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region NpcQuest

            var npcQuest = ReadFromFile<NpcQuest>("NpcQuest.EP5.SData", Format.EP5);

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

            var guildHouse = ReadFromFile<GuildHouse>("GuildHouse.SData");
            guildHouse.ExportJson("GuildHouse.json");

            #endregion

            #region Item

            var item = ReadFromFile<Item>("Item.SData");
            var encryptedBuffer = SData.Encrypt(item.Buffer);
            FileHelper.WriteFile("Item.SData.Encrypted", encryptedBuffer);

            #endregion

            #region Cash

            var cash = ReadFromFile<Cash>("Cash.SData");
            cash.ExportJson("Cash.json");

            #endregion

            #region KillStatus

            var killStatus = ReadFromFile<KillStatus>("KillStatus.SData");
            killStatus.ExportJson("KillStatus.json", enumFriendly: true);

            #endregion

            #region DualLayerClothes

            var dualLayerClothes = ReadFromFile<DualLayerClothes>("DualLayerClothes.SData");
            dualLayerClothes.ExportJson("DualLayerClothes.json");

            #endregion

            #region SetItem

            var setItem = ReadFromFile<SetItem>("SetItem.SData");
            setItem.ExportJson("SetItem.json");

            #endregion
        }
    }
}
