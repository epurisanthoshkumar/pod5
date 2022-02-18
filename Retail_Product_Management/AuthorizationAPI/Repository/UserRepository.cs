using AuthorizationAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AuthorizationAPI.Repository
{
    public class UserRepository:IUserRepository
    {
        
            private readonly Appsettings _appSettings;

            private readonly string Key;
            public UserRepository(string Key)
            {
                this.Key = Key;
            }
            public List<UserModel> userlist = new List<UserModel>() {
           new UserModel{ userid=1,password="123",username="Bharath"},
            new UserModel{ userid=2,password="123",username="Anupama"},
            new UserModel{ userid=3,password="123",username="Renuka"},
            new UserModel{ userid=4,password="123",username="Nancy"},
            new UserModel{ userid=5,password="123",username="Pranay"}
        };

            public UserRepository(IOptions<Appsettings> appSettings)
            {
                _appSettings = appSettings.Value;
            }

            UserModel IUserRepository.Authenticate(string UserName, string password)
            {
                var user = userlist.SingleOrDefault(x => x.username == UserName && x.password == password);
                if (user == null)
                {
                    return null;
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var k = "This is my jwt authentication demo";
                var key = Encoding.ASCII.GetBytes(k);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.UserData, user.username)
                }),
                    /* notBefore: DateTime.UtcNow,*/
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                user.password = "";
                return user;
            }

            bool IUserRepository.isUniqueUser(string UserName)
            {
                var user = userlist.SingleOrDefault(x => x.username == UserName);
                if (user == null)
                {
                    return true;
                }
                return false;
            }
            public UserModel UserDetails(string username)
            {

                foreach (var user in userlist)
                {
                    if (user.username == username)
                    {
                        return user;
                    }
                }
                return null;

            }

            Register IUserRepository.RegisterDetails(string userid, string username, string Email, string password, string address)
            {
                Register register = new Register()
                {
                    userid = Guid.NewGuid().ToString(),
                    username = username,
                    Email = Email,
                    password = password,
                    address = address
                };

                return register;



            }


        }
    }

