using ProjectCalories.Core.DTOs;

namespace ProjectCalories.Application.Interfaces
{
    public interface IMealPlanService
    {
        MealPlanDTO GenerateMealPlan(int userId);
    }
}
