using System;
using System.IO;

namespace M2HW5
{
    public class FileService : IFileService
    {
        public FileService(IDirectoryConfigurationService directoryConfigurationService)
        {
            DirectoryConfigurationService = directoryConfigurationService;
            DateOfFileCreation = DateTime.Now;
        }

        public IDirectoryConfigurationService DirectoryConfigurationService { get; set; }
        public DateTime DateOfFileCreation { get; set; }

        public void WriteIntoFile(string text)
        {
            string pathToJsonConfig = @"C:\Users\sasha\source\repos\Module2HW5\M2HW1\Configs\directory-config.json";
            DirectoryConfig directoryConfig = DirectoryConfigurationService.DeserializeDirectoryConfig(pathToJsonConfig);

            string pathToLogFiles = directoryConfig.DirectoryName;

            if (!Directory.Exists(pathToLogFiles))
            {
                Directory.CreateDirectory(pathToLogFiles);
            }

            if (Directory.GetFiles(pathToLogFiles).Length > 3)
            {
                DeleteOldFile(pathToLogFiles);
            }

            using (StreamWriter streamWriter = new StreamWriter($"{pathToLogFiles}\\{DateOfFileCreation:HH.mm.ss dd.MM.yyyy}.txt", true))
            {
                streamWriter.WriteLine(text);
            }
        }

        public void DeleteOldFile(string pathToLogFiles)
        {
            DateTime minFileDateTime = DateTime.Now;
            DateTime fileDateTime;
            string pathToOldFile = string.Empty;
            FileInfo fileToDelete;

            foreach (var pathToFile in Directory.GetFiles(pathToLogFiles))
            {
                if ((fileDateTime = File.GetCreationTime(pathToFile)) < minFileDateTime)
                {
                    minFileDateTime = fileDateTime;
                    pathToOldFile = pathToFile;
                }
            }

            fileToDelete = new FileInfo(pathToOldFile);

            if (fileToDelete.Exists)
            {
                fileToDelete.Delete();
            }
        }
    }
}
