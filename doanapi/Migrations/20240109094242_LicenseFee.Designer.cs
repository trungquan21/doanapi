﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using doanapi.Data;

#nullable disable

namespace doanapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240109094242_LicenseFee")]
    partial class LicenseFee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("doanapi.Data.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("doanapi.Data.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("doanapi.Data.Commune", b =>
                {
                    b.Property<int>("CommuneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommuneId"));

                    b.Property<string>("AdministrativeLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommuneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.HasKey("CommuneId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Commune");
                });

            modelBuilder.Entity("doanapi.Data.Construction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CommuneId")
                        .HasColumnType("int");

                    b.Property<string>("ConstructionLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConstructionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConstructionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("EditAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RepairTime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("X")
                        .HasColumnType("float");

                    b.Property<double?>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CommuneId");

                    b.HasIndex("ConstructionTypeId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Construction");
                });

            modelBuilder.Entity("doanapi.Data.ConstructionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AmountRain")
                        .HasColumnType("float");

                    b.Property<double>("BasinArea")
                        .HasColumnType("float");

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<int>("ConstructionLevel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<double>("Depth")
                        .HasColumnType("float");

                    b.Property<string>("DischargeLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EditAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ExplorationArea")
                        .HasColumnType("float");

                    b.Property<string>("ExplorationScale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Flow")
                        .HasColumnType("float");

                    b.Property<int?>("IdConstruction")
                        .HasColumnType("int");

                    b.Property<double>("IrrigatedArea")
                        .HasColumnType("float");

                    b.Property<double>("KF")
                        .HasColumnType("float");

                    b.Property<double>("KQ")
                        .HasColumnType("float");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NumberWell")
                        .HasColumnType("float");

                    b.Property<int>("PumpNumber")
                        .HasColumnType("int");

                    b.Property<string>("Purposes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RepairTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartDate")
                        .HasColumnType("int");

                    b.Property<double>("WaterLevel")
                        .HasColumnType("float");

                    b.Property<string>("Watersource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Wattage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdConstruction")
                        .IsUnique()
                        .HasFilter("[IdConstruction] IS NOT NULL");

                    b.ToTable("ConstructionDetails");
                });

            modelBuilder.Entity("doanapi.Data.ConstructionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConstructionTypeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EditAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdParent")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RepairTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConstructionType");
                });

            modelBuilder.Entity("doanapi.Data.Dashboards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PermitAccess")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("doanapi.Data.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictId"));

                    b.Property<string>("DistrictName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DistrictId");

                    b.ToTable("District");
                });

            modelBuilder.Entity("doanapi.Data.Functions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("doanapi.Data.License", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConstructionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EditAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileDocument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePermission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LicenseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("LicensingAuthorities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RepairTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Revoked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SignDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Signer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionId");

                    b.HasIndex("LicenseTypeId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("License");
                });

            modelBuilder.Entity("doanapi.Data.LicenseFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DecisionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EditAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePDF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LicenseId")
                        .HasColumnType("int");

                    b.Property<string>("LicensingAuthorities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RepairTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SignDay")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.ToTable("LicenseFee");
                });

            modelBuilder.Entity("doanapi.Data.LicenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EditAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseTypeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RepairTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LicenseType");
                });

            modelBuilder.Entity("doanapi.Data.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorizedPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EditAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalRepresentation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RepairTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("doanapi.Data.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DashboardId")
                        .HasColumnType("int");

                    b.Property<string>("FunctionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FunctionId")
                        .HasColumnType("int");

                    b.Property<string>("FunctionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("doanapi.Data.RoleDashboards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DashboardId")
                        .HasColumnType("int");

                    b.Property<string>("FileControl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PermitAccess")
                        .HasColumnType("bit");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleDashboards");
                });

            modelBuilder.Entity("doanapi.Data.UserDashboards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DashboardId")
                        .HasColumnType("int");

                    b.Property<string>("FileControl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PermitAccess")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDashboards");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("doanapi.Data.AspNetRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("doanapi.Data.AspNetUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("doanapi.Data.AspNetUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("doanapi.Data.AspNetRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("doanapi.Data.AspNetUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("doanapi.Data.AspNetUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("doanapi.Data.Commune", b =>
                {
                    b.HasOne("doanapi.Data.District", "District")
                        .WithMany("Communes")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("doanapi.Data.Construction", b =>
                {
                    b.HasOne("doanapi.Data.Commune", "Commune")
                        .WithMany()
                        .HasForeignKey("CommuneId");

                    b.HasOne("doanapi.Data.ConstructionType", "ConstructionType")
                        .WithMany("CongTrinh")
                        .HasForeignKey("ConstructionTypeId");

                    b.HasOne("doanapi.Data.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.Navigation("Commune");

                    b.Navigation("ConstructionType");

                    b.Navigation("District");
                });

            modelBuilder.Entity("doanapi.Data.ConstructionDetail", b =>
                {
                    b.HasOne("doanapi.Data.Construction", "Construction")
                        .WithOne("ConstructionDetails")
                        .HasForeignKey("doanapi.Data.ConstructionDetail", "IdConstruction");

                    b.Navigation("Construction");
                });

            modelBuilder.Entity("doanapi.Data.License", b =>
                {
                    b.HasOne("doanapi.Data.Construction", "Construction")
                        .WithMany("License")
                        .HasForeignKey("ConstructionId");

                    b.HasOne("doanapi.Data.LicenseType", "LicenseType")
                        .WithMany("License")
                        .HasForeignKey("LicenseTypeId");

                    b.HasOne("doanapi.Data.Organization", "Organization")
                        .WithMany("License")
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Construction");

                    b.Navigation("LicenseType");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("doanapi.Data.LicenseFee", b =>
                {
                    b.HasOne("doanapi.Data.License", "Licenses")
                        .WithMany("LicenseFee")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Licenses");
                });

            modelBuilder.Entity("doanapi.Data.Construction", b =>
                {
                    b.Navigation("ConstructionDetails");

                    b.Navigation("License");
                });

            modelBuilder.Entity("doanapi.Data.ConstructionType", b =>
                {
                    b.Navigation("CongTrinh");
                });

            modelBuilder.Entity("doanapi.Data.District", b =>
                {
                    b.Navigation("Communes");
                });

            modelBuilder.Entity("doanapi.Data.License", b =>
                {
                    b.Navigation("LicenseFee");
                });

            modelBuilder.Entity("doanapi.Data.LicenseType", b =>
                {
                    b.Navigation("License");
                });

            modelBuilder.Entity("doanapi.Data.Organization", b =>
                {
                    b.Navigation("License");
                });
#pragma warning restore 612, 618
        }
    }
}
