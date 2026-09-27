using Cw48_2.Models;
using Cw48_2.Services;
using Cw48_2.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Cw48_2.Controllers
{
    public class AccountController : Controller
    {
        readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserDto objDto)
        {
            bool isUserExist = _userService.UserExists(objDto.Email);
            if (isUserExist)
            {
                return View(objDto);
            }

            _userService.RegisterUser(objDto);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto obj)
        {
            bool canLog = _userService.CanLog(obj.Email, obj.Password);
            bool isPro = _userService.IsPro(obj.Email);
            if (!canLog)
            {
                return View();
            }

            if (isPro)
            {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "User", new { id = _userService.IdByMail(obj.Email) });
        }
    }
}
