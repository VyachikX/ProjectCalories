
using ProjectCalories.Core.Entities;


namespace ProjectCalories.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int userId);
        void Add(User user);
        void Update(User user);
        void Delete(int userId);
    }
}