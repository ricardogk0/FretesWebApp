using FretesWebApplication.Interface;
using Microsoft.AspNetCore.Mvc;
using FretesWebApplication.Models;
using FretesWebApplication.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace FretesWebApplication.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario model)
        {
            var username = model.Nome;
            var password = model.Senha;

            if (_authenticationService.UserAuthentication(username, password))
            {
                var tokenJwt = GerarTokenJwt(username);
                return Ok(new { Token = tokenJwt });
            }

            return Unauthorized("Usuário ou senha inválidos.");
        }


        private string GerarTokenJwt(string username, SymmetricSecurityKey symmetricSecurityKey)
        {
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)

            };

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "MinhaAplicacaoLocal",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

