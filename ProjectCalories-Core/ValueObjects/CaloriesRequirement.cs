using ProjectCalories.Core.DTOs;
using ProjectCalories.Core.Entities;

namespace ProjectCalories.Core.ValueObjects 
{ 
    public class CaloriesRequirement 
    { 
        public static int CalculateDailyCalorieIntake(UserDTO user) 
        { 
            // Simplified Basal Metabolic Rate (BMR) calculation 
            double bmr = 10 * user.Weight + 6.25 * user.Height - 5 * user.Age + 5; 
 
            // Adjust based on goal using switch statement 
            switch (user.Goal) 
            { 
                case UserDTO.UserGoal.LoseWeight: 
                    return (int)(bmr * 0.8); // 20% calorie deficit 
                case UserDTO.UserGoal.GainWeight: 
                    return (int)(bmr * 1.2); // 20% calorie surplus 
                case UserDTO.UserGoal.MaintainWeight: 
                    return (int)bmr; // Maintenance 
                default: 
                    return (int)bmr; // Default to maintenance 
            } 
        } 

        // Метод для получения калорий из белков, жиров и углеводов
        public static int CalculateCaloriesFromMacros(FoodMDTO foodM)
        {
            // Калории из белков
            int proteinCalories = (int)(foodM.ProteinGrams * 4);

            // Калории из жиров
            int fatCalories = (int)(foodM.FatGrams * 9);

            // Калории из углеводов
            int carbohydrateCalories = (int)(foodM.CarbohydrateGrams * 4);

            // Общее количество калорий
            return proteinCalories + fatCalories + carbohydrateCalories;
        }
    } 
}