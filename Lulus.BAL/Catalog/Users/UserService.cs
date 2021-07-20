
using Lulus.BAL.Catalog.Users.Interfaces;
using Lulus.Data.Entities;
using Lulus.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        // Identity libaries
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<string> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return "Wrong username";
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            if (!result.Succeeded) return "Wrong password";

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.PrimarySid, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Customer_FirstName),
                new Claim(ClaimTypes.Name, user.Customer_LastName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                _configuration["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> AdminLogin(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return "Wrong username";
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            if (!result.Succeeded) return "Wrong password";

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.PrimarySid, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Customer_FirstName),
                new Claim(ClaimTypes.Name, user.Customer_LastName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                _configuration["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new User()
            {
                UserName = request.Username,
                Email = request.Email,
                Customer_FirstName = request.FirstName,
                Customer_LastName = request.LastName,

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
