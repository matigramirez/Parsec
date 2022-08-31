using System;
using System.Text;
using Parsec;
using Parsec.Common;
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
        npcQuest.ExportJson("NpcQuest.EP5.json");

        npcQuest = Reader.ReadFromFile<NpcQuest>("NpcQuest.EP6.SData", Episode.EP6);
        npcQuest.ExportJson("NpcQuest.EP6.json");

        npcQuest = Reader.ReadFromFile<NpcQuest>("NpcQuest.EP8.SData", Episode.EP8);
        npcQuest.ExportJson("NpcQuest.EP8.json");

        #endregion

        #region Quest translation

        var npcQuestTrans = Reader.ReadFromFile<NpcQuestTrans>("NpcQuestTrans_USA.SData");
        Console.WriteLine($"Merchant names: {npcQuestTrans.Merchants.Count}");
        Console.WriteLine($"GateKeeper names: {npcQuestTrans.Merchants.Count}");

        npcQuestTrans.ExportJson("NpcQuestTrans_USA.json");

        // Imagine you change json to ascii 1251...

        var npcQuestTransModified = Reader.ReadFromJson<NpcQuestTrans>("NpcQuestTrans_USA.json");
        npcQuestTransModified.Encoding = CodePagesEncodingProvider.Instance.GetEncoding(1251);
        npcQuestTransModified.Write("NpcQuestTrans_USA.modified.SData");

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
