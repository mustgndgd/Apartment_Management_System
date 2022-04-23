using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.App.DataAccess.EntityFramework.Configurations
{
    public class FloorConfigurations: IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floors");
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.FloorNumber).IsRequired();
        }
    }
}
