using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.DataAccess.EntityFramework.Configurations;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Apartment.App.DataAccess.EntityFramework
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Housing> Housings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Block> Blocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new HousingConfigurations());
            builder.ApplyConfiguration(new InvoiceConfigurations());
            builder.ApplyConfiguration(new InvoiceTypeConfigurations());
            builder.ApplyConfiguration(new BlockConfigurations());
            builder.ApplyConfiguration(new FloorConfigurations());

            builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }


    }
}
