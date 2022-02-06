using System.IO;
using Newtonsoft.Json;

namespace M2HW5
{
    public class DirectoryConfigurationService : IDirectoryConfigurationService
    {
        public void SerializeDirectoryConfig(DirectoryConfig directoryConfig, string jsonFilePath)
        {
            string serializedDirectoryConfig = JsonConvert.SerializeObject(directoryConfig);
            File.WriteAllText(jsonFilePath, serializedDirectoryConfig);
        }

        public DirectoryConfig DeserializeDirectoryConfig(string jsonFilePath)
        {
            string configFile = File.ReadAllText(jsonFilePath);
            DirectoryConfig directoryConfig = JsonConvert.DeserializeObject<DirectoryConfig>(configFile);
            return directoryConfig;
        }
    }
}