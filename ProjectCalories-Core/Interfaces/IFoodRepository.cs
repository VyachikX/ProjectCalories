using ProjectCalories.Core.Entities;
using System.Collections.Generic;

namespace ProjectCalories.Core.Interfaces
{
    public interface IFoodRepository
    {
        List<Food> GetAll();
        Food GetById(int foodId);
        void Update(Food food);
        void Delete(int foodId);
        bool Exists(int foodId); // Добавлено
        void Add(Food food); // Добавлено

    }
}