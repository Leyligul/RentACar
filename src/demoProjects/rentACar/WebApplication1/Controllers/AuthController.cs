using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {


        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.Accesstoken);
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new()
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress()
            };

            LoggedDto result = await Mediator.Send(loginCommand);

            if(result.RefreshToken is not null)  setRefreshTokenToCookie(result.RefreshToken);
           
            return Ok(result.Accesstoken);

        }

        private void setRefreshTokenToCookie (RefreshTokenDto refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(1)
            };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
