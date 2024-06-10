using System;

namespace ProjectCalories.Core.Exceptions
{
    public class FoodNotFoundException : Exception
    {
        public FoodNotFoundException(int userId) : base($"Meal plan for user {userId} not found.") { }
    }
}