using System;

namespace Common.Exceptions
{
    public class BancoBuilesException : Exception
    {
        public string Code { get; }

        public BancoBuilesException(string message) : base(message)
        {
        }

        public BancoBuilesException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
