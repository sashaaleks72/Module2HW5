using System;

namespace M2HW5
{
    public class Logger : ILogger
    {
        public Logger(IFileService fileService, INotificationService notificationService)
        {
            FileService = fileService;
            NotificationService = notificationService;
        }

        public IFileService FileService { get; set; }
        public INotificationService NotificationService { get; set; }

        public void PrintLog(string log)
        {
            NotificationService.ShowMsg(log);
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
