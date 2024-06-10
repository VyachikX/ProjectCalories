//конкретная реализация IFoodRepository 

using ProjectCalories.Core.Entities; //сущности Food
using ProjectCalories.Core.Interfaces; //интерфейсы репозиториев
using ProjectCalories.Infrastructure.Data; //контекст базы данных
using ProjectCalories.Core.Exceptions; //исключения

using Microsoft.EntityFrameworkCore;

namespace ProjectCalories.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository 
    {
        private readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //
        public void Add(Food food) 
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food), "Объект продукта не может быть пустым.");
            }

            try
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Ошибка при добавлении продукта в базу данных.", ex);
            }
        }
        //
        //
        public bool Exists(int foodId)
        {
            if (foodId <= 0)
            {
                throw new ArgumentException("ID продукта не может быть отрицательным или нулевым.", nameof(foodId));
            }

            return _context.Foods.Any(f => f.Id == foodId);
        }
        //
        public List<Food> GetAll()
        {
            return _context.Foods.ToList();
        }

        public Food GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID продукта не может быть отрицательным или нулевым.", nameof(id));
            }

            var food = _context.Foods.Find(id);

            if (food == null)
            {
                throw new FoodNotFoundException(id);
            }

            return food;
        }

        public void Update(Food food)
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food), "Объект продукта не может быть пустым.");
            }

            if (!_context.Foods.Any(f => f.Id == food.Id))
            {
                throw new FoodNotFoundException(food.Id);
            }

            try
            {
                _context.Entry(food).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Ошибка при обновлении продукта в базе данных.", ex);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID продукта не может быть отрицательным или нулевым.", nameof(id));
            }

            var food = _context.Foods.Find(id);

            if (food == null)
            {
                throw new FoodNotFoundException(id);
            }

            try
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Ошибка при удалении продукта из базы данных.", ex);
            }
        }
    }
}


