using ProjectCalories.Core.DTOs;
using ProjectCalories.Core.Entities;
using ProjectCalories.Core.Exceptions;
using ProjectCalories.Application.Interfaces;
using ProjectCalories.Core.Interfaces;
using ProjectCalories.Core.ValueObjects;


namespace ProjectCalories.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Weight = user.Weight,
                Height = user.Height,
                Goal = (UserDTO.UserGoal)user.Goal,
                DailyCalorieIntake = user.DailyCalorieIntake
            };
        }

        public void CreateUser(UserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Age = userDTO.Age,
                Weight = userDTO.Weight,
                Height = userDTO.Height,
                Goal = (User.UserGoal)userDTO.Goal,
                DailyCalorieIntake = CaloriesRequirement.CalculateDailyCalorieIntake(userDTO)
            };

            _userRepository.Add(user);
        }

        // Удаление пользователя
        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }

        // Обновление пользователя
        public void UpdateUser(UserDTO userDTO)
        {
            var user = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Age = userDTO.Age,
                Weight = userDTO.Weight,
                Height = userDTO.Height,
                Goal = (User.UserGoal)userDTO.Goal,
                DailyCalorieIntake = CaloriesRequirement.CalculateDailyCalorieIntake(userDTO)
            };
            _userRepository.Update(user);
        }
    }
}