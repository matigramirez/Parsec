using System.Linq;
using Parsec.Shaiya.Data;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read data
            var data = new Data("data.sah");

            // Find the file you want to extract
            var file = data.Sah.FileIndex.Values.FirstOrDefault(f => f.Name == "AutoStat_Mode.cfg");

            // Check that file isn't null
            if (file == null)
                return;

            // Extract the selected file
            data.Extract(file, "extracted");
        }
    }
}
