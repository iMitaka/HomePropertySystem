using System.Threading.Tasks;
using HomePropertySystem.DataTransferModels.User;
using HomePropertySystem.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomePropertySystem.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            IUserService userService
           )
        {
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm]UserLoginPostModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.LoginUser(model);

                if (!result.Error)
                {
                    return Ok(result.DataResult);
                }

                return BadRequest(result.ErrorMessage);
            }

            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm]UserRegisterPostModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.RegisterUser(model, User.Identity.Name);

                if (!result.Error)
                {
                    return Ok(result);
                }

                return BadRequest(result.ErrorMessage);
            }

            return BadRequest();
        }
    }
}
