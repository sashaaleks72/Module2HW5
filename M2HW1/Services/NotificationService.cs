using System;

namespace M2HW5
{
    public class NotificationService : INotificationService
    {
        public void ShowMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
