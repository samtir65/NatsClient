
using System.Runtime.InteropServices.JavaScript;
using NatsServer.Data;
using NatsServer.DTOs;
using NatsServer.Implementation;





var userManage = new UserManagement();

var user = await userManage.Get(new Guid("EDDFC991-DE3F-429C-DC7F-08DB58B99DD6"));

var c = 1;
    
