using System.Collections.Generic;

namespace ProjectCalories.Core.Entities

{
    public class MealPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Food> Foods { get; set; } = new List<Food>();
    }
}