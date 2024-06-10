using System;

namespace ProjectCalories.Core.Exceptions
{
    public class MealPlanNotFoundException : Exception
    {
        public MealPlanNotFoundException(int userId) : base($"Meal plan for user {userId} not found.") { }
    }
}