using CarRentalManagement___DataAccessLayer.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement___DataAccessLayer.Repository.Context
{
    public class CarDBContext : DbContext
    {
        //public DbSet<UserDto> UserDtos { get; set; }
        //public DbSet<AdminDto> AdminDtos { get; set; }
        //public DbSet<CarDto> CarDtos { get; set; }
        //public DbSet<CarTypeDto> CarTypeDtos { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<IDProof> IDProofs { get; set; }
        //public DbSet<Condition> Conditions { get; set; }
        //public DbSet<Status> Statuses { get;set; }
        //public DbSet<Transmition> Transmitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var connectionString = configuration.GetConnectionString("CarDBContext");
            optionsBuilder.UseSqlServer(connectionString);

        }

    }
}
