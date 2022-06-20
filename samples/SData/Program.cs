using System;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Cash;
using Parsec.Shaiya.DualLayerClothes;
using Parsec.Shaiya.GuildHouse;
using Parsec.Shaiya.KillStatus;
using Parsec.Shaiya.Monster;
using Parsec.Shaiya.NpcQuest;
using Parsec.Shaiya.SData;
using Parsec.Shaiya.SetItem;
using Item = Parsec.Shaiya.Item.Item;

namespace Parsec.Samples;

class Program
{
    static void Main(string[] args)
    {
        #region NpcQuest

        var npcQuest = Reader.ReadFromFile<NpcQuest>("NpcQuest.EP5.SData", Episode.EP5);

        Console.WriteLine($"Merchant Count (EP 5): {npcQuest.Merchants.Count}");
        Console.WriteLine($"GateKeeper Count (EP 5): {npcQuest.Gatekeepers.Count}");
        Console.WriteLine($"Quest Count (EP 5): {npcQuest.Quests.Count}");
        npcQuest.ExportJson("NpcQuest.EP5.json");

        var encryptedBytes = SData.Encrypt(npcQuest.Buffer);
        FileHelper.WriteFile("NpcQuest.EP5.SData.Encrypted", encryptedBytes);

        var decryptedBytes = SData.Decrypt(npcQuest.Buffer);
        FileHelper.WriteFile("NpcQuest.EP5.SData.Decrypted", decryptedBytes);

        npcQuest = Reader.ReadFromFile<NpcQuest>("NpcQuest.EP8.SData", Episode.EP8);

        Console.WriteLine($"Merchant Count (EP 8): {npcQuest.Merchants.Count}");
        Console.WriteLine($"GateKeeper Count (EP 8): {npcQuest.Gatekeepers.Count}");
        Console.WriteLine($"Quest Count (EP 8): {npcQuest.Quests.Count}");
        npcQuest.ExportJson("NpcQuest.EP8.json");

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

        #region Monster

        var monster = Reader.ReadFromFile<Monster>("Monster.SData");
        monster.WriteDecrypted("Monster.dec.SData");
        monster.ExportCSV("Monster.csv");

        #endregion
    }
}
