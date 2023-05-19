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
        UserDto Signup(RequestDto requestDto);
        UserDto Get(Guid Id);
    }
}
