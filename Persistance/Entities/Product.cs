using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Persistance.Entities
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public Translation Description { get; set; }
        public ProductType Type { get; set; }
        public virtual List<ProductHasAccessory> Accessories { get; set; }
        public virtual List<ProductHasAccessory> Products { get; set; }

        int IWithId.Id => ProductId;
    }

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Accessories)
                .WithOne(phs => phs.Product)
                .HasForeignKey(phs => phs.ProductId);

            builder.HasMany(p => p.Products)
                .WithOne(phs => phs.Accessory)
                .HasForeignKey(phs => phs.AccessoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
