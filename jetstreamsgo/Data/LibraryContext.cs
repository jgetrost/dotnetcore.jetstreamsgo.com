using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static jetstreamsgo.Models.LibraryModel;

namespace jetstreamsgo.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=dotnetcore.jetstreamsgo.com;database=library;user=library;password=A%b42aWD#A@!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ISBN);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Publisher)
                  .WithMany(p => p.Books);
            });
        }
    }
}
