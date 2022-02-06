using System;

namespace M2HW5
{
    public class Starter
    {
        public Starter(ILogger logger, IActions actions, IDirectoryConfigurationService directoryConfigurationService)
        {
            Logger = logger;
            Actions = actions;
            DirectoryConfigurationService = directoryConfigurationService;
        }

        private ILogger Logger { get; set; }
        private IActions Actions { get; set; }
        private IDirectoryConfigurationService DirectoryConfigurationService { get; set; }

        public void Run()
        {
            string nameOfLogsFolder = "Logs";
            string pathToJsonConfig = @"C:\Users\sasha\source\repos\Module2HW5\M2HW1\Configs\directory-config.json";
            DirectoryConfig directoryConfig = new DirectoryConfig($@"C:\Users\sasha\source\repos\Module2HW5\M2HW1\{nameOfLogsFolder}");

            DirectoryConfigurationService.SerializeDirectoryConfig(directoryConfig, pathToJsonConfig);

            int randomValue = 0;

            for (int i = 0; i < 100; i++)
            {
                randomValue = new Random().Next(1, 4);

                switch (randomValue)
                {
                    case 1:
                        Actions.WriteInfoLog();
                        break;
                    case 2:
                        try
                        {
                            Actions.GetBusinessException();
                        }
                        catch (BusinessException ex)
                        {
                            Logger.WriteAndPrintLog($"{DateTime.Now}: Error: Action failed by reason: {ex}");
                        }

                        break;
                    case 3:
                        try
                        {
                            Actions.GetException();
                        }
                        catch (Exception ex)
                        {
                            Logger.WriteAndPrintLog($"{DateTime.Now}: Warning: Action got this custom Exception: {ex.Message}");
                        }

                        break;
                }
            }
        }
    }
}
