using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using NatsServer.Data;
using NatsServer.DTOs;
using NatsServer.Interfaces;

namespace NatsServer.Implementation
{
    public class UserManagement:IUserManagement
    {
        public async Task<UserDto> Signup(RequestDto requestDto)
        {
            var userdto = new UserDto()
            {
                
                Age = requestDto.Age,
                Name = requestDto.Name,
                PasswordHash = HashPassword(requestDto.Password)
                
            };

            using (var db = new DataBase())
            {
                

                db.Users.Add((userdto));

                await db.SaveChangesAsync();
            }


            return userdto;
        }

        public async Task<UserDto?> Get(Guid Id)
        {
            using (var db = new DataBase())
            {
              UserDto? user = await db.Users
                  .Where(x=>x.Id == Id)
                  .FirstOrDefaultAsync();

              Console.WriteLine(user.Name + ' ' + user.Age + ' ' + user.PasswordHash);

                return user;
            }

            
        }

        static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
