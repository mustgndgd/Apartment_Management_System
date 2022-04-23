using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.App.DataAccess.EntityFramework.Configurations
{
    public class HousingConfigurations : IEntityTypeConfiguration<Housing>
    {
        public void Configure(EntityTypeBuilder<Housing> builder)
        {
            builder.ToTable("Housings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsEmpty).IsRequired();
            builder.Property(x => x.IsHomeowner).IsRequired();
            builder.Property(x => x.ApartmentNumber).IsRequired();
            builder.Property(x => x.ApartmentSizeInfo).IsRequired();
        }
    }
}
