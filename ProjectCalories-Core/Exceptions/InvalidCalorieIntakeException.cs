using System;

namespace ProjectCalories.Core.Exceptions
{
    public class InvalidCalorieIntakeException : Exception
    {
        public InvalidCalorieIntakeException(string message) : base(message) { }
    }
}