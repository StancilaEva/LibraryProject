using Library.Core;
using Library.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Lend> Lends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ROMOB41209\\SQLEXPRESS;Database=ComicBooksDatabase;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
         .HasOne(x => x.Client)
         .WithOne(x => x.Address)
         .HasForeignKey<Client>("AddressFk")
         .IsRequired(false)
         .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
