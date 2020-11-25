using System;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using POS.Entities;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Steander.Core.Entities;
using POS.Data.Dto;
using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using System.Net.Http;

namespace POS.Data.DataContext
{

    public partial class PosDbContext : IdentityDbContext<ApplicationUser>
    {

        public PosDbContext(DbContextOptions<PosDbContext> options) : base(options) { }
        
        public PosDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultPosConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        #region DbQuery Call Procedure

        [Obsolete]
        public virtual DbQuery<ReturnResult> ReturnResult { get; set; }

        [Obsolete]
        public virtual DbQuery<DeleteRecord> DeleteRecord { get; set; }
        [Obsolete]
        public virtual DbQuery<JsonData> JsonData { get; set; }

        #endregion


        #region DbSet Entity
        //public virtual DbSet<BranchServices> BranchServices { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
       public virtual DbSet<Country> Country { get; set; }
       public virtual DbSet<Currency> Currency { get; set; }
       public virtual DbSet<ItemGroup> ItemGroup { get; set; }
        public virtual DbSet<MajorServices> MajorServices { get; set; }
        public virtual DbSet<MajorServiceTypes> MajorServiceTypes { get; set; }
        public virtual DbSet<MajorServicesIcons> MajorServicesIcons { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemUom> ItemUom { get; set; }
        public virtual DbSet<Sku> Sku { get; set; }
        public virtual DbSet<RemarksTemplateDetails> RemarksTemplateDetails { get; set; }
        public virtual DbSet<RemarksTemplate> RemarksTemplate { get; set; }
        public virtual DbSet<BranchWorkStations> BranchWorkStations { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<ItemComponents> ItemComponents { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<BranchesConnecting> BranchesConnecting { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<SalesGroupsItems> SalesGroupsItems { get; set; }
        public virtual DbSet<Config> Config { get; set; }

        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<UserDefinedObjects> UserDefinedObjects { get; set; }
    #endregion


    //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
    //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
    //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
    //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
    //public virtual DbSet<Users> Users { get; set; }
    //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
    //protected readonly IConfiguration Configuration;
    //public virtual DbSet<MajorServiceTypes> MajorServiceTypes { get; set; }
    //public virtual DbSet<Menu> Menu { get; set; }
    //public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
    //public virtual DbSet<States> States { get; set; }
    //public virtual DbSet<Test> Test { get; set; }



    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<ApplicationUser>(entity =>
    //    {

    //        entity.HasIndex(e => e.UserName)
    //            .HasName("RoleNameIndex")
    //            .IsUnique();

    //        entity.Property(e => e.Id).HasMaxLength(128);

    //        entity.Property(e => e.UserName)
    //            .IsRequired()
    //            .HasMaxLength(256);
    //    });

    //    //modelBuilder.Entity<AspNetUserClaims>(entity =>
    //    //{
    //    //    entity.HasIndex(e => e.UserId)
    //    //        .HasName("IX_UserId");

    //    //    entity.Property(e => e.UserId)
    //    //        .IsRequired()
    //    //        .HasMaxLength(128);

    //    //    entity.HasOne(d => d.User)
    //    //        .WithMany(p => p.AspNetUserClaims)
    //    //        .HasForeignKey(d => d.UserId)
    //    //        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
    //    //});

    //    //modelBuilder.Entity<AspNetUserLogins>(entity =>
    //    //{
    //    //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
    //    //        .HasName("PK_dbo.AspNetUserLogins");

    //    //    entity.HasIndex(e => e.UserId)
    //    //        .HasName("IX_UserId");

    //    //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

    //    //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

    //    //    entity.Property(e => e.UserId).HasMaxLength(128);

    //    //    entity.HasOne(d => d.User)
    //    //        .WithMany(p => p.AspNetUserLogins)
    //    //        .HasForeignKey(d => d.UserId)
    //    //        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
    //    //});

    //    //modelBuilder.Entity<AspNetUserRoles>(entity =>
    //    //{
    //    //    entity.HasKey(e => new { e.UserId, e.RoleId })
    //    //        .HasName("PK_dbo.AspNetUserRoles");

    //    //    entity.HasIndex(e => e.RoleId)
    //    //        .HasName("IX_RoleId");

    //    //    entity.HasIndex(e => e.UserId)
    //    //        .HasName("IX_UserId");

    //    //    entity.Property(e => e.UserId).HasMaxLength(128);

    //    //    entity.Property(e => e.RoleId).HasMaxLength(128);

    //    //    entity.HasOne(d => d.Role)
    //    //        .WithMany(p => p.AspNetUserRoles)
    //    //        .HasForeignKey(d => d.RoleId)
    //    //        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

    //    //    entity.HasOne(d => d.User)
    //    //        .WithMany(p => p.AspNetUserRoles)
    //    //        .HasForeignKey(d => d.UserId)
    //    //        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
    //    //});

    //    modelBuilder.Entity<ApplicationUser>(entity =>
    //    {
    //        entity.HasIndex(e => e.UserName)
    //            .HasName("UserNameIndex")
    //            .IsUnique();

    //        entity.Property(e => e.Id).HasMaxLength(128);

    //        entity.Property(e => e.CreateDate).HasColumnType("datetime");

    //        entity.Property(e => e.Email).HasMaxLength(256);

    //        entity.Property(e => e.InsertedBy).HasMaxLength(128);

    //        //entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

    //        //entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

    //        //entity.Property(e => e.ModifiedBy).HasMaxLength(128);

    //        //entity.Property(e => e.Password).IsRequired();

    //        //entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.Property(e => e.UserName)
    //            .IsRequired()
    //            .HasMaxLength(256);

    //        //entity.HasOne(d => d.Company)
    //        //    .WithMany(p => p.AspNetUsers)
    //        //    .HasForeignKey(d => d.CompanyId)
    //        //    .HasConstraintName("FK_AspNetUsers_Companies");
    //    });

    //    modelBuilder.Entity<BranchServices>(entity =>
    //    {
    //        entity.HasKey(e => e.BranchServiceId);

    //        entity.Property(e => e.BranchServiceId)
    //            .HasColumnName("BranchServiceID")
    //            .ValueGeneratedNever();

    //        entity.Property(e => e.BranchId).HasColumnName("BranchID");

    //        entity.Property(e => e.ServiceTypeId)
    //            .HasColumnName("ServiceTypeID")
    //            .ValueGeneratedOnAdd();

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.HasOne(d => d.Branch)
    //            .WithMany(p => p.BranchServices)
    //            .HasForeignKey(d => d.BranchId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_BranchServices_Branches");

    //        entity.HasOne(d => d.ServiceType)
    //            .WithMany(p => p.BranchServices)
    //            .HasForeignKey(d => d.ServiceTypeId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_BranchServices_MajorServiceTypes");
    //    });

    //    modelBuilder.Entity<Branches>(entity =>
    //    {
    //        entity.HasKey(e => e.BranchId);

    //        entity.Property(e => e.BranchId).HasColumnName("BranchID");

    //        entity.Property(e => e.Address).HasMaxLength(350);

    //        entity.Property(e => e.BranchName)
    //            .IsRequired()
    //            .HasMaxLength(250);

    //        entity.Property(e => e.BranchNameAr)
    //            .IsRequired()
    //            .HasMaxLength(250);

    //        entity.Property(e => e.BranchNum)
    //            .IsRequired()
    //            .HasMaxLength(50);

    //        entity.Property(e => e.BrandId).HasColumnName("BrandID");

    //        entity.Property(e => e.CityId).HasColumnName("CityID");

    //        entity.Property(e => e.CountryId).HasColumnName("CountryID");

    //        entity.Property(e => e.CreateDate).HasColumnType("datetime");

    //        entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

    //        entity.Property(e => e.DeletedBy).HasMaxLength(128);

    //        entity.Property(e => e.DeletedDate).HasColumnType("datetime");

    //        entity.Property(e => e.ImageName).HasMaxLength(100);

    //        entity.Property(e => e.InsertedBy).HasMaxLength(128);

    //        entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

    //        entity.Property(e => e.ModifiedBy).HasMaxLength(128);

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.Property(e => e.TypeId).HasColumnName("TypeID");

    //        entity.HasOne(d => d.Brand)
    //            .WithMany(p => p.Branches)
    //            .HasForeignKey(d => d.BrandId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Branches_Brands");

    //        entity.HasOne(d => d.City)
    //            .WithMany(p => p.Branches)
    //            .HasForeignKey(d => d.CityId)
    //            .HasConstraintName("FK_Branches_City");

    //        entity.HasOne(d => d.Country)
    //            .WithMany(p => p.Branches)
    //            .HasForeignKey(d => d.CountryId)
    //            .HasConstraintName("FK_Branches_Country");

    //        entity.HasOne(d => d.Currency)
    //            .WithMany(p => p.Branches)
    //            .HasForeignKey(d => d.CurrencyId)
    //            .HasConstraintName("FK_Branches_Currency");
    //    });

    //    modelBuilder.Entity<Brands>(entity =>
    //    {
    //        entity.HasKey(e => e.BrandId);

    //        entity.Property(e => e.BrandId).HasColumnName("BrandID");

    //        entity.Property(e => e.BrandName).HasMaxLength(100);

    //        entity.Property(e => e.BrandNameAr).HasMaxLength(100);

    //        entity.Property(e => e.CityId).HasColumnName("CityID");

    //        entity.Property(e => e.CountryId).HasColumnName("CountryID");

    //        entity.Property(e => e.CreateDate).HasColumnType("datetime");

    //        entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

    //        entity.Property(e => e.DeletedBy).HasMaxLength(128);

    //        entity.Property(e => e.DeletedDate).HasColumnType("datetime");

    //        entity.Property(e => e.ImageName).HasMaxLength(100);

    //        entity.Property(e => e.InsertedBy).HasMaxLength(128);

    //        entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

    //        entity.Property(e => e.MajorServiceId).HasColumnName("MajorServiceID");

    //        entity.Property(e => e.ModifiedBy).HasMaxLength(128);

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.Property(e => e.TaxNo).HasMaxLength(100);

    //        entity.HasOne(d => d.City)
    //            .WithMany(p => p.Brands)
    //            .HasForeignKey(d => d.CityId)
    //            .HasConstraintName("FK_Brands_City");

    //        entity.HasOne(d => d.Company)
    //            .WithMany(p => p.Brands)
    //            .HasForeignKey(d => d.CompanyId)
    //            .HasConstraintName("FK_Brands_Companies");

    //        entity.HasOne(d => d.Country)
    //            .WithMany(p => p.Brands)
    //            .HasForeignKey(d => d.CountryId)
    //            .HasConstraintName("FK_Brands_Country");

    //        entity.HasOne(d => d.Currency)
    //            .WithMany(p => p.Brands)
    //            .HasForeignKey(d => d.CurrencyId)
    //            .HasConstraintName("FK_Brands_Currency");

    //        entity.HasOne(d => d.MajorService)
    //            .WithMany(p => p.Brands)
    //            .HasForeignKey(d => d.MajorServiceId)
    //            .HasConstraintName("FK_Brands_MajorService");
    //    });

    //    modelBuilder.Entity<City>(entity =>
    //    {
    //        entity.Property(e => e.CityName).HasMaxLength(100);

    //        entity.Property(e => e.CityNameAr).HasMaxLength(100);

    //        entity.HasOne(d => d.CityCountry)
    //            .WithMany(p => p.City)
    //            .HasForeignKey(d => d.CityCountryId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_City_Country");
    //    });

    //    modelBuilder.Entity<Companies>(entity =>
    //    {
    //        entity.HasKey(e => e.CompanyId);

    //        entity.Property(e => e.CompanyId).ValueGeneratedNever();

    //        entity.Property(e => e.CompanyAddress).HasMaxLength(250);

    //        entity.Property(e => e.CompanyEmail).HasMaxLength(256);

    //        entity.Property(e => e.CompanyName).HasMaxLength(100);

    //        entity.Property(e => e.CompanyNameAr).HasMaxLength(100);

    //        entity.Property(e => e.CreationDate).HasColumnType("datetime");

    //        entity.Property(e => e.ImageName).HasMaxLength(100);

    //        entity.Property(e => e.ModificationDate).HasColumnType("datetime");

    //        entity.Property(e => e.ModifiedBy).HasMaxLength(128);

    //        entity.Property(e => e.Phone).HasMaxLength(20);

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.HasOne(d => d.City)
    //            .WithMany(p => p.Companies)
    //            .HasForeignKey(d => d.CityId)
    //            .HasConstraintName("FK_Companies_City");

    //        entity.HasOne(d => d.Country)
    //            .WithMany(p => p.Companies)
    //            .HasForeignKey(d => d.CountryId)
    //            .HasConstraintName("FK_Companies_Country");

    //        entity.HasOne(d => d.Currency)
    //            .WithMany(p => p.Companies)
    //            .HasForeignKey(d => d.CurrencyId)
    //            .HasConstraintName("FK_Companies_Currency");
    //    });

    //    modelBuilder.Entity<Country>(entity =>
    //    {
    //        entity.Property(e => e.Code).HasMaxLength(50);

    //        entity.Property(e => e.CountryName).HasMaxLength(100);

    //        entity.Property(e => e.CountryNameAr).HasMaxLength(100);

    //        entity.Property(e => e.Flag).HasMaxLength(200);

    //        entity.HasOne(d => d.Currency)
    //            .WithMany(p => p.Country)
    //            .HasForeignKey(d => d.CurrencyId)
    //            .HasConstraintName("FK_Country_Currency");
    //    });

    //    modelBuilder.Entity<Currency>(entity =>
    //    {
    //        entity.Property(e => e.CurrencyName).HasMaxLength(100);

    //        entity.Property(e => e.CurrencyNameAr).HasMaxLength(100);

    //        entity.Property(e => e.CurrencySign).HasMaxLength(20);

    //        entity.Property(e => e.CurrencySignAr).HasMaxLength(20);
    //    });

    //    modelBuilder.Entity<ItemGroup>(entity =>
    //    {
    //        entity.Property(e => e.ItemGroupId).HasColumnName("ItemGroupID");

    //        entity.Property(e => e.BrandId).HasColumnName("BrandID");

    //        entity.Property(e => e.CreateDate).HasColumnType("datetime");

    //        entity.Property(e => e.DeletedBy).HasMaxLength(128);

    //        entity.Property(e => e.DeletedDate).HasColumnType("datetime");

    //        entity.Property(e => e.ImageName).HasMaxLength(100);

    //        entity.Property(e => e.InsertedBy).HasMaxLength(128);

    //        entity.Property(e => e.ItemGroupMobileName).HasMaxLength(100);

    //        entity.Property(e => e.ItemGroupName).HasMaxLength(100);

    //        entity.Property(e => e.ItemGroupNameAr).HasMaxLength(100);

    //        entity.Property(e => e.ItemGroupNameMobileAr).HasMaxLength(100);

    //        entity.Property(e => e.ItemGroupNum).HasMaxLength(10);

    //        entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

    //        entity.Property(e => e.ModifiedBy).HasMaxLength(128);

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.Property(e => e.TypeId).HasColumnName("TypeID");

    //        entity.HasOne(d => d.Brand)
    //            .WithMany(p => p.ItemGroup)
    //            .HasForeignKey(d => d.BrandId)
    //            .HasConstraintName("FK_ItemGroup_Brands");
    //    });

    //    modelBuilder.Entity<Lookups>(entity =>
    //    {
    //        entity.HasNoKey();

    //        entity.Property(e => e.LookupId)
    //            .HasColumnName("LookupID")
    //            .ValueGeneratedOnAdd();

    //        entity.Property(e => e.Name).HasMaxLength(50);

    //        entity.Property(e => e.NameAr).HasMaxLength(50);

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.Property(e => e.Tag).HasMaxLength(50);

    //        entity.Property(e => e.Value)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //    });

    //    modelBuilder.Entity<MajorService>(entity =>
    //    {
    //        entity.HasKey(e => e.ServiceId)
    //            .HasName("PK__MajorSer__C51BB0EAFC7A9801");

    //        entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

    //        entity.Property(e => e.CreationDate).HasColumnType("datetime");

    //        entity.Property(e => e.ServiceName).HasMaxLength(100);

    //        entity.Property(e => e.ServiceNameAr).HasMaxLength(100);
    //    });

    //    modelBuilder.Entity<MajorServiceTypes>(entity =>
    //    {
    //        entity.HasKey(e => e.MajorServiceTypeId);

    //        entity.Property(e => e.MajorServiceTypeId).HasColumnName("MajorServiceTypeID");

    //        entity.Property(e => e.MajorServiceId).HasColumnName("MajorServiceID");

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.Property(e => e.TypeName)
    //            .IsRequired()
    //            .HasMaxLength(150);

    //        entity.Property(e => e.TypeNameAr).HasMaxLength(150);

    //        entity.HasOne(d => d.MajorService)
    //            .WithMany(p => p.MajorServiceTypes)
    //            .HasForeignKey(d => d.MajorServiceId)
    //            .HasConstraintName("FK_MajorServiceTypes_MajorService");
    //    });

    //    modelBuilder.Entity<Menu>(entity =>
    //    {
    //        entity.Property(e => e.MenuId)
    //            .HasColumnName("MenuID")
    //            .ValueGeneratedNever();

    //        entity.Property(e => e.MenuClassName).HasMaxLength(50);

    //        entity.Property(e => e.MenuImagePath).HasMaxLength(50);

    //        entity.Property(e => e.MenuKeyName).HasMaxLength(100);

    //        entity.Property(e => e.MenuParentId).HasColumnName("MenuParentID");

    //        entity.Property(e => e.MenuUrl)
    //            .HasColumnName("MenuURL")
    //            .HasMaxLength(25);

    //        entity.Property(e => e.StatusId).HasColumnName("StatusID");

    //        entity.HasOne(d => d.MenuParent)
    //            .WithMany(p => p.InverseMenuParent)
    //            .HasForeignKey(d => d.MenuParentId)
    //            .HasConstraintName("FK_Menu_Menu");
    //    });

    //    modelBuilder.Entity<MigrationHistory>(entity =>
    //    {
    //        entity.HasKey(e => new { e.MigrationId, e.ContextKey })
    //            .HasName("PK_dbo.__MigrationHistory");

    //        entity.ToTable("__MigrationHistory");

    //        entity.Property(e => e.MigrationId).HasMaxLength(150);

    //        entity.Property(e => e.ContextKey).HasMaxLength(300);

    //        entity.Property(e => e.Model).IsRequired();

    //        entity.Property(e => e.ProductVersion)
    //            .IsRequired()
    //            .HasMaxLength(32);
    //    });

    //    modelBuilder.Entity<States>(entity =>
    //    {
    //        entity.Property(e => e.StatesId).HasColumnName("StatesID");

    //        entity.Property(e => e.ActionBy)
    //            .IsRequired()
    //            .HasMaxLength(100);

    //        entity.Property(e => e.ActionDate).HasColumnType("datetime");

    //        entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

    //        entity.Property(e => e.StateTypeId).HasColumnName("StateTypeID");
    //    });

    //    modelBuilder.Entity<Test>(entity =>
    //    {
    //        entity.HasNoKey();

    //        entity.Property(e => e.SettingId).HasColumnName("SettingID");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

  }
}

