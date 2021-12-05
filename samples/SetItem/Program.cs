using Parsec.Shaiya.SETITEM;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var setItem = new SetItem("SetItem.SData");
            setItem.Read();
            setItem.ExportJson("SetItem.json");
        }
    }
}
