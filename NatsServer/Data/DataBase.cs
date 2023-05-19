using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NatsServer.DTOs;

namespace NatsServer.Data
{
    public class DataBase:DbContext
    {

        public DbSet<UserDto> Users { get; set; }

        public DataBase()
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NatsServerDb;Integrated Security=True;Trust Server Certificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
