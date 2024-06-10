using ProjectCalories.Core.DTOs; //дитиошки
using ProjectCalories.Core.Entities; //сущности
using ProjectCalories.Core.Interfaces; //интерфейсы репозиториев
using ProjectCalories.Core.Exceptions; //исключения
using ProjectCalories.Application.Interfaces; //интерфейсы сервисов
using System.Collections.Generic;
using System;
using ProjectCalories.Core.ValueObjects;

namespace ProjectCalories.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public List<Food> GetAllFoods()
        {
            return _foodRepository.GetAll(); // Получение всех продуктов из репозитория
        }

        // Получение продукта по ID
        public FoodDTO GetFoodById(int foodId)
        {
            var food = _foodRepository.GetById(foodId);

            if (food == null)
            {
                throw new BaseException(foodId.ToString());
            }

            return new FoodDTO
            {
                Id = food.Id,
                Name = food.Name,
                Calories = food.Calories
            };
        }

        // Удаление продукта
        public void DeleteFood(int foodId)
        {
            if (!_foodRepository.Exists(foodId))
            {
                throw new FoodNotFoundException(foodId); 
            }

            _foodRepository.Delete(foodId);
        }

        // Обновление продукта
        public void UpdateFood(FoodDTO foodDTO)
        {
            if (!_foodRepository.Exists(foodDTO.Id))
            {
                throw new FoodNotFoundException(foodDTO.Id);
            }

            var food = new Food
            {
                Id = foodDTO.Id,
                Name = foodDTO.Name,
                Calories = foodDTO.Calories
            };
            _foodRepository.Update(food);
        }

        // Создание продукта
        public void CreateFood(FoodDTO foodDTO)
        {
            // Проверка на пустоту входных данных
            if (string.IsNullOrWhiteSpace(foodDTO.Name))
            {
                throw new ArgumentException("Название продукта не может быть пустым.", nameof(foodDTO.Name));
            }

            if (foodDTO.Calories <= 0)
            {
                throw new ArgumentException("Калорийность продукта должна быть больше нуля.", nameof(foodDTO.Calories));
            }

            // Создание объекта Food из FoodDTO
            var food = new Food
            {
                Id = foodDTO.Id,
                Name = foodDTO.Name,
                Calories = foodDTO.Calories
            };

            // Сохранение продукта в репозиторий
            _foodRepository.Add(food); 
        }

        // Создание продукта, используя знания о его БЖУ
        public void CreateFoodM(FoodMDTO foodMDTO)
        {
            // Проверка на пустоту входных данных
            if (string.IsNullOrWhiteSpace(foodMDTO.Name))
            {
                throw new ArgumentException("Название продукта не может быть пустым.", nameof(foodMDTO.Name));
            }

            // Создание объекта Food из FoodMDTO
            var food = new Food
            {
                Id = foodMDTO.Id,
                Name = foodMDTO.Name,
                Calories = CaloriesRequirement.CalculateCaloriesFromMacros(foodMDTO) // Добавил
            };

            // Сохранение продукта в репозиторий
            _foodRepository.Add(food); 
        }
    }
}

