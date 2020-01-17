using Api.Interface;
using Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly User _user;


        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

        }

        public User Authenticate(User user)
        {
            var auth = (user.Get(user));
            

            if (auth == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier.ToString(), auth.Id.ToString()),
                    new Claim(ClaimTypes.Name.ToString(), auth.Id.ToString()),
                    //new Claim(ClaimTypes.Authentication, auth.Entity.Id.ToString()),
                    //new Claim(ClaimTypes.Name, auth.Entity.i)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            auth.Token = tokenHandler.WriteToken(token);
            auth = auth.WithoutPassword();
            return auth;
        }

        public IEnumerable<User> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _user.GetAll(pageIndex, pageSize);
        }

        public User GetUser(int id)
        {
            User user = new User();
            return user.Get(id);
        }

        public User Create(User user)
        {
            return user.Create(user);
        }
    }
}
