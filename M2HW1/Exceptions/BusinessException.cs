using System;

namespace M2HW5
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg)
        {
            Message = msg;
        }

        public override string Message { get; }
    }
}
