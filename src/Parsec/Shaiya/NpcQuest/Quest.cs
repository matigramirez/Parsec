using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class Quest : IBinary
{
    public short Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }

    public ushort MinLevel { get; set; }
    public ushort MaxLevel { get; set; }
    public FactionByte Faction { get; set; }
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
    public List<QuestItem> RequiredItems { get; } = new();

    public byte EndType { get; set; }
    public byte EndNpcType { get; set; }
    public short EndNpcId { get; set; }

    /// <summary>
    /// 3 for EP4 and EP5?
    /// </summary>
    public List<QuestItem> FarmItems { get; } = new();

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
    public List<QuestResult> Results { get; } = new();

    public string InitialDescription { get; set; }
    public string QuestWindowSummary { get; set; }
    public string ReminderInstructions { get; set; }
    public string AlternateResponse { get; set; }

    [JsonConstructor]
    public Quest()
    {
    }

    public Quest(SBinaryReader binaryReader, Episode episode)
    {
        Id = binaryReader.Read<short>();

        // In ep 8, messages are moved to separate translation files.
        if (episode < Episode.EP8)
        {
            Name = binaryReader.ReadString();
            Summary = binaryReader.ReadString();
        }

        MinLevel = binaryReader.Read<ushort>();
        MaxLevel = binaryReader.Read<ushort>();
        Faction = (FactionByte)binaryReader.Read<byte>();
        Mode = (Mode)binaryReader.Read<byte>();

        // Sex - 2 separate bool
        MaleSex = binaryReader.Read<bool>();
        FemaleSex = binaryReader.Read<bool>();

        // Job x6
        Fighter = binaryReader.Read<byte>();
        Defender = binaryReader.Read<byte>();
        Ranger = binaryReader.Read<byte>();
        Archer = binaryReader.Read<byte>();
        Mage = binaryReader.Read<byte>();
        Priest = binaryReader.Read<byte>();

        wHG = binaryReader.Read<ushort>();
        shVG = binaryReader.Read<short>();
        byCG = binaryReader.Read<byte>();
        byOG = binaryReader.Read<byte>();
        byIG = binaryReader.Read<byte>();

        PreviousQuestId = binaryReader.Read<ushort>();
        RequireParty = binaryReader.Read<bool>();

        // Party Job x6
        PartyFighter = binaryReader.Read<byte>();
        PartyDefender = binaryReader.Read<byte>();
        PartyRanger = binaryReader.Read<byte>();
        PartyArcher = binaryReader.Read<byte>();
        PartyMage = binaryReader.Read<byte>();
        PartyPriest = binaryReader.Read<byte>();

        // Time values
        MinimumTime = binaryReader.Read<uint>();
        Time = binaryReader.Read<uint>();
        TickStartTerm = binaryReader.Read<uint>();
        TickKeepTime = binaryReader.Read<uint>();
        TickReceiveCount = binaryReader.Read<uint>();

        StartType = binaryReader.Read<byte>();
        StartNpcType = binaryReader.Read<byte>();
        StartNpcId = binaryReader.Read<ushort>();
        StartItemType = binaryReader.Read<byte>();
        StartItemId = binaryReader.Read<byte>();

        for (int i = 0; i < 3; i++)
        {
            var requiredItem = new QuestItem(binaryReader);
            RequiredItems.Add(requiredItem);
        }

        EndType = binaryReader.Read<byte>();
        EndNpcType = binaryReader.Read<byte>();
        EndNpcId = binaryReader.Read<short>();

        for (int i = 0; i < 3; i++)
        {
            var farmItem = new QuestItem(binaryReader);
            FarmItems.Add(farmItem);
        }

        PvpKillCount = binaryReader.Read<byte>();
        RequiredMobId1 = binaryReader.Read<ushort>();
        RequiredMobCount1 = binaryReader.Read<byte>();
        RequiredMobId2 = binaryReader.Read<ushort>();
        RequiredMobCount2 = binaryReader.Read<byte>();

        ResultType = binaryReader.Read<byte>();
        ResultUserSelect = binaryReader.Read<byte>();

        switch (episode)
        {
            case <= Episode.EP5:
                {
                    // Episodes 4 & 5 have 3 results and completion messages are read afterwards
                    for (int i = 0; i < 3; i++)
                    {
                        var result = new QuestResult(binaryReader, episode);
                        Results.Add(result);
                    }

                    InitialDescription = binaryReader.ReadString(false);
                    QuestWindowSummary = binaryReader.ReadString(false);
                    ReminderInstructions = binaryReader.ReadString(false);
                    AlternateResponse = binaryReader.ReadString(false);

                    for (int i = 0; i < 3; i++)
                    {
                        Results[i].CompletionMessage = binaryReader.ReadString(false);
                    }

                    break;
                }
            case >= Episode.EP6:
                {
                    // Episode 6 has 6 quest results and each result value is followed by its completion message
                    for (int i = 0; i < 6; i++)
                    {
                        var result = new QuestResult(binaryReader, episode);
                        Results.Add(result);

                        // Episode 8 doesn't have messages, they're part of the translation files
                        if (episode < Episode.EP8)
                            result.CompletionMessage = binaryReader.ReadString(false);
                    }

                    // Episode 8 doesn't have messages, they're part of the translation files
                    if (episode < Episode.EP8)
                    {
                        InitialDescription = binaryReader.ReadString(false);
                        QuestWindowSummary = binaryReader.ReadString(false);
                        ReminderInstructions = binaryReader.ReadString(false);
                        AlternateResponse = binaryReader.ReadString(false);
                    }

                    break;
                }
        }
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
            episode = (Episode)options[0];

        var buffer = new List<byte>();

        buffer.AddRange(Id.GetBytes());

        if (episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
        {
            buffer.AddRange(Name.GetLengthPrefixedBytes(false));
            buffer.AddRange(Summary.GetLengthPrefixedBytes(false));
        }

        buffer.AddRange(MinLevel.GetBytes());
        buffer.AddRange(MaxLevel.GetBytes());
        buffer.Add((byte)Faction);
        buffer.Add((byte)Mode);
        buffer.AddRange(MaleSex.GetBytes());
        buffer.AddRange(FemaleSex.GetBytes());
        buffer.Add(Fighter);
        buffer.Add(Defender);
        buffer.Add(Ranger);
        buffer.Add(Archer);
        buffer.Add(Mage);
        buffer.Add(Priest);
        buffer.AddRange(wHG.GetBytes());
        buffer.AddRange(shVG.GetBytes());
        buffer.Add(byCG);
        buffer.Add(byOG);
        buffer.Add(byIG);

        buffer.AddRange(PreviousQuestId.GetBytes());
        buffer.AddRange(RequireParty.GetBytes());

        buffer.Add(PartyFighter);
        buffer.Add(PartyDefender);
        buffer.Add(PartyRanger);
        buffer.Add(PartyArcher);
        buffer.Add(PartyMage);
        buffer.Add(PartyPriest);

        buffer.AddRange(MinimumTime.GetBytes());
        buffer.AddRange(Time.GetBytes());
        buffer.AddRange(TickStartTerm.GetBytes());
        buffer.AddRange(TickKeepTime.GetBytes());
        buffer.AddRange(TickReceiveCount.GetBytes());

        buffer.Add(StartType);
        buffer.Add(StartNpcType);
        buffer.AddRange(StartNpcId.GetBytes());
        buffer.Add(StartItemType);
        buffer.Add(StartItemId);

        buffer.AddRange(RequiredItems.Take(3).GetBytes(false));

        buffer.Add(EndType);
        buffer.Add(EndNpcType);
        buffer.AddRange(EndNpcId.GetBytes());

        buffer.AddRange(FarmItems.Take(3).GetBytes(false));

        buffer.Add(PvpKillCount);
        buffer.AddRange(RequiredMobId1.GetBytes());
        buffer.Add(RequiredMobCount1);
        buffer.AddRange(RequiredMobId2.GetBytes());
        buffer.Add(RequiredMobCount2);

        buffer.Add(ResultType);
        buffer.Add(ResultUserSelect);

        switch (episode)
        {
            case <= Episode.EP5:
                {
                    buffer.AddRange(Results.Take(3).GetBytes(false));
                    buffer.AddRange(InitialDescription.GetLengthPrefixedBytes(false));
                    buffer.AddRange(QuestWindowSummary.GetLengthPrefixedBytes(false));
                    buffer.AddRange(ReminderInstructions.GetLengthPrefixedBytes(false));
                    buffer.AddRange(AlternateResponse.GetLengthPrefixedBytes(false));
                    foreach (var result in Results.Take(3))
                        buffer.AddRange(result.CompletionMessage.GetLengthPrefixedBytes(false));

                    break;
                }
            case >= Episode.EP6:
                {
                    foreach (var result in Results.Take(6))
                    {
                        buffer.AddRange(result.GetBytes(episode));

                        if (episode < Episode.EP8)
                        {
                            buffer.AddRange(result.CompletionMessage.GetLengthPrefixedBytes(false));
                        }
                    }

                    if (episode < Episode.EP8)
                    {
                        buffer.AddRange(InitialDescription.GetLengthPrefixedBytes(false));
                        buffer.AddRange(QuestWindowSummary.GetLengthPrefixedBytes(false));
                        buffer.AddRange(ReminderInstructions.GetLengthPrefixedBytes(false));
                        buffer.AddRange(AlternateResponse.GetLengthPrefixedBytes(false));
                    }

                    break;
                }
        }

        return buffer;
    }
}
