using Parsec.Readers;
using Parsec.Shaiya.Itm;
using Parsec.Shaiya.Mlt;
using Parsec.Shaiya.MLX;
using Parsec.Shaiya.MON;

namespace Parsec.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region MLX

            var mlx = Reader.ReadFromFile<MLX>("demf.MLX");

            // Since each MLX record has its Id appended, it's important to recalculate the indices after
            // adding or removing a record
            mlx.RecalculateIndices();

            mlx.ExportJson($"{mlx.FileName}.json");

            #endregion

            #region MLT

            var mlt = Reader.ReadFromFile<MLT>("humf_face.MLT");
            mlt.ExportJson($"{mlt.FileName}.json");

            #endregion

            #region ITM

            var itm = Reader.ReadFromFile<ITM>("02.ITM");
            itm.ExportJson($"{itm.FileName}.json");

            #endregion

            #region MON

            var mon = Reader.ReadFromFile<MON>("Monster.MON");
            mon.ExportJson($"{mon.FileName}.json");

            #endregion
        }
    }
}
