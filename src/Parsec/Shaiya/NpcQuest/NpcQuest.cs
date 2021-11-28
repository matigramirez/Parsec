using System.Collections.Generic;
using Parsec.Shaiya.SDATA;

namespace Parsec.Shaiya.NPCQUEST
{
    public class NpcQuest : SData
    {
        public List<Merchant> Merchants { get; } = new();
        public List<GateKeeper> GateKeepers { get; } = new();
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
        public List<Quest> Quests { get; } = new();

        // TODO: add quest fields

        public NpcQuest(string path) : base(path)
        {
        }

        public override void Read()
        {
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

            // TODO: Find out how many bytes need to be skipped exactly here
            // Quest Offset for Ep6 Quests
            //_binaryReader.SetOffset(0xC3D73);

            //ReadQuests();
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
                GateKeepers.Add(gatekeeper);
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

        private void ReadQuests()
        {
            var questCount = _binaryReader.Read<int>();

            for (int i = 0; i < questCount; i++)
            {
                var quest = new Quest(_binaryReader);
                Quests.Add(quest);
            }
        }
    }
}
