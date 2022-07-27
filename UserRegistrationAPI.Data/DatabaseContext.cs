using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserRegistrationAPI.Data.Configurations.Entities;
using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<DataSheet> DataSheets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ImageObject> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(builder);

            //builder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        //Password = "P@ssword1",
            //        DataSheetId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482").ToString()
            //    },
            //    new User
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        //Password = "P@ssword2",
            //        DataSheetId = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4").ToString()
            //    });
            //builder.Entity<DataSheet>().HasData(
            //    new DataSheet
            //    {
            //        Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482").ToString(),
            //        FirstName = "Vardenis",
            //        LastName = "Pavarednis",
            //        IdentificationNumber = "38989521245",
            //        AddressId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482").ToString()
            //    },
            //    new DataSheet
            //    {
            //        Id = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4").ToString(),
            //        FirstName = "Antanas",
            //        LastName = "Antanaitis",
            //        IdentificationNumber = "38989521245",
            //        AddressId = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4").ToString()
            //    });
            //builder.Entity<Address>().HasData(
            //    new Address
            //    {
            //        Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482").ToString(),
            //        City = "Vilnius",
            //        Street = "Neries g.",
            //        House = 10,
            //        Apartament = 10
            //    },
            //    new Address
            //    {
            //        Id = new Guid("083a8133-231d-4028-a878-b365ba2f9eb4").ToString(),
            //        City = "Kaunas",
            //        Street = "Nemuno g.",
            //        House = 20,
            //        Apartament = 20
            //    });
        }
    }
}
