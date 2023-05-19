
using System.Runtime.InteropServices.JavaScript;
using NatsServer.DTOs;
using NatsServer.Implementation;

UserManagement userManagement = new UserManagement();

UserDto userDto = userManagement.Signup(new RequestDto()
{
    Age = 37,
    Name = "mohammad",
    Password = "sam123"

});


Console.WriteLine(userDto.Name+ ' '+userDto.Age+ ' '+userDto.PasswordHash);

