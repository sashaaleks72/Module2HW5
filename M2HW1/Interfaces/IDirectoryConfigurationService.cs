namespace M2HW5
{
    public interface IDirectoryConfigurationService
    {
        void SerializeDirectoryConfig(DirectoryConfig directoryConfig, string jsonFilePath);
        DirectoryConfig DeserializeDirectoryConfig(string jsonFilePath);
    }
}
