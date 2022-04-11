
using Library.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.EntityConfigurations
{
    public class AdressEntityConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(address => address.Client)
                .WithOne(client=>client.Address)
                .HasForeignKey<Address>("ClientId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
