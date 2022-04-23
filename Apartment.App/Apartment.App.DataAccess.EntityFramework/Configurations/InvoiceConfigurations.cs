using Apartment.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.App.DataAccess.EntityFramework.Configurations
{
    public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.InvoicePrice).IsRequired();
            builder.Property(x => x.InvoiceAmountOfUse).IsRequired();
            builder.Property(x => x.IsSpended).IsRequired();
            builder.Property(x => x.TotalDay).IsRequired();
        }
    }

}
