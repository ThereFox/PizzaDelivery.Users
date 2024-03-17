using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.Image)
        .HasColumnType("bytea");

        builder
        .HasOne(ex => ex.Product)
        .WithMany(ex => ex.ProductImages)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
