namespace M2HW5
{
    public interface ILogger
    {
        public void PrintLog(string log);
        public void WriteLogIntoFile(string log);
        public void WriteAndPrintLog(string log);
    }
}
