using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class ProductIngridientsConfiguration : IEntityTypeConfiguration<ProductIngridients>
{
    public void Configure(EntityTypeBuilder<ProductIngridients> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Product)
        .WithMany(ex => ex.Ingridients)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.Ingridient)
        .WithMany(ex => ex.ProductIngridients)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.IngridientId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .Property(ex => ex.Weight)
        .HasColumnType("int");

    }
}
