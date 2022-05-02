﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class Portal : IBinary
    {
        public Vector3 Position { get; set; }
        public int FactionOrPortalId { get; set; }
        public short MinLevel { get; set; }
        public short MaxLevel { get; set; }
        public int DestinationMapId { get; set; }
        public Vector3 DestinationPosition { get; set; }

        [JsonConstructor]
        public Portal()
        {
        }
        
        public Portal(SBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
            FactionOrPortalId = binaryReader.Read<int>();
            MinLevel = binaryReader.Read<short>();
            MaxLevel = binaryReader.Read<short>();
            DestinationMapId = binaryReader.Read<int>();
            DestinationPosition = new Vector3(binaryReader);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Position.GetBytes());
            buffer.AddRange(FactionOrPortalId.GetBytes());
            buffer.AddRange(MinLevel.GetBytes());
            buffer.AddRange(MaxLevel.GetBytes());
            buffer.AddRange(DestinationMapId.GetBytes());
            buffer.AddRange(DestinationPosition.GetBytes());
            return buffer.ToArray();
        }
    }
}
