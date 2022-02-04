using System;

namespace M2HW5
{
    public class Logger : ILogger
    {
        public Logger(IFileService fileService)
        {
            FileService = fileService;
        }

        public IFileService FileService { get; set; }

        public void PrintLog(string log)
        {
            Console.WriteLine(log);
        }

        public void WriteLogIntoFile(string log)
        {
            FileService.WriteIntoFile(log);
        }

        public void WriteAndPrintLog(string log)
        {
            PrintLog(log);
            WriteLogIntoFile(log);
        }
    }
}
