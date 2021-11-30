using System.IO;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Helpers
{
    public static class Deserializer
    {
        public static T ReadFromJson<T>(string path) where T : FileBase, IJsonReadable
        {
            if (!FileHelper.FileExists(path))
                throw new FileNotFoundException($"File ${path} not found");

            if (path.Length < 6 || path[^5..] != ".json")
                throw new FileLoadException("The provided file to deserialize must be a valid json file");

            // Read json file content
            string jsonContent = File.ReadAllText(path);

            // Deserialize into FileBase
            var deserializedObject = JsonConvert.DeserializeObject<T>(jsonContent);

            // Get file name without the ".json" extension
            string fileNameWithoutJsonExtension = Path.GetFileNameWithoutExtension(path);

            // Add proper Path to deserialized object
            if (deserializedObject != null)
            {
                var objectExtension = deserializedObject.Extension;

                // If file name is not long enough to have the extension, add it
                if (fileNameWithoutJsonExtension.Length < objectExtension.Length)
                {
                    deserializedObject.Path = $"{fileNameWithoutJsonExtension}.{objectExtension}";
                    return deserializedObject;
                }

                // Check if file extension matches the appropriate FileBase child extension
                // This is needed since a file could be called MobFox.3DC.json, meaning it already has
                // its extension after the ".json" part is removed
                var fileExtension = fileNameWithoutJsonExtension[^objectExtension.Length..];

                if (fileExtension != objectExtension)
                {
                    deserializedObject.Path = $"{fileNameWithoutJsonExtension}.{objectExtension}";
                }
                else
                {
                    deserializedObject.Path = fileNameWithoutJsonExtension;
                }
            }

            return deserializedObject;
        }
    }
}