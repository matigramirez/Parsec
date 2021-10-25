using System;
using System.Linq;

namespace Parsec.Shaiya.Common
{
    public class Matrix4
    {
        private readonly float[,] _matrix = new float[4,4];

        public float[,] Data => _matrix;

        public Matrix4()
        {
        }

        public Matrix4(float[] row0, float[] row1, float[] row2, float[] row3)
        {
            if (row0.Length != 4 || row1.Length != 4 || row2.Length != 4 || row3.Length != 4)
            {
                throw new ArgumentException("Rows must have 4 elements each");
            }

            SetRow(0, row0);
            SetRow(1, row1);
            SetRow(2, row2);
            SetRow(3, row3);
        }

        public void SetRow(int rowNumber, float[] data)
        {
            if (data.Length != 4)
                throw new ArgumentException("Rows must have 4 elements each");

            for (int i = 0; i < 4; i++)
            {
                _matrix[rowNumber, i] = data[i];
            }
        }

        public void SetColumn(int columnNumber, float[] data)
        {
            if (data.Length != 4)
                throw new ArgumentException("Columns must have 4 elements each");

            for (int i = 0; i < 4; i++)
            {
                _matrix[i, columnNumber] = data[i];
            }
        }

        public float[] GetRow(int rowNumber)
        {
            if (rowNumber > 3)
                throw new ArgumentException("The matrix's valid rows are 0-3");

            return Enumerable.Range(0, _matrix.GetLength(0))
                      .Select(x => _matrix[rowNumber, x])
                      .ToArray();
        }

        public float[] GetColumn(int columnNumber)
        {
            if (columnNumber > 3)
                throw new ArgumentException("The matrix's valid columns are 0-3");

            return Enumerable.Range(0, _matrix.GetLength(0))
                      .Select(x => _matrix[x, columnNumber])
                      .ToArray();
        }

        public float[] Row0 => GetRow(0);
        public float[] Row1 => GetRow(1);
        public float[] Row2 => GetRow(2);
        public float[] Row3 => GetRow(3);

        public float[] Col0 => GetColumn(0);
        public float[] Col1 => GetColumn(1);
        public float[] Col2 => GetColumn(2);
        public float[] Col3 => GetColumn(3);

        public float A00 => _matrix[0, 0];
        public float A01 => _matrix[0, 1];
        public float A02 => _matrix[0, 2];
        public float A03 => _matrix[0, 3];
        public float A10 => _matrix[1, 0];
        public float A11 => _matrix[1, 1];
        public float A12 => _matrix[1, 2];
        public float A13 => _matrix[1, 3];
        public float A20 => _matrix[2, 0];
        public float A21 => _matrix[2, 1];
        public float A22 => _matrix[2, 2];
        public float A23 => _matrix[2, 3];
        public float A30 => _matrix[3, 0];
        public float A31 => _matrix[3, 1];
        public float A32 => _matrix[3, 2];
        public float A33 => _matrix[3, 3];
    }
}
