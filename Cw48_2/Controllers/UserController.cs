using Cw48_2.Db;
using Cw48_2.DTOS;
using Cw48_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw48_2.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index(int id)
        {
            if (!_userService.UserExists(id))
            {
                return NotFound();
            }

            return View(_userService.GetUser(id));
        }
    }
}
