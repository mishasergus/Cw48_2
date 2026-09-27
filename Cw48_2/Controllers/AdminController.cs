using Cw48_2.DTOS;
using Cw48_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw48_2.Controllers
{
    public class AdminController : Controller
    {
        readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            return View(users);
        }

        [HttpPost]
        public IActionResult CreateUser(RegisterUserDto objDto)
        {
            bool isUserExist = _userService.UserExists(objDto.Email);
            if (isUserExist)
            {
                return RedirectToAction("Index");
            }

            _userService.RegisterUser(objDto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DelUser(string email)
        {
            bool isUserExist = _userService.UserExists(email);
            if (!isUserExist)
            {
                return RedirectToAction("Index");
            }

            _userService.DelUser(email);

            return RedirectToAction("Index");
        }
    }
}
