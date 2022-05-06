using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcSkill
{
    public class Skill : IBinary
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Level { get; set; }
        public short Image { get; set; }

        public byte Unknown1 { get; set; }
        public byte Unknown2 { get; set; }
        public byte Unknown3 { get; set; }
        public byte Unknown4 { get; set; }
        public byte Unknown5 { get; set; }
        public byte Unknown6 { get; set; }
        public byte Unknown7 { get; set; }
        public byte Unknown8 { get; set; }

        public byte Country { get; set; }
        public byte AttackFighter { get; set; }
        public byte DefenseFighter { get; set; }
        public byte PatrolRogue { get; set; }
        public byte ShootRogue { get; set; }
        public byte AttackMage { get; set; }
        public byte DefenseMage { get; set; }

        public byte Unknown9 { get; set; }
        public byte Unknown10 { get; set; }
        public byte Unknown11 { get; set; }

        public byte TypeAttack { get; set; }
        public byte TypeEffect { get; set; }
        public byte Type { get; set; }

        public byte Unknown12 { get; set; }

        public byte NeedWeapon1 { get; set; }
        public byte NeedWeapon2 { get; set; }
        public byte NeedWeapon3 { get; set; }
        public byte NeedWeapon4 { get; set; }
        public byte NeedWeapon5 { get; set; }
        public byte NeedWeapon6 { get; set; }
        public byte NeedWeapon7 { get; set; }
        public byte NeedWeapon8 { get; set; }
        public byte NeedWeapon9 { get; set; }
        public byte NeedWeapon10 { get; set; }
        public byte NeedWeapon11 { get; set; }
        public byte NeedWeapon12 { get; set; }
        public byte NeedWeapon13 { get; set; }
        public byte NeedWeapon14 { get; set; }
        public byte NeedWeapon15 { get; set; }
        public byte Shield { get; set; }

        public byte Unknown13 { get; set; }
        public byte Unknown14 { get; set; }
        public byte Unknown15 { get; set; }
        public byte Unknown16 { get; set; }

        public byte ReadyTime { get; set; }
        public short ResetTime { get; set; }
        public byte AttackRange { get; set; }
        public byte StateType { get; set; }
        public byte Attribute { get; set; }

        public byte Unknown17 { get; set; }
        public byte Unknown18 { get; set; }
        public byte Unknown19 { get; set; }
        public byte Unknown20 { get; set; }

        public byte SuccessType { get; set; }
        public byte SuccessValue { get; set; }
        public byte TargetType { get; set; }
        public byte ApplyRange { get; set; }
        public byte MultiAttack { get; set; }
        public short KeepTime { get; set; }

        public byte Unknown21 { get; set; }
        public byte Unknown22 { get; set; }
        public byte Unknown23 { get; set; }
        public byte Unknown24 { get; set; }
        public byte Unknown25 { get; set; }
        public byte Unknown26 { get; set; }

        public byte DamageType { get; set; }
        public short HpDamage { get; set; }
        public short SpDamage { get; set; }
        public short MpDamage { get; set; }

        public byte TimeDamageType { get; set; }
        public short HpTimeDamage { get; set; }
        public short SpTimeDamage { get; set; }
        public short MpTimeDamage { get; set; }

        public short HpAddDamage { get; set; }
        public short SpAddDamage { get; set; }
        public short MpAddDamage { get; set; }

        public int AbilityCount { get; set; }
        public List<Ability> Abilities { get; } = new();

        public short HpHeal { get; set; }
        public short SpHeal { get; set; }
        public short MpHeal { get; set; }

        public short HpTimeHeal { get; set; }
        public short SpTimeHeal { get; set; }
        public short MpTimeHeal { get; set; }

        public byte Unknown27 { get; set; }
        public byte Unknown28 { get; set; }
        public byte Unknown29 { get; set; }
        public byte Unknown30 { get; set; }
        public byte Unknown31 { get; set; }
        public byte Unknown32 { get; set; }
        public byte Unknown33 { get; set; }
        public byte Unknown34 { get; set; }

        [JsonConstructor]
        public Skill()
        {
        }

        public Skill(SBinaryReader binaryReader, Format format)
        {
            Name = binaryReader.ReadString();
            Description = binaryReader.ReadString();
            Level = binaryReader.Read<byte>();
            Image = binaryReader.Read<short>();

            Unknown1 = binaryReader.Read<byte>();
            Unknown2 = binaryReader.Read<byte>();
            Unknown3 = binaryReader.Read<byte>();
            Unknown4 = binaryReader.Read<byte>();
            Unknown5 = binaryReader.Read<byte>();
            Unknown6 = binaryReader.Read<byte>();
            Unknown7 = binaryReader.Read<byte>();
            Unknown8 = binaryReader.Read<byte>();

            Country = binaryReader.Read<byte>();
            AttackFighter = binaryReader.Read<byte>();
            DefenseFighter = binaryReader.Read<byte>();
            PatrolRogue = binaryReader.Read<byte>();
            ShootRogue = binaryReader.Read<byte>();
            AttackMage = binaryReader.Read<byte>();
            DefenseMage = binaryReader.Read<byte>();

            Unknown9 = binaryReader.Read<byte>();
            Unknown10 = binaryReader.Read<byte>();
            Unknown11 = binaryReader.Read<byte>();

            TypeAttack = binaryReader.Read<byte>();
            TypeEffect = binaryReader.Read<byte>();
            Type = binaryReader.Read<byte>();

            Unknown12 = binaryReader.Read<byte>();

            NeedWeapon1 = binaryReader.Read<byte>();
            NeedWeapon2 = binaryReader.Read<byte>();
            NeedWeapon3 = binaryReader.Read<byte>();
            NeedWeapon4 = binaryReader.Read<byte>();
            NeedWeapon5 = binaryReader.Read<byte>();
            NeedWeapon6 = binaryReader.Read<byte>();
            NeedWeapon7 = binaryReader.Read<byte>();
            NeedWeapon8 = binaryReader.Read<byte>();
            NeedWeapon9 = binaryReader.Read<byte>();
            NeedWeapon10 = binaryReader.Read<byte>();
            NeedWeapon11 = binaryReader.Read<byte>();
            NeedWeapon12 = binaryReader.Read<byte>();
            NeedWeapon13 = binaryReader.Read<byte>();
            NeedWeapon14 = binaryReader.Read<byte>();
            NeedWeapon15 = binaryReader.Read<byte>();
            Shield = binaryReader.Read<byte>();

            Unknown13 = binaryReader.Read<byte>();
            Unknown14 = binaryReader.Read<byte>();
            Unknown15 = binaryReader.Read<byte>();
            Unknown16 = binaryReader.Read<byte>();

            ReadyTime = binaryReader.Read<byte>();
            ResetTime = binaryReader.Read<short>();
            AttackRange = binaryReader.Read<byte>();
            StateType = binaryReader.Read<byte>();
            Attribute = binaryReader.Read<byte>();

            Unknown17 = binaryReader.Read<byte>();
            Unknown18 = binaryReader.Read<byte>();
            Unknown19 = binaryReader.Read<byte>();
            Unknown20 = binaryReader.Read<byte>();

            SuccessType = binaryReader.Read<byte>();
            SuccessValue = binaryReader.Read<byte>();
            TargetType = binaryReader.Read<byte>();
            ApplyRange = binaryReader.Read<byte>();
            MultiAttack = binaryReader.Read<byte>();
            KeepTime = binaryReader.Read<short>();

            Unknown21 = binaryReader.Read<byte>();
            Unknown22 = binaryReader.Read<byte>();
            Unknown23 = binaryReader.Read<byte>();
            Unknown24 = binaryReader.Read<byte>();
            Unknown25 = binaryReader.Read<byte>();
            Unknown26 = binaryReader.Read<byte>();

            DamageType = binaryReader.Read<byte>();
            HpDamage = binaryReader.Read<short>();
            SpDamage = binaryReader.Read<short>();
            MpDamage = binaryReader.Read<short>();

            TimeDamageType = binaryReader.Read<byte>();
            HpTimeDamage = binaryReader.Read<short>();
            SpTimeDamage = binaryReader.Read<short>();
            MpTimeDamage = binaryReader.Read<short>();

            HpAddDamage = binaryReader.Read<short>();
            SpAddDamage = binaryReader.Read<short>();
            MpAddDamage = binaryReader.Read<short>();

            AbilityCount = format switch
            {
                Format.EP4 => 3,
                Format.EP5 => 3,
                Format.EP6 => 10,
                Format.EP7 => 10,
                _ => throw new NotImplementedException()
            };

            for (int i = 0; i < AbilityCount; i++)
            {
                var ability = new Ability(binaryReader);
                Abilities.Add(ability);
            }

            HpHeal = binaryReader.Read<short>();
            SpHeal = binaryReader.Read<short>();
            MpHeal = binaryReader.Read<short>();

            HpTimeHeal = binaryReader.Read<short>();
            SpTimeHeal = binaryReader.Read<short>();
            MpTimeHeal = binaryReader.Read<short>();

            Unknown27 = binaryReader.Read<byte>();
            Unknown28 = binaryReader.Read<byte>();
            Unknown29 = binaryReader.Read<byte>();
            Unknown30 = binaryReader.Read<byte>();
            Unknown31 = binaryReader.Read<byte>();
            Unknown32 = binaryReader.Read<byte>();
            Unknown33 = binaryReader.Read<byte>();
            Unknown34 = binaryReader.Read<byte>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Name.GetLengthPrefixedBytes(Encoding.ASCII));
            buffer.AddRange(Description.GetLengthPrefixedBytes(Encoding.ASCII));
            buffer.Add(Level);
            buffer.AddRange(Image.GetBytes());

            buffer.Add(Unknown1);
            buffer.Add(Unknown2);
            buffer.Add(Unknown3);
            buffer.Add(Unknown4);
            buffer.Add(Unknown5);
            buffer.Add(Unknown6);
            buffer.Add(Unknown7);
            buffer.Add(Unknown8);

            buffer.Add(Country);
            buffer.Add(AttackFighter);
            buffer.Add(DefenseFighter);
            buffer.Add(PatrolRogue);
            buffer.Add(ShootRogue);
            buffer.Add(AttackMage);
            buffer.Add(DefenseMage);

            buffer.Add(Unknown9);
            buffer.Add(Unknown10);
            buffer.Add(Unknown11);

            buffer.Add(TypeAttack);
            buffer.Add(TypeEffect);
            buffer.Add(Type);

            buffer.Add(Unknown12);

            buffer.Add(NeedWeapon1);
            buffer.Add(NeedWeapon2);
            buffer.Add(NeedWeapon3);
            buffer.Add(NeedWeapon4);
            buffer.Add(NeedWeapon5);
            buffer.Add(NeedWeapon6);
            buffer.Add(NeedWeapon7);
            buffer.Add(NeedWeapon8);
            buffer.Add(NeedWeapon9);
            buffer.Add(NeedWeapon10);
            buffer.Add(NeedWeapon11);
            buffer.Add(NeedWeapon12);
            buffer.Add(NeedWeapon13);
            buffer.Add(NeedWeapon14);
            buffer.Add(NeedWeapon15);
            buffer.Add(Shield);

            buffer.Add(Unknown13);
            buffer.Add(Unknown14);
            buffer.Add(Unknown15);
            buffer.Add(Unknown16);

            buffer.Add(ReadyTime);
            buffer.AddRange(ResetTime.GetBytes());
            buffer.Add(AttackRange);
            buffer.Add(StateType);
            buffer.Add(Attribute);

            buffer.Add(Unknown17);
            buffer.Add(Unknown18);
            buffer.Add(Unknown19);
            buffer.Add(Unknown20);

            buffer.Add(SuccessType);
            buffer.Add(SuccessValue);
            buffer.Add(TargetType);
            buffer.Add(ApplyRange);
            buffer.Add(MultiAttack);
            buffer.AddRange(KeepTime.GetBytes());

            buffer.Add(Unknown21);
            buffer.Add(Unknown22);
            buffer.Add(Unknown23);
            buffer.Add(Unknown24);
            buffer.Add(Unknown25);
            buffer.Add(Unknown26);

            buffer.Add(DamageType);
            buffer.AddRange(HpDamage.GetBytes());
            buffer.AddRange(SpDamage.GetBytes());
            buffer.AddRange(MpDamage.GetBytes());

            buffer.Add(TimeDamageType);
            buffer.AddRange(HpTimeDamage.GetBytes());
            buffer.AddRange(SpTimeDamage.GetBytes());
            buffer.AddRange(MpTimeDamage.GetBytes());

            buffer.AddRange(HpAddDamage.GetBytes());
            buffer.AddRange(SpAddDamage.GetBytes());
            buffer.AddRange(MpAddDamage.GetBytes());

            foreach (var ability in Abilities)
            {
                buffer.AddRange(ability.GetBytes());
            }

            buffer.AddRange(HpHeal.GetBytes());
            buffer.AddRange(SpHeal.GetBytes());
            buffer.AddRange(MpHeal.GetBytes());

            buffer.AddRange(HpTimeHeal.GetBytes());
            buffer.AddRange(SpTimeHeal.GetBytes());
            buffer.AddRange(MpTimeHeal.GetBytes());

            buffer.Add(Unknown27);
            buffer.Add(Unknown28);
            buffer.Add(Unknown29);
            buffer.Add(Unknown30);
            buffer.Add(Unknown31);
            buffer.Add(Unknown32);
            buffer.Add(Unknown33);
            buffer.Add(Unknown34);

            return buffer.ToArray();
        }
    }
}
