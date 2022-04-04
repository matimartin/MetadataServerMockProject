using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace MetadataServerMockProject
{
    public static class Helper
    {
        /// <summary>
        /// Deserializes a JSON object string to a given object type
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <param name="jsonObject">JSON object string</param>
        /// <returns>Object created from JSON string</returns>
        public static T ParseJsonObject<T>(string jsonObject)
        {
            return JsonConvert.DeserializeObject<T>(jsonObject);
        }

        /// <summary>
        /// Deserializes a JSON object file to a given object type
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <param name="fileName">JSON object file</param>
        /// <returns>Object created from JSON file</returns>
        public static T ParseJsonFile<T>(string fileName)
        {
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var files = Directory.GetFiles(currentPath, fileName, SearchOption.AllDirectories);

            if (files.Length == 0)
                throw new Exception($"Unable to find '{fileName}'");

            if (files.Length > 1)
                throw new Exception($"Multiple files found with name: '{fileName}'. File names must be unique.");

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(files[0]));
        }
    }
}
