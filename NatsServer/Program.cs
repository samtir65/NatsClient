
using NatsServer.DTOs;
using NatsServer.Implementation;

while (true)
{
    var menuItems = new[] { "Sign Up", "Get User Info By Guid", "Exit" };
    for (int i = 0; i < menuItems.Length; i++)
    {
        Console.WriteLine($"{i + 1}- {menuItems[i]}");
    }

    var choice = GetInput("Enter your choice: ");

    bool isExit = false;
    switch (choice)
    {
        case "1" :
           await Register();
            break;
        case "2":
            //GetInput("Enter your GuId: ");
           await GuId();
            break;

        case "3":
            isExit = true;
            break;
           
        default:

            Console.WriteLine("Bad Data");
            break;
    }

    if (isExit == true)
    {
        break;
    }
    
}


static string GetInput(string message)
{
    Console.Write(message);
    return Console.ReadLine();
}


static async Task<UserDto> Register()
{
    int age;
    string name;
    string password;
    Console.WriteLine("enter your age");
    age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("enter your name");
    name = Console.ReadLine();
    Console.WriteLine("enter your name");
    password = Console.ReadLine();
    UserManagement ueserManagement = new();

    UserDto user = await ueserManagement.Signup(new RequestDto(age, name, password));
    return user;
}

static async Task<UserDto> GuId()
{
    Guid id;
    Console.WriteLine("enter your Guid");
    id = new Guid(Console.ReadLine());
    UserManagement userManagement = new();
    UserDto user = await userManagement.Get(id);

    return user;

}



//UserManagement management = new();
// await management.Signup(new RequestDto()
//{
//    Age = 12,
//    Name = "ali",
//    Password = "1234"
//});

//UserDto user = await  management.Get(new Guid("C72DFD0D-E619-45C0-F12E-08DB59E3F245"));
//Console.WriteLine(user.Name + ' '+user.Age + ' ' +user.PasswordHash);


