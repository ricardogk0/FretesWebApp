using FretesWebApplication.Interface;
using FretesWebApplication.Controllers;
using FretesWebApplication.Data;
using System.Security.Cryptography;
using FretesWebApplication.Models;
using BCrypt.Net;

namespace FretesWebApplication.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly FretesWebApplicationContext _context;

        public AuthenticationService(FretesWebApplicationContext context)
        {
            _context = context;
        }

        public bool UserAuthentication(string username, string password)
        {
            var user = _context.Usuario.FirstOrDefault(u => u.Nome == username);
            if(user != null)
            {
                bool passwordVerify = BCrypt.Net.BCrypt.Verify(password, user.Senha);
                return passwordVerify;
            }

            return false;
        }


    }
}
