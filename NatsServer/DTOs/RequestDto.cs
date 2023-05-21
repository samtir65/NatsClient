﻿using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatsServer.DTOs
{
    public class RequestDto
    {
       
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public RequestDto(int age,string name,string password)
        {
            this.Age = age;
            this.Name = name;
            this.Password = password;
        }
    }
}
