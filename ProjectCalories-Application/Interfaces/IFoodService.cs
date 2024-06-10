using ProjectCalories.Core.DTOs;
using System.Collections.Generic;
using ProjectCalories.Core.Entities;

namespace ProjectCalories.Application.Interfaces
{

    public interface IFoodService
    {
        List<Food> GetAllFoods();
        FoodDTO GetFoodById(int foodId);
        void CreateFood(FoodDTO foodDTO);
        void CreateFoodM(FoodMDTO foodMDTO);
        void DeleteFood(int foodId);
        void UpdateFood(FoodDTO foodDTO);
    }

}