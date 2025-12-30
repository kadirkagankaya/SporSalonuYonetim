using Microsoft.AspNetCore.Mvc;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;
using SporSalonuYonetim.Core.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace SporSalonuYonetim.API.Controllers
{
    public class AuthController : CustomBaseController
    {
        private readonly IService<User> _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IService<User> userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userResponse = await _userService.FindAsync(x => x.Username == loginDto.Username);
            var user = userResponse.Data.FirstOrDefault();

            if (user == null || user.PasswordHash != loginDto.Password)
            {
                return CreateActionResult(ServiceResponse<NoContentDto>.FailResult("Kullanıcı adı veya şifre yanlış", 400));
            }

            var token = _tokenService.CreateToken(user);

            return CreateActionResult(ServiceResponse<TokenDto>.SuccessResult(token));
        }
    }
}
