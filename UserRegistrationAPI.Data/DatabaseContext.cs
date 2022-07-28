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

        }
    }
}
