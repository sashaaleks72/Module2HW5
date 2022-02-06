using System;

namespace M2HW5
{
    public class Actions : IActions
    {
        public Actions(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; set; }

        public bool WriteInfoLog()
        {
            Logger.WriteAndPrintLog($"{DateTime.Now}: Info: Start method: {nameof(WriteInfoLog)}");
            return true;
        }

        public bool GetBusinessException()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public bool GetException()
        {
            throw new Exception("I broke a logic");
        }
    }
}
