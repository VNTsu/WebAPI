using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass2.Model;

namespace Ass2.Data
{
    public class Ass2Context : DbContext
    {
        public Ass2Context(DbContextOptions<Ass2Context> options)
        : base(options) { }

        public DbSet<Category> Categorie { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(l => l.ProductID);
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(e => e.CategoryID);
                e.HasMany<Product>(e => e.Products)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryID);
            });
        }
    }
}