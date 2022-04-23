using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.App.DataAccess.EntityFramework.Configurations
{
    public class InvoiceTypeConfigurations : IEntityTypeConfiguration<InvoiceType>
    {
        public void Configure(EntityTypeBuilder<InvoiceType> builder)
        {
            builder.ToTable("InvoiceTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TypeName).IsRequired();
            builder.Property(x => x.TypeUnit).IsRequired();
        }
    }
}
