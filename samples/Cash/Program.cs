using Parsec.Shaiya.CASH;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var cash = new Cash("Cash.SData");
            cash.Read();
            cash.ExportJson("Cash.json");
        }
    }
}
