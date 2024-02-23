using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        DataContext db;

        public AuthController(IAuthService authService, DataContext db)
        {
            this.authService = authService;
            this.db = db;
        }

        [HttpPost("LoginUser")]
        public  async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            var result= await authService.LoginUserAsync(request);
            return result;
        }

        [HttpPost("Register")]
        public IActionResult RegisterAsync([FromBody] UserRequest request)
        { 
            User newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password 
            };

            var user=db.User.FirstOrDefault(x => x.Password == request.Password && x.UserName==request.UserName);

            if (user==null) {
                db.User.Add(newUser);
                db.SaveChanges();
                return Ok(newUser);
               
            }

            return BadRequest();

        }

    }
}
