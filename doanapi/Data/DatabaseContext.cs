﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;

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

        //For Authoright -- assign permission folow dashboard
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Dashboards> Dashboards { get; set; }
        public DbSet<UserDashboards> UserDashboards { get; set; }
        public DbSet<RoleDashboards> RoleDashboards { get; set; }
        public DbSet<Functions> Functions { get; set; }

        //Other database
        public DbSet<LoaiCongTrinh> ConstructionType { get; set; }
        public DbSet<CongTrinh> Construction { get; set; }
        public DbSet<ThongSoCongTrinh> ConstructionDetails { get; set; }
        public DbSet<DonViHC> DonViHC { get; set; }

        public DbSet<License> License { get; set; }
        public DbSet<LicenseType> LicenseType { get; set; }
        public DbSet<Organization> Organization { get; set; }

        #endregion
    }
}
