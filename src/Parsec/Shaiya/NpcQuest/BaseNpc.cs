using System;
using System.Collections.Generic;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest
{
    public abstract class BaseNpc : IBinary
    {
        private readonly Format _format;
        public NpcType Type { get; set; }
        public short TypeId { get; set; }
        public int Model { get; set; }
        public int MoveDistance { get; set; }
        public int MoveSpeed { get; set; }
        public FactionInt Faction { get; set; }
        public string Name { get; set; }
        public string WelcomeMessage { get; set; }

        public List<short> InQuestIds { get; } = new();
        public List<short> OutQuestIds { get; } = new();

        public BaseNpc(Format format)
        {
            _format = format;
        }

        protected void ReadNpcBaseComplete(SBinaryReader binaryReader)
        {
            ReadBaseNpcFirstSegment(binaryReader);
            ReadBaseNpcSecondSegment(binaryReader);
            ReadBaseNpcThirdSegment(binaryReader);
        }

        protected void ReadBaseNpcFirstSegment(SBinaryReader binaryReader)
        {
            Type = (NpcType)binaryReader.Read<byte>();
            TypeId = binaryReader.Read<short>();
        }

        protected void WriteBaseNpcFirstSegmentBytes(List<byte> buffer)
        {
            buffer.Add((byte)Type);
            buffer.AddRange(TypeId.GetBytes());
        }

        protected void ReadBaseNpcSecondSegment(SBinaryReader binaryReader)
        {
            Model = binaryReader.Read<int>();
            MoveDistance = binaryReader.Read<int>();
            MoveSpeed = binaryReader.Read<int>();
            Faction = (FactionInt)binaryReader.Read<int>();

            if (_format < Format.EP8) // In ep 8, messages are moved to separate translation files.
            {
                Name = binaryReader.ReadString(false);
                WelcomeMessage = binaryReader.ReadString(false);
            }
        }

        protected void WriteBaseNpcSecondSegmentBytes(List<byte> buffer)
        {
            buffer.AddRange(Model.GetBytes());
            buffer.AddRange(MoveDistance.GetBytes());
            buffer.AddRange(MoveSpeed.GetBytes());
            buffer.AddRange(((int)Faction).GetBytes());
            if (_format < Format.EP8) // In ep 8, messages are moved to separate translation files.
            {
                buffer.AddRange(Name.GetLengthPrefixedBytes(false));
                buffer.AddRange(WelcomeMessage.GetLengthPrefixedBytes(false));
            }
        }

        protected void ReadBaseNpcThirdSegment(SBinaryReader binaryReader)
        {
            var inQuestQuantity = binaryReader.Read<int>();

            for (int i = 0; i < inQuestQuantity; i++)
            {
                var questId = binaryReader.Read<short>();
                InQuestIds.Add(questId);
            }

            var outQuestQuantity = binaryReader.Read<int>();

            for (int i = 0; i < outQuestQuantity; i++)
            {
                var questId = binaryReader.Read<short>();
                OutQuestIds.Add(questId);
            }
        }

        protected void WriteBaseNpcThirdSegmentBytes(List<byte> buffer)
        {
            buffer.AddRange(BitConverter.GetBytes(InQuestIds.Count));

            foreach (var inQuestId in InQuestIds)
                buffer.AddRange(BitConverter.GetBytes(inQuestId));

            buffer.AddRange(BitConverter.GetBytes(OutQuestIds.Count));

            foreach (var outQuestId in OutQuestIds)
                buffer.AddRange(BitConverter.GetBytes(outQuestId));
        }

        public virtual byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            WriteBaseNpcFirstSegmentBytes(buffer);
            WriteBaseNpcSecondSegmentBytes(buffer);
            WriteBaseNpcThirdSegmentBytes(buffer);

            return buffer.ToArray();
        }
    }
}
