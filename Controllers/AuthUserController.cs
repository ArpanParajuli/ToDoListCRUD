using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListCRUD.Repositories;
using ToDoListCRUD.Dtos;
using ToDoListCRUD.Services;

namespace ToDoListCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        private readonly IJwtService jwtService;
        public AuthUserController(IAuthRepository authRepository , IJwtService jwtService)
        {
            this.authRepository = authRepository;
            this.jwtService = jwtService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto obj, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var User = await authRepository.ValidateUser(obj, ct);


            if(User == null)
            {
                return BadRequest("Login invalid!");
            }

            else
            {
                var token =  jwtService.GenerateJwtToken(User);
                return Ok(new { token });
            }            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto obj , CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var User = await authRepository.RegisterUser(obj , ct);

            if (User == null)
            {
                return BadRequest("Register invalid!");
            }

            else
            {
                return Ok("Register done!");               
            }
            
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok("Logout done!");
        }



    }
}
