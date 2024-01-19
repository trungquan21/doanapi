using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;
using System.ComponentModel.Design;

namespace doanapi.Data
{
    public class DatabaseContext : IdentityDbContext<AspNetUsers, AspNetRoles, string>
    {
        private readonly IConfiguration configuration;
        public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        //
        #region DbSet

        //Other database
        public DbSet<ConstructionType> ConstructionType { get; set; }
        public DbSet<Construction> Construction { get; set; }
        public DbSet<ConstructionDetail> ConstructionDetails { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Commune> Commune { get; set; }

        public DbSet<License> License { get; set; }
        public DbSet<LicenseType> LicenseType { get; set; }
        public DbSet<LicenseFee> LicenseFee { get; set; }

        #endregion
    }
}
