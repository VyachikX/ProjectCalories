using System;

namespace ProjectCalories.Core.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message) { }
    }
}