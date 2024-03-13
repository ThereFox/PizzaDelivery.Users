using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.BaseWeight)
        .HasColumnType("int");

        builder
        .Property(ex => ex.BasePrice)
        .HasColumnType("money");

        builder
        .Property(ex => ex.Description)
        .HasColumnType("text");

        builder
        .Property(ex => ex.IsArchived)
        .HasColumnType("boolean");

        builder
        .HasMany(ex => ex.Ingridients)
        .WithOne(ex => ex.Product)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasMany(ex => ex.OrderLists)
        .WithOne(ex => ex.Product)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.OrderId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .HasMany(ex => ex.ModificationForThisProductsInOrders)
        .WithOne(ex => ex.Products)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.OrderId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasMany(ex => ex.AvaliableModification)
        .WithOne(ex => ex.Product)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasMany(ex => ex.ProductImages)
        .WithOne(ex => ex.Product)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
        

    }
}
