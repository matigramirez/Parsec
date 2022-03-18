using Parsec.Readers;
using Parsec.Shaiya.Ani;

var dir = Directory.GetCurrentDirectory();
var files = Directory.GetFiles(dir);
var aniFiles = files.Where(f => Path.GetExtension(f).ToLower() == ".ani");
int conversionCount = 0;

foreach (var aniPath in aniFiles)
{
    var ani = Reader.ReadFromFile<Ani>(aniPath);
    ani.IsAniV2 = false;
    ani.Write(aniPath);
    conversionCount++;
}

Console.WriteLine($"Converted {conversionCount} ANI files.");
Console.ReadLine();
