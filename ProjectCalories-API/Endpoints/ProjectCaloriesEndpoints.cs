using ProjectCalories.Core.DTOs;
using ProjectCalories.Application.Interfaces;

namespace ProjectCalories.API.Endpoints
{
    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            // Пользователи
            app.MapGet("/api/users/{id}", (int id, IUserService userService) =>
            {
                var user = userService.GetUserById(id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            })
            .WithName("GetUserById");

            app.MapPost("/api/users", (UserDTO userDTO, IUserService userService) =>
            {
                userService.CreateUser(userDTO);
                return Results.Created($"/api/users/{userDTO.Id}", userDTO);
            })
            .WithName("CreateUser");

            app.MapDelete("/api/users/{id}", (int id, IUserService userService) =>
            {
                userService.DeleteUser(id);
                return Results.NoContent();
            })
            .WithName("DeleteUser");

            app.MapPut("/api/users/{id}", (int id, UserDTO userDTO, IUserService userService) =>
            {
                userService.UpdateUser(userDTO);
                return Results.Ok();
            })
            .WithName("UpdateUser");

            // Генерация плана питания
            app.MapGet("/api/users/{id}/mealplan", (int id, IMealPlanService mealPlanService) =>
            {
                var mealPlan = mealPlanService.GenerateMealPlan(id);
                return Results.Ok(mealPlan);
            })
            .WithName("GenerateMealPlan");

            // Продукты
            app.MapGet("/api/foods/{id}", (int id, IFoodService foodService) =>
            {
                var food = foodService.GetFoodById(id);
                if (food == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(food);
            })
            .WithName("GetFoodById");

            app.MapPost("/api/foods", (FoodDTO foodDTO, IFoodService foodCreationService) =>
            {
                foodCreationService.CreateFood(foodDTO);
                return Results.Created($"/api/foods/{foodDTO.Id}", foodDTO);
            })
            .WithName("CreateFood");

            app.MapPost("/api/foodsM", (FoodMDTO foodMDTO, IFoodService foodCreationService) =>
            {
                foodCreationService.CreateFoodM(foodMDTO);
                return Results.Created($"/api/foods/{foodMDTO.Id}", foodMDTO);
            })
            .WithName("CreateFoodM");

            app.MapDelete("/api/foods/{id}", (int id, IFoodService foodService) =>
            {
                foodService.DeleteFood(id);
                return Results.NoContent();
            })
            .WithName("DeleteFood");

            app.MapPut("/api/foods/{id}", (int id, FoodDTO foodDTO, IFoodService foodService) =>
            {
                foodService.UpdateFood(foodDTO);
                return Results.Ok();
            })
            .WithName("UpdateFood");

            app.MapGet("/api/foods", (IFoodService foodService) =>
            {
                var foods = foodService.GetAllFoods();
                return Results.Ok(foods);
            })
            .WithName("GetAllFoods");
        }
    }
}