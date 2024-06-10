using ProjectCalories.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace ProjectCalories.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Foods.Any())
            {
                return; // DB has been seeded
            }

            var foods = new List<Food>
            {
                new Food { Name = "Apple", Calories = 52 },
                new Food { Name = "Banana", Calories = 89 },
                new Food { Name = "Chicken Breast", Calories = 165 }
            };

            context.Foods.AddRange(foods);
            context.SaveChanges();
        }
    }
}