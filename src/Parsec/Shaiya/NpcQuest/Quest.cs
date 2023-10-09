using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class Quest : ISerializable
{
    public ushort Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public ushort MinLevel { get; set; }

    public ushort MaxLevel { get; set; }

    public QuestFaction Faction { get; set; }

    public Mode Mode { get; set; }

    // Sex - 2 separate bool
    public bool MaleSex { get; set; }

    public bool FemaleSex { get; set; }

    // Job x6
    public byte Fighter { get; set; }

    public byte Defender { get; set; }

    public byte Ranger { get; set; }

    public byte Archer { get; set; }

    public byte Mage { get; set; }

    public byte Priest { get; set; }

    public ushort wHG { get; set; }

    public short shVG { get; set; }

    public byte byCG { get; set; }

    public byte byOG { get; set; }

    public byte byIG { get; set; }

    public ushort PreviousQuestId { get; set; }

    public bool RequireParty { get; set; }

    // Party Job x6
    public byte PartyFighter { get; set; }

    public byte PartyDefender { get; set; }

    public byte PartyRanger { get; set; }

    public byte PartyArcher { get; set; }

    public byte PartyMage { get; set; }

    public byte PartyPriest { get; set; }

    // Time values
    public uint MinimumTime { get; set; }

    public uint Time { get; set; }

    public uint TickStartTerm { get; set; }

    public uint TickKeepTime { get; set; }

    public uint TickReceiveCount { get; set; }

    public byte StartType { get; set; }

    public byte StartNpcType { get; set; }

    public ushort StartNpcId { get; set; }

    public byte StartItemType { get; set; }

    public byte StartItemId { get; set; }

    /// <summary>
    /// 3 for EP4 and EP5?
    /// </summary>
    public List<QuestItem> RequiredItems { get; set; } = new();

    public byte EndType { get; set; }

    public byte EndNpcType { get; set; }

    public short EndNpcId { get; set; }

    /// <summary>
    /// 3 for EP4 and EP5?
    /// </summary>
    public List<QuestItem> FarmItems { get; set; } = new();

    /// <summary>
    /// byPCKillCount = pvp kills?
    /// </summary>
    public byte PvpKillCount { get; set; }

    public ushort RequiredMobId1 { get; set; }

    /// <summary>
    /// The required mob count for <see cref="RequiredMobId1"/>
    /// </summary>
    public byte RequiredMobCount1 { get; set; }

    public ushort RequiredMobId2 { get; set; }

    /// <summary>
    /// The required mob count for <see cref="RequiredMobId2"/>
    /// </summary>
    public byte RequiredMobCount2 { get; set; }

    public byte ResultType { get; set; }

    /// <summary>
    /// I guess defines if the user can choose a reward or if a default reward should be given
    /// </summary>
    public byte ResultUserSelect { get; set; }

    /// <summary>
    /// 3 for EP5 and below, 6 results for EP6 and above
    /// </summary>
    public List<QuestResult> Results { get; set; } = new();

    public string InitialDescription { get; set; } = string.Empty;

    public string QuestWindowSummary { get; set; } = string.Empty;

    public string ReminderInstructions { get; set; } = string.Empty;

    public string AlternateResponse { get; set; } = string.Empty;

    private const int RequiredItemCount = 3;

    private const int FarmItemCount = 3;

    public void Read(SBinaryReader binaryReader)
    {
        var episode = binaryReader.SerializationOptions.Episode;

        Id = binaryReader.ReadUInt16();

        if (episode < Episode.EP8)
        {
            Name = binaryReader.ReadString();
            Summary = binaryReader.ReadString();
        }

        MinLevel = binaryReader.ReadUInt16();
        MaxLevel = binaryReader.ReadUInt16();
        Faction = (QuestFaction)binaryReader.ReadByte();
        Mode = (Mode)binaryReader.ReadByte();

        // Sex - 2 separate bool
        MaleSex = binaryReader.ReadBool();
        FemaleSex = binaryReader.ReadBool();

        // Job x6
        Fighter = binaryReader.ReadByte();
        Defender = binaryReader.ReadByte();
        Ranger = binaryReader.ReadByte();
        Archer = binaryReader.ReadByte();
        Mage = binaryReader.ReadByte();
        Priest = binaryReader.ReadByte();

        wHG = binaryReader.ReadUInt16();
        shVG = binaryReader.ReadInt16();
        byCG = binaryReader.ReadByte();
        byOG = binaryReader.ReadByte();
        byIG = binaryReader.ReadByte();

        PreviousQuestId = binaryReader.ReadUInt16();
        RequireParty = binaryReader.ReadBool();

        // Party Job x6
        PartyFighter = binaryReader.ReadByte();
        PartyDefender = binaryReader.ReadByte();
        PartyRanger = binaryReader.ReadByte();
        PartyArcher = binaryReader.ReadByte();
        PartyMage = binaryReader.ReadByte();
        PartyPriest = binaryReader.ReadByte();

        // Time values
        MinimumTime = binaryReader.ReadUInt32();
        Time = binaryReader.ReadUInt32();
        TickStartTerm = binaryReader.ReadUInt32();
        TickKeepTime = binaryReader.ReadUInt32();
        TickReceiveCount = binaryReader.ReadUInt32();

        StartType = binaryReader.ReadByte();
        StartNpcType = binaryReader.ReadByte();
        StartNpcId = binaryReader.ReadUInt16();
        StartItemType = binaryReader.ReadByte();
        StartItemId = binaryReader.ReadByte();

        RequiredItems = binaryReader.ReadList<QuestItem>(RequiredItemCount).ToList();

        EndType = binaryReader.ReadByte();
        EndNpcType = binaryReader.ReadByte();
        EndNpcId = binaryReader.ReadInt16();

        FarmItems = binaryReader.ReadList<QuestItem>(FarmItemCount).ToList();

        PvpKillCount = binaryReader.ReadByte();
        RequiredMobId1 = binaryReader.ReadUInt16();
        RequiredMobCount1 = binaryReader.ReadByte();
        RequiredMobId2 = binaryReader.ReadUInt16();
        RequiredMobCount2 = binaryReader.ReadByte();

        ResultType = binaryReader.ReadByte();
        ResultUserSelect = binaryReader.ReadByte();

        var resultCount = GetResultCount(episode);

        if (episode <= Episode.EP5)
        {
            // Episodes 4 & 5 have 3 results and completion messages are read afterwards
            Results = binaryReader.ReadList<QuestResult>(resultCount).ToList();

            InitialDescription = binaryReader.ReadString();
            QuestWindowSummary = binaryReader.ReadString();
            ReminderInstructions = binaryReader.ReadString();
            AlternateResponse = binaryReader.ReadString();

            for (var i = 0; i < resultCount; i++)
            {
                Results[i].CompletionMessage = binaryReader.ReadString();
            }
        }
        else
        {
            // Episode 6 has 6 quest results and each result value is followed by its completion message
            Results = binaryReader.ReadList<QuestResult>(resultCount).ToList();

            if (episode < Episode.EP8)
            {
                InitialDescription = binaryReader.ReadString();
                QuestWindowSummary = binaryReader.ReadString();
                ReminderInstructions = binaryReader.ReadString();
                AlternateResponse = binaryReader.ReadString();
            }
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var episode = binaryWriter.SerializationOptions.Episode;

        binaryWriter.Write(Id);

        if (episode < Episode.EP8)
        {
            binaryWriter.Write(Name);
            binaryWriter.Write(Summary);
        }

        binaryWriter.Write(MinLevel);
        binaryWriter.Write(MaxLevel);
        binaryWriter.Write((byte)Faction);
        binaryWriter.Write((byte)Mode);
        binaryWriter.Write(MaleSex);
        binaryWriter.Write(FemaleSex);
        binaryWriter.Write(Fighter);
        binaryWriter.Write(Defender);
        binaryWriter.Write(Ranger);
        binaryWriter.Write(Archer);
        binaryWriter.Write(Mage);
        binaryWriter.Write(Priest);
        binaryWriter.Write(wHG);
        binaryWriter.Write(shVG);
        binaryWriter.Write(byCG);
        binaryWriter.Write(byOG);
        binaryWriter.Write(byIG);
        binaryWriter.Write(PreviousQuestId);
        binaryWriter.Write(RequireParty);
        binaryWriter.Write(PartyFighter);
        binaryWriter.Write(PartyDefender);
        binaryWriter.Write(PartyRanger);
        binaryWriter.Write(PartyArcher);
        binaryWriter.Write(PartyMage);
        binaryWriter.Write(PartyPriest);
        binaryWriter.Write(MinimumTime);
        binaryWriter.Write(Time);
        binaryWriter.Write(TickStartTerm);
        binaryWriter.Write(TickKeepTime);
        binaryWriter.Write(TickReceiveCount);
        binaryWriter.Write(StartType);
        binaryWriter.Write(StartNpcType);
        binaryWriter.Write(StartNpcId);
        binaryWriter.Write(StartItemType);
        binaryWriter.Write(StartItemId);
        binaryWriter.Write(RequiredItems.Take(RequiredItemCount).ToSerializable(), lengthPrefixed: false);
        binaryWriter.Write(EndType);
        binaryWriter.Write(EndNpcType);
        binaryWriter.Write(EndNpcId);
        binaryWriter.Write(FarmItems.Take(FarmItemCount).ToSerializable(), lengthPrefixed: false);
        binaryWriter.Write(PvpKillCount);
        binaryWriter.Write(RequiredMobId1);
        binaryWriter.Write(RequiredMobCount1);
        binaryWriter.Write(RequiredMobId2);
        binaryWriter.Write(RequiredMobCount2);
        binaryWriter.Write(ResultType);
        binaryWriter.Write(ResultUserSelect);

        var resultCount = GetResultCount(episode);

        if (episode <= Episode.EP5)
        {
            binaryWriter.Write(Results.Take(resultCount).ToSerializable(), lengthPrefixed: false);

            binaryWriter.Write(InitialDescription, includeStringTerminator: false);
            binaryWriter.Write(QuestWindowSummary, includeStringTerminator: false);
            binaryWriter.Write(ReminderInstructions, includeStringTerminator: false);
            binaryWriter.Write(AlternateResponse, includeStringTerminator: false);

            for (var i = 0; i < resultCount; i++)
            {
                binaryWriter.Write(Results[i].CompletionMessage, includeStringTerminator: false);
            }
        }
        else
        {
            binaryWriter.Write(Results.Take(resultCount).ToSerializable(), lengthPrefixed: false);

            if (episode < Episode.EP8)
            {
                binaryWriter.Write(InitialDescription, includeStringTerminator: false);
                binaryWriter.Write(QuestWindowSummary, includeStringTerminator: false);
                binaryWriter.Write(ReminderInstructions, includeStringTerminator: false);
                binaryWriter.Write(AlternateResponse, includeStringTerminator: false);
            }
        }
    }

    private int GetResultCount(Episode episode)
    {
        return episode <= Episode.EP5 ? 3 : 6;
    }
}
