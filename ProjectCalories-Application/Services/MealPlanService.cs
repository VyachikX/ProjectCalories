using ProjectCalories.Core.Entities;
using ProjectCalories.Core.Exceptions;
using ProjectCalories.Application.Interfaces;
using ProjectCalories.Core.DTOs;
using ProjectCalories.Core.Interfaces;

namespace ProjectCalories.Application.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodRepository _foodRepository;

        public MealPlanService(IUserRepository userRepository, IFoodRepository foodRepository)
        {
            _userRepository = userRepository;
            _foodRepository = foodRepository;
        }

        public MealPlanDTO GenerateMealPlan(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            var foods = _foodRepository.GetAll();

            // Сортируем продукты по калорийности
            foods = foods.OrderBy(f => f.Calories).ToList();

            // Создаем пустой список для рациона
            var mealPlanFoods = new List<Food>();

            // Добавляем продукты в рацион до тех пор, пока не достигнем требуемого количества калорий
            var currentCalories = 0;
            foreach (var food in foods)
            {
                if (currentCalories + food.Calories <= user.DailyCalorieIntake)
                {
                    mealPlanFoods.Add(food);
                    currentCalories += food.Calories;
                }
                else
                {
                    break;
                }
            }

            var mealPlan = new MealPlan
            {
                UserId = user.Id,
                Foods = mealPlanFoods
            };

            return new MealPlanDTO
            {
                UserId = mealPlan.UserId,
                Foods = mealPlan.Foods.Select(f => new FoodDTO
                {
                    Id = f.Id,
                    Name = f.Name,
                    Calories = f.Calories
                }).ToList()
            };
        }
    }
}