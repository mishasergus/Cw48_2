using Cw48_2.Db;
using Cw48_2.DTOS;
using Cw48_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw48_2.Services
{
    public class UserService : IUserService
    {
        private int _nextId = 0;
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool IsPro(string email)
        {
            var u = _dbContext.Users.FirstOrDefault(objUser => objUser.email == email);
            if (u != null)
            {
                return u.Role == "Pro";
            }
            throw new Exception("Not found");
        }
        public bool UserExists(string email)
        {
            return _dbContext.Users.FirstOrDefault(objUser => objUser.email == email) != null;
        }
        public bool UserExists(int id)
        {
            return _dbContext.Users.FirstOrDefault(objUser => objUser.id == id) != null;
        }
        public bool CanLog(string email, string passw)
        {
            return _dbContext.Users.FirstOrDefault(objUser => objUser.email == email && objUser.password == passw) != null;
        }

        public void RegisterUser(RegisterUserDto objDto)
        {
            var user = new UserEntity
            {
                id = _nextId++,
                name = objDto.Name,
                email = objDto.Email,
                password = objDto.Password,
                Role = objDto.Role
            };


            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public int IdByMail(string email)
        {
            var u = _dbContext.Users.FirstOrDefault(objUser => objUser.email == email);
            if (u != null)
            {
                return u.id;
            }
            return 0;
        }

        public UserDto? GetUser(int id)
        {
            var u = _dbContext.Users.FirstOrDefault(objUser => objUser.id == id);
            return new UserDto()
            {
                Name = u.name,
                Email = u.email,
                Role = u.Role
            };
        }
        public List<UserDto> GetUsers()
        {
            var users = new List<UserDto>();
            foreach (var user in _dbContext.Users)
            {
                users.Add(new UserDto()
                {
                    Name = user.name,
                    Email = user.email,
                    Role = user.Role
                });
            }
            return users;
        }
        public void DelUser(string email)
        {
            var u = _dbContext.Users.FirstOrDefault(us => us.email == email);
            if (u != null)
            {
                _dbContext.Users.Remove(u);
                _dbContext.SaveChanges();
            }
        }
    }
}
