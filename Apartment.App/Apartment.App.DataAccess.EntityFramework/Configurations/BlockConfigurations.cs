using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.App.DataAccess.EntityFramework.Configurations
{
    public class BlockConfigurations : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.ToTable("Blocks");
            builder.HasKey(x => x.Id);
        }
    }

}
