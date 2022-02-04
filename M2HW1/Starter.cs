using System;

namespace M2HW5
{
    public class Starter
    {
        public Starter(ILogger logger, IActions actions)
        {
            Logger = logger;
            Actions = actions;
        }

        private ILogger Logger { get; set; }
        private IActions Actions { get; set; }

        public void Run()
        {
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
