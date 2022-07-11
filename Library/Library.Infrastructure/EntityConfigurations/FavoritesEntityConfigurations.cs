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
    public class FavoritesEntityConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasMany(client=>client.Comics)
                .WithMany(book=>book.Clients)
                .UsingEntity<Favorite>(fav=>
                fav.HasOne(x=>x.ComicBook).WithMany().HasForeignKey(x=>x.ComicId),
                fav=> fav.HasOne(x=>x.Client).WithMany().HasForeignKey(x=>x.ClientId));
        }
    }
}
