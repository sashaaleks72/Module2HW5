using System;
using System.IO;
using System.Text;

namespace M2HW5
{
    public class FileService : IFileService
    {
        public FileService(IDirectoryConfigurationService directoryConfigurationService)
        {
            DirectoryConfigurationService = directoryConfigurationService;
        }

        public IDirectoryConfigurationService DirectoryConfigurationService { get; set; }

        public void WriteIntoFile(string text)
        {
            string pathToConfig = @"C:\\Users\\sasha\\source\\repos\\Module2HW5\\M2HW1\\Configs\directory-config.json";
            string directoryName = DirectoryConfigurationService.DeserializeDirectoryConfig(pathToConfig).DirectoryName;

            string[] fileNames = Directory.GetFiles(directoryName);

            if (fileNames.Length > 3)
            {
                string oldFile = fileNames[0];

                for (int i = 0; i < fileNames.Length; i++)
                {
                    if (File.GetCreationTime(oldFile) > File.GetCreationTime(fileNames[i]))
                    {
                        oldFile = fileNames[i];
                    }
                }

                File.Delete(oldFile);
            }

            using (StreamWriter streamWriter = new StreamWriter($@"{directoryName}\{DateTime.Now:HH.mm.ss dd.MM.yyyy}.txt", true, Encoding.UTF8))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}
