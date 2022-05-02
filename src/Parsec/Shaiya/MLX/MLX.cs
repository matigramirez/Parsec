﻿using System.Collections.Generic;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MLX
{
    /// <summary>
    /// Represents a .MLX file, which is used as an index for 3DC-DDS combinations for each class/sex combination
    /// </summary>
    public class MLX : FileBase, IJsonReadable
    {
        public List<MLXRecord> Records { get; } = new();

        public override string Extension => "MLX";

        public MLXFormat Format { get; set; } = MLXFormat.MLX1;

        public override void Read(params object[] options)
        {
            // For some reason, sometimes MLX files are empty
            if(_binaryReader.Buffer.Length == 0)
                return;
            
            var signature = _binaryReader.ReadString(4);

            if (signature == "MLX2")
                Format = MLXFormat.MLX2;
            else
                _binaryReader.ResetOffset();
            
            var recordCount = _binaryReader.Read<int>();

            for (int i = 0; i < recordCount; i++)
            {
                var record = new MLXRecord(_binaryReader, Format);
                Records.Add(record);
            }
        }

        public override byte[] GetBytes(params object[] options) => Records.GetBytes();

        /// <summary>
        /// Helper method to recalculate MLX record indices, just in case they get messed up or new records have been added
        /// </summary>
        public void RecalculateIndices()
        {
            for (int i = 0; i < Records.Count; i++)
            {
                var record = Records[i];
                record.Id = i;
            }
        }
    }
}
