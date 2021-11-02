using System.Linq;
using Parsec.Shaiya;

namespace Parsec.Samples.Sah
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load sah
            var sah = new Shaiya.Sah("data.sah");
            sah.Load();

            // Find the file you want to extract
            var file = sah.FileIndex.Values.FirstOrDefault(f => f.Name == "sysmsg-uni.txt");

            // Check that file isn't null
            if (file == null)
                return;

            // Create file instance
            var saf = new Saf(sah);

            // Read saf and extract the selected file
            saf.Extract(file, "extracted");
        }
    }
}
