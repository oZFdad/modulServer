using System;

namespace Logic.Exceptions
{
    public class IncorrectRequestException : Exception
    {
        public IncorrectRequestException(string message):base(message)
        {
        }
    }
}