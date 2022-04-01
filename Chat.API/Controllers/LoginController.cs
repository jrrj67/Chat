using Chat.API.Models.Requests;
using Chat.API.Repositories;
using Chat.API.Services.TokenService;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<string> Authenticate([FromBody] LoginRequest request)
        {
            var user = UserRepository.Get(request.Username, request.Password);

            if (user == null) return NotFound();

            return _tokenService.GenerateToken(user);
        }
    }
}
