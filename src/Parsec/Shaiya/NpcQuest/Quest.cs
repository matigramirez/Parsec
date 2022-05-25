using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest
{
    public class Quest : IBinary
    {
        private readonly Episode _episode;
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
        public List<QuestItem> RewardItems { get; } = new();

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
        /// 3 results, it this variable throughout EPs too?
        /// </summary>
        public List<QuestResult> Results { get; } = new();

        public string InitialDescription { get; set; }
        public string QuestWindowSummary { get; set; }
        public string ReminderInstructions { get; set; }
        public string AlternateResponse { get; set; }
        public string CompletionMessage { get; set; }
        public string AlternateCompletionMessage1 { get; set; }
        public string AlternateCompletionMessage2 { get; set; }

        public Quest(SBinaryReader binaryReader, Episode episode)
        {
            _episode = episode;
            Id = binaryReader.Read<short>();
            if (_episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
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
                var rewardItem = new QuestItem(binaryReader);
                RewardItems.Add(rewardItem);
            }

            PvpKillCount = binaryReader.Read<byte>();
            RequiredMobId1 = binaryReader.Read<ushort>();
            RequiredMobCount1 = binaryReader.Read<byte>();
            RequiredMobId2 = binaryReader.Read<ushort>();
            RequiredMobCount2 = binaryReader.Read<byte>();

            ResultType = binaryReader.Read<byte>();
            ResultUserSelect = binaryReader.Read<byte>();


            for (int i = 0; i < (_episode <= Episode.EP5 ? 3 : 6); i++)
            {
                var result = new QuestResult(binaryReader, episode);
                Results.Add(result);
            }

            if (_episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
            {
                InitialDescription = binaryReader.ReadString(false);
                QuestWindowSummary = binaryReader.ReadString(false);
                ReminderInstructions = binaryReader.ReadString(false);
                AlternateResponse = binaryReader.ReadString(false);
                CompletionMessage = binaryReader.ReadString(false);
                AlternateCompletionMessage1 = binaryReader.ReadString(false);
                AlternateCompletionMessage2 = binaryReader.ReadString(false);
            }
        }

        [JsonConstructor]
        public Quest()
        {
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Id.GetBytes());
            if (_episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
            {
                buffer.AddRange(Name.GetLengthPrefixedBytes(false));
                buffer.AddRange(Summary.GetLengthPrefixedBytes(false));
            }
            buffer.AddRange(MinLevel.GetBytes());
            buffer.AddRange(MaxLevel.GetBytes());
            buffer.Add((byte)Faction);
            buffer.Add((byte)Mode);
            buffer.Add(Convert.ToByte(MaleSex));
            buffer.Add(Convert.ToByte(FemaleSex));
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
            buffer.Add(Convert.ToByte(RequireParty));
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

            buffer.AddRange(RequiredItems.GetBytes());

            buffer.Add(EndType);
            buffer.Add(EndNpcType);
            buffer.AddRange(EndNpcId.GetBytes());

            buffer.AddRange(RewardItems.GetBytes());

            buffer.Add(PvpKillCount);
            buffer.AddRange(RequiredMobId1.GetBytes());
            buffer.Add(RequiredMobCount1);
            buffer.AddRange(RequiredMobId2.GetBytes());
            buffer.Add(RequiredMobCount2);

            buffer.Add(ResultType);
            buffer.Add(ResultUserSelect);

            buffer.AddRange(Results.GetBytes());

            if (_episode < Episode.EP8) // In ep 8, messages are moved to separate translation files.
            {
                buffer.AddRange(InitialDescription.GetLengthPrefixedBytes());
                buffer.AddRange(QuestWindowSummary.GetLengthPrefixedBytes());
                buffer.AddRange(ReminderInstructions.GetLengthPrefixedBytes());
                buffer.AddRange(AlternateResponse.GetLengthPrefixedBytes());
                buffer.AddRange(CompletionMessage.GetLengthPrefixedBytes());
                buffer.AddRange(AlternateCompletionMessage1.GetLengthPrefixedBytes());
                buffer.AddRange(AlternateCompletionMessage2.GetLengthPrefixedBytes());
            }

            return buffer.ToArray();
        }
    }
}
