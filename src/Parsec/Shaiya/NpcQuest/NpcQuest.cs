using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.NpcQuest
{
    public class NpcQuest : SData.SData
    {
        [JsonIgnore]
        public Format Format { get; set; }
        public List<Merchant> Merchants { get; } = new();
        public List<GateKeeper> Gatekeepers { get; } = new();
        public List<StandardNpc> Blacksmiths { get; } = new();
        public List<StandardNpc> PvpManagers { get; } = new();
        public List<StandardNpc> GamblingHouses { get; } = new();
        public List<StandardNpc> Warehouses { get; } = new();
        public List<StandardNpc> NormalNpcs { get; } = new();
        public List<StandardNpc> Guards { get; } = new();
        public List<StandardNpc> Animals { get; } = new();
        public List<StandardNpc> Apprentices { get; } = new();
        public List<StandardNpc> GuildMasters { get; } = new();
        public List<StandardNpc> DeadNpcs { get; } = new();
        public List<StandardNpc> CombatCommanders { get; } = new();
        public byte[] UnknownArray { get; set; }
        public List<Quest> Quests { get; } = new();

        public override void Read(params object[] options)
        {
            if (options.Length > 0)
            {
                object format = options[0];
                Format = (Format)format;
            }
            else
            {
                Format = Format.EP5;
            }

            // TODO: Remove this when support for EP5+ is added
            if (Format > Format.EP5)
                throw new NotSupportedException("Only NpcQuest EP4 and EP5 format can be read");

            ReadMerchants();
            ReadGatekeepers();
            ReadStandardNpcs(Blacksmiths);
            ReadStandardNpcs(PvpManagers);
            ReadStandardNpcs(GamblingHouses);
            ReadStandardNpcs(Warehouses);
            ReadStandardNpcs(NormalNpcs);
            ReadStandardNpcs(Guards);
            ReadStandardNpcs(Animals);
            ReadStandardNpcs(Apprentices);
            ReadStandardNpcs(GuildMasters);
            ReadStandardNpcs(DeadNpcs);
            ReadStandardNpcs(CombatCommanders);
            ReadUnknownArray();
            ReadQuests();
        }

        private void ReadMerchants()
        {
            var merchantCount = _binaryReader.Read<int>();

            for (int i = 0; i < merchantCount; i++)
            {
                var merchant = new Merchant(_binaryReader);
                Merchants.Add(merchant);
            }
        }

        private void ReadGatekeepers()
        {
            var gateKeeperCount = _binaryReader.Read<int>();

            for (int i = 0; i < gateKeeperCount; i++)
            {
                var gatekeeper = new GateKeeper(_binaryReader);
                Gatekeepers.Add(gatekeeper);
            }
        }

        private void ReadStandardNpcs(List<StandardNpc> npcList)
        {
            var count = _binaryReader.Read<int>();

            for (int i = 0; i < count; i++)
            {
                var npc = new StandardNpc(_binaryReader);
                npcList.Add(npc);
            }
        }

        private void ReadUnknownArray()
        {
            var unknownBuffer = new List<byte>();

            // 256x256 matrix
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    var value1 = _binaryReader.Read<int>();
                    var array1 = _binaryReader.ReadBytes(2 * value1);

                    unknownBuffer.AddRange(BitConverter.GetBytes(value1));
                    unknownBuffer.AddRange(array1);

                    var value2 = _binaryReader.Read<int>();
                    var array2 = _binaryReader.ReadBytes(2 * value2);

                    unknownBuffer.AddRange(BitConverter.GetBytes(value2));
                    unknownBuffer.AddRange(array2);
                }
            }

            UnknownArray = unknownBuffer.ToArray();
        }

        private void ReadQuests()
        {
            var questCount = _binaryReader.Read<int>();

            for (int i = 0; i < questCount; i++)
            {
                var quest = new Quest(_binaryReader, Format);
                Quests.Add(quest);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            throw new NotImplementedException();

            var buffer = new List<byte>();

            buffer.AddRange(Merchants.GetBytes());
            buffer.AddRange(Gatekeepers.GetBytes());
            buffer.AddRange(Blacksmiths.GetBytes());
            buffer.AddRange(PvpManagers.GetBytes());
            buffer.AddRange(GamblingHouses.GetBytes());
            buffer.AddRange(Warehouses.GetBytes());
            buffer.AddRange(NormalNpcs.GetBytes());
            buffer.AddRange(Guards.GetBytes());
            buffer.AddRange(Animals.GetBytes());
            buffer.AddRange(Apprentices.GetBytes());
            buffer.AddRange(GuildMasters.GetBytes());
            buffer.AddRange(DeadNpcs.GetBytes());
            buffer.AddRange(CombatCommanders.GetBytes());
            buffer.AddRange(UnknownArray);
            buffer.AddRange(Quests.GetBytes());

            return buffer.ToArray();
        }
    }
}
