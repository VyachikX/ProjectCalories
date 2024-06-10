using System;

namespace ProjectCalories.Core.Exceptions
{
    public class InvalidUserGoalException : Exception
    {
        public InvalidUserGoalException(string message) : base(message) { }
    }
}