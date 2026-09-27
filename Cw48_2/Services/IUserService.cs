using Cw48_2.DTOS;
using Cw48_2.Models;

namespace Cw48_2.Services
{
    public interface IUserService
    {
        public bool IsPro(string email);
        public bool UserExists(string email);
        public bool UserExists(int id);
        public bool CanLog(string email, string passw);
        public void RegisterUser(RegisterUserDto user);
        public int IdByMail(string email);
        public UserDto? GetUser(int id);
        public List<UserDto> GetUsers();
        public void DelUser(string email);
    }
}
