using Microsoft.EntityFrameworkCore;
using System;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "Vardenis",
                    Password = "P@ssword1",
                    Role = "User",
                    InfoSheetId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "Antanas",
                    Password = "P@ssword2",
                    Role = "User",
                    InfoSheetId = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4")
                });
            builder.Entity<InfoSheet>().HasData(
                new InfoSheet
                {
                    Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                    FirstName = "Vardenis",
                    LastName = "Pavarednis",
                    PersonalNumber = 38989521245,
                    Email = "vardenis@vardenis.lt",
                    AddressId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                },
                new InfoSheet
                {
                    Id = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"),
                    FirstName = "Antanas",
                    LastName = "Antanaitis",
                    PersonalNumber = 38989521245,
                    Email = "antanas@antanas.lt",
                    AddressId = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"),
                });
            builder.Entity<Address>().HasData(
                new Address
                {
                    Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                    City = "Vilnius",
                    Street = "Neries g.",
                    House = 10,
                    Apartanemt = 10
                },
                new Address
                {
                Id = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"),
                    City = "Kaunas",
                    Street = "Nemuno g.",
                    House = 20,
                    Apartanemt = 20
                });
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<InfoSheet> InfoSheets { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
