using ASP_pl.Persistance.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductE = ASP_pl.Persistance.Entities.Product;
using SynchronizationE = ASP_pl.Persistance.Entities.Synchronization;
namespace ASP_pl.Persistance
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductE> Products { get; set; }
        public DbSet<ProductHasAccessory> ProductHasAccessories { get; set; }
        public DbSet<ProductHasPrice> ProductHasPrices { get; set; }
        public DbSet<SynchronizationE> Synchronizations { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new TranslationConfig());
            modelBuilder.ApplyConfiguration(new SynchronizationConfig());
        }
    }

}
