using System;

namespace ProjectCalories.Core.Exceptions
{
    public class InvalidFoodException : Exception
    {
        public InvalidFoodException(string message) : base(message) { }
    }
}