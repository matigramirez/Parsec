using System;
using Parsec;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Cash;
using Parsec.Shaiya.DualLayerClothes;
using Parsec.Shaiya.GuildHouse;
using Parsec.Shaiya.Item;
using Parsec.Shaiya.KillStatus;
using Parsec.Shaiya.Monster;
using Parsec.Shaiya.NpcQuest;
using Parsec.Shaiya.NpcSkill;
using Parsec.Shaiya.SetItem;
using Parsec.Shaiya.Skill;
using Item = Parsec.Shaiya.Item.Item;

namespace Sample.SData;

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

        var encryptedBytes = Parsec.Shaiya.SData.SData.Encrypt(npcQuest.Buffer);
        FileHelper.WriteFile("NpcQuest.EP5.SData.Encrypted", encryptedBytes);

        var decryptedBytes = Parsec.Shaiya.SData.SData.Decrypt(npcQuest.Buffer);
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

        var item = Reader.ReadFromFile<Item>("ItemEP6.SData", Episode.EP6);
        item.WriteEncrypted("Item.encrypted.SData", Episode.EP6);

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

        #region BinarySData

        var itemSell = Reader.ReadFromFile<DBItemSellData>("DBItemSellData.SData");
        itemSell.ExportJson($"{itemSell.FileName}.json");
        itemSell.Write($"{itemSell.FileNameWithoutExtension}_Created.SData");

        var itemData = Reader.ReadFromFile<DBItemData>("DBItemData.SData");
        itemData.ExportJson($"{itemData.FileName}.json");
        itemData.Write($"{itemData.FileNameWithoutExtension}_Created.SData");

        var monsterData = Reader.ReadFromFile<DBMonsterData>("DBMonsterData.SData");
        monster.ExportJson($"{monsterData.FileName}.json");
        monster.Write($"{monsterData.FileNameWithoutExtension}_Created.SData");

        var skill = Reader.ReadFromFile<DBSkillData>("DBSkillData.SData");
        skill.ExportJson($"{skill.FileName}.json");
        skill.Write($"{skill.FileNameWithoutExtension}_Created.SData");

        var npcSkill = Reader.ReadFromFile<DBNpcSkillData>("DBNpcSkillData.SData");
        npcSkill.ExportJson($"{npcSkill.FileName}.json");
        npcSkill.Write($"{npcSkill.FileNameWithoutExtension}_Created.SData");

        var itemSellText = Reader.ReadFromFile<DBItemSellText>("DBItemSellText_USA.SData");
        itemSell.ExportJson($"{itemSellText.FileName}.json");
        itemSell.Write($"{itemSellText.FileNameWithoutExtension}_Created.SData");

        var itemText = Reader.ReadFromFile<DBItemText>("DBItemText_USA.SData");
        itemData.ExportJson($"{itemText.FileName}.json");
        itemData.Write($"{itemText.FileNameWithoutExtension}_Created.SData");

        var monsterText = Reader.ReadFromFile<DBMonsterText>("DBMonsterText_USA.SData");
        monster.ExportJson($"{monsterText.FileName}.json");
        monster.Write($"{monsterText.FileNameWithoutExtension}_Created.SData");

        var skillText = Reader.ReadFromFile<DBNpcSkillText>("DBSkillText_USA.SData");
        skill.ExportJson($"{skillText.FileName}.json");
        skill.Write($"{skillText.FileNameWithoutExtension}_Created.SData");

        var npcSkillText = Reader.ReadFromFile<DBNpcSkillText>("DBNpcSkillText_USA.SData");
        npcSkill.ExportJson($"{npcSkillText.FileName}.json");
        npcSkill.Write($"{npcSkillText.FileNameWithoutExtension}_Created.SData");

        #endregion
    }
}
