using System.Collections.Generic;

namespace ProjectCalories.Core.DTOs
{
    public class MealPlanDTO
    {
        public int UserId { get; set; }
        public List<FoodDTO> Foods { get; set; } = new List<FoodDTO>();
    }
}