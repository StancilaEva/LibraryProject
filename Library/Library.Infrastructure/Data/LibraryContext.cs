using Library.Core;
using Library.Infrastructure.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : IdentityDbContext
    {
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public LibraryContext(DbContextOptions options):base(options)
        {
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Address>()
         .HasOne(x => x.Client)
         .WithOne(x => x.Address)
         .HasForeignKey<Client>("AddressFk")
         .IsRequired(false)
         .OnDelete(DeleteBehavior.SetNull);
          modelBuilder.ApplyConfiguration(new IdentityUserTokenConfig());
          modelBuilder.ApplyConfiguration(new IdentityUserLogInConfig());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleConfig());
            modelBuilder.ApplyConfiguration(new FavoritesEntityConfigurations());
        }
    }
}
