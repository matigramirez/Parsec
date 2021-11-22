using System.IO;
using Newtonsoft.Json;
using Parsec.Common;

namespace Parsec.Helpers
{
    public static class Deserializer
    {
        public static T ReadFromJson<T>(string path) where T : IJsonReadable
        {
            if (!FileHelper.FileExists(path))
                throw new FileNotFoundException($"File ${path} not found");

            string jsonContent = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}