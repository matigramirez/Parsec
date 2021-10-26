using System.Collections.Generic;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya
{
    public class NpcQuest : SData
    {
        public int MerchantCount => Merchants.Count;
        public List<Merchant> Merchants { get; } = new();
        public int GateKeeperCount => GateKeepers.Count;
        public List<GateKeeper> GateKeepers { get; } = new();
        public int BlacksmithCount => Blacksmiths.Count;
        public List<StandardNpc> Blacksmiths { get; } = new();
        public int PvpManagerCount => PvpManagers.Count;
        public List<StandardNpc> PvpManagers { get; } = new();
        public int GamblingHouseCount => GamblingHouses.Count;
        public List<StandardNpc> GamblingHouses { get; } = new();
        public int WarehouseCount => Warehouses.Count;
        public List<StandardNpc> Warehouses { get; } = new();
        public int NormalNpcCount => NormalNpcs.Count;
        public List<StandardNpc> NormalNpcs { get; } = new();
        public int GuardCount => Guards.Count;
        public List<StandardNpc> Guards { get; } = new();
        public int AnimalCount => Animals.Count;
        public List<StandardNpc> Animals { get; } = new();
        public int ApprenticeCount => Apprentices.Count;
        public List<StandardNpc> Apprentices { get; } = new();
        public int GuildMasterCount => GuildMasters.Count;
        public List<StandardNpc> GuildMasters { get; } = new();
        public int DeadNpcCount => DeadNpcs.Count;
        public List<StandardNpc> DeadNpcs { get; } = new();
        public int CombatCommanderCount => CombatCommanders.Count;
        public List<StandardNpc> CombatCommanders { get; } = new();

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
        }

        private void ReadMerchants()
        {
            var merchantCount = _binaryReader.Read<int>();

            for (int i = 0; i < merchantCount; i++)
            {
                var merchant = new Merchant();
                merchant.ReadBaseNpcFirstSegment(_binaryReader);
                merchant.MerchantType = (MerchantType)_binaryReader.Read<byte>();
                merchant.ReadBaseNpcSecondSegment(_binaryReader);

                merchant.ItemQuantity = _binaryReader.Read<int>();

                for (int j = 0; j < merchant.ItemQuantity; j++)
                {
                    var merchantItem = new MerchantItem
                    {
                        Type = _binaryReader.Read<byte>(),
                        TypeId = _binaryReader.Read<byte>()
                    };

                    merchant.SaleItems.Add(merchantItem);
                }

                merchant.ReadBaseNpcThirdSegment(_binaryReader);

                Merchants.Add(merchant);
            }
        }

        private void ReadGatekeepers()
        {
            var gateKeeperCount = _binaryReader.Read<int>();

            GateTarget ReadGateTarget() => new GateTarget
            {
                MapId = _binaryReader.Read<short>(),
                Position = new Vector3(_binaryReader),
                TargetName = _binaryReader.ReadString(),
                Cost = _binaryReader.Read<int>()
            };


            for (int i = 0; i < gateKeeperCount; i++)
            {
                var gatekeeper = new GateKeeper();
                gatekeeper.ReadBaseNpcFirstSegment(_binaryReader);
                gatekeeper.ReadBaseNpcSecondSegment(_binaryReader);

                gatekeeper.GateTarget1 = ReadGateTarget();
                gatekeeper.GateTarget2 = ReadGateTarget();
                gatekeeper.GateTarget3 = ReadGateTarget();

                gatekeeper.ReadBaseNpcThirdSegment(_binaryReader);

                GateKeepers.Add(gatekeeper);
            }
        }

        private void ReadStandardNpcs(List<StandardNpc> npcList)
        {
            var count = _binaryReader.Read<int>();

            for (int i = 0; i < count; i++)
            {
                var npc = new StandardNpc();
                npc.ReadNpcBaseComplete(_binaryReader);
                npcList.Add(npc);
            }
        }
    }
}
