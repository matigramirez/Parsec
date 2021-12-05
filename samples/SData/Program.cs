using System;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.CASH;
using Parsec.Shaiya.DUALLAYERCLOTHES;
using Parsec.Shaiya.GUILDHOUSE;
using Parsec.Shaiya.KILLSTATUS;
using Parsec.Shaiya.NPCQUEST;
using Parsec.Shaiya.SDATA;
using Parsec.Shaiya.SETITEM;
using Item = Parsec.Shaiya.Item.Item;

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

            #region Cash

            var cash = new Cash("Cash.SData");
            cash.Read();
            cash.ExportJson("Cash.json");

            #endregion

            #region KillStatus

            var killStatus = new KillStatus("KillStatus.SData");
            killStatus.Read();
            killStatus.ExportJson("KillStatus.json", enumFriendly: true);

            #endregion

            #region DualLayerClothes

            var dualLayerClothes = new DualLayerClothes("DualLayerClothes.SData");
            dualLayerClothes.Read();
            dualLayerClothes.ExportJson("DualLayerClothes.json");

            #endregion

            #region SetItem

            var setItem = new SetItem("SetItem.SData");
            setItem.Read();
            setItem.ExportJson("SetItem.json");

            #endregion
        }
    }
}
