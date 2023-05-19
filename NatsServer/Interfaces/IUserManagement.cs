using NatsServer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatsServer.Interfaces
{
    public interface IUserManagement
    {
        Task<UserDto> Signup(RequestDto requestDto);
        Task<UserDto?> Get(Guid Id);
    }
}
