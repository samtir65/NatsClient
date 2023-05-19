using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NatsServer.DTOs;
using NatsServer.Interfaces;

namespace NatsServer.Implementation
{
    public class UserManagement:IUserManagement
    {
        public UserDto Signup(RequestDto requestDto)
        {
            var userdto = new UserDto()
            {
                Age = requestDto.Age,
                Name = requestDto.Name,
                PasswordHash = HashPassword(requestDto.Password)

            };
            return userdto;
        }

        public UserDto Get(Guid Id)
        {
            throw new NotImplementedException();
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
