//конкретная реализация интерфейса IUserRepository 

using ProjectCalories.Core.Entities; //сущность User
using ProjectCalories.Core.Interfaces; //интерфейс репозиториев
using ProjectCalories.Infrastructure.Data; //контекст базы данных
using ProjectCalories.Core.Exceptions; //исключения

using Microsoft.EntityFrameworkCore;

namespace ProjectCalories.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository 
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID пользователя не может быть отрицательным или нулевым.", nameof(id));
            }

            var user = _context.Users.Find(id);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            return user;
        }

        public void Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Объект пользователя не может быть пустым.");
            }

            _context.Users.Add(user);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Ошибка при добавлении пользователя в базу данных.", ex);
            }
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Объект пользователя не может быть пустым.");
            }

            if (!_context.Users.Any(u => u.Id == user.Id))
            {
                throw new UserNotFoundException(user.Id);
            }

            try
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Ошибка при обновлении пользователя в базе данных.", ex);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID пользователя не может быть отрицательным или нулевым.", nameof(id));
            }

            var user = _context.Users.Find(id);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Ошибка при удалении пользователя из базы данных.", ex);
            }
        }
    }
}


