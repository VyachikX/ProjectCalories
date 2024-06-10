using ProjectCalories.Core.DTOs; 

namespace ProjectCalories.Application.Interfaces 
{ 
    public interface IUserService
    {
        UserDTO GetUserById(int id);
        void CreateUser(UserDTO userDTO);
        void DeleteUser(int userId);
        void UpdateUser(UserDTO userDTO);
    }
}