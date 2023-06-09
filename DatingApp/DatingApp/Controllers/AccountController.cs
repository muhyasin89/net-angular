using DatingApp.Data;
using DatingApp.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {

            var response = new ResponseUser
            {
                Message = "",
                Code = 0,
                user = null
            };

            if (await UserExists(registerDto!.Username)) 
            {
                response.Message = "Username is taken";
                response.Code = 400;
                return Ok(response);
            }

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto!.Password)),
                PasswordSalt = hmac.Key
            };

            response.Message = "User Record Successfully created";
            response.Code = 200;
            response.user = user;

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

           

            return Ok(response);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.AppUsers.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
