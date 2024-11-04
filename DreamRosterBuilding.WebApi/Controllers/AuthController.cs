using DreamRosterBuilding.Business.Operations.User;
using DreamRosterBuilding.Business.Operations.User.Dtos;
using DreamRosterBuilding.WebApi.Filters;
using DreamRosterBuilding.WebApi.Jwt;
using DreamRosterBuilding.WebApi.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = DreamRosterBuilding.WebApi.Models.Auth.LoginRequest;
using RegisterRequest = DreamRosterBuilding.WebApi.Models.Auth.RegisterRequest;

namespace DreamRosterBuilding.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService; // -> Using User Service with dependency injection in ctor

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        #region Register - HttpPost
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest) // -> RegisterRequest is also defined Microsoft.Identity but I used mine 'Models.RegisterRequest'
        {
            if (!ModelState.IsValid) // -> Checking model states that I defined in Models.RegisterRequest
            {
                return BadRequest(ModelState);
            }

            var addUserDto = new AddUserDto // -> Single Responsibility! For transfering request data to my service I used data transfer object that I define in Service-Operation-OperationName-Dtos
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Birthdate = registerRequest.Birthdate,
            };

            var serviceResult = await _userService.AddUser(addUserDto); // -> Calling service add method that return ServiceMessage(isSucceed,message,Data?(if necessary)) object

            if (serviceResult.IsSucceed)
            {
                return Ok();
            }
            else
            {
                return BadRequest(serviceResult.Message);
            }
        }
        #endregion

        #region Login - HttpPost
        [HttpPost("login")]
        [TimeControlFilter] // -> I created ActionFilter onexecuting you can check in 'Filters' folder
        public async Task<IActionResult> Login (LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) // -> Checking model states that I defined in Models.LoginRequest
            {
                return BadRequest(ModelState);
            }

            var serviceResult =await _userService.LoginUser(new LoginUserDto { Email=loginRequest.Email, Password=loginRequest.Password}); // -> request to dto

            if(serviceResult.IsSucceed is false)
            {
                return BadRequest(serviceResult.Message);
            }

            var user = serviceResult.Data; // -> getting logined user data

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>(); // -> property dependency injection if I need everwhere I use ctor injection but only need here so propery injection

            // ▼ Creating token with JwtHelper ▼
            var token = JwtHelper.GenerateToken(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserRole = user.UserRole,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer= configuration["Jwt:Issuer"]!,
                Audience= configuration["Jwt:Audience"]!,
                ExpireMinutes= int.Parse(configuration["Jwt:ExpireMinutes"]!)
            });

            return Ok(new LoginResponse { Message="Login is successfull",Token=token}); // -> I created LoginResponse for sending message and token
        }
        #endregion

        // ▼ For testing token autherization ▼ 
        [HttpGet("MyProfile/{id:int:min(1)}")]
        [Authorize] // -> Authorize with token
        public IActionResult GetMyProfile(int id)
        {
            var user = _userService.GetUser(id);
            return Ok(user);
        }
    }
}
