using Microsoft.EntityFrameworkCore;

using ProjectCalories.API.Endpoints; //эндпоинты (файл с логикой путей)
using ProjectCalories.Application.Interfaces; //интерфейс сервисов
using ProjectCalories.Core.Interfaces; //интерфейс репозиториев
using ProjectCalories.Infrastructure.Repositories; //реализация репозиториев
using ProjectCalories.Application.Services; //реализация сервисов

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProjectCalories.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Подключение к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Регистрация сервисов
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IMealPlanService, MealPlanService>();

// Настройка Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectCalories API", Version = "v1" });
});

var app = builder.Build();

// Использование Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectCalories API v1"));
}

// Создание эндпоинтов
app.MapEndpoints();

app.Run();
