using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class ProductModificationInOrderConfiguration : IEntityTypeConfiguration<ProductModificationsInOrder>
{
    public void Configure(EntityTypeBuilder<ProductModificationsInOrder> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.OrderList)
        .WithMany(ex => ex.Modifications)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.OrderId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.Products)
        .WithMany(ex => ex.ModificationForThisProductsInOrders)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ProductId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .HasOne(ex => ex.Modification)
        .WithMany(ex => ex.OrdersWithThisModification)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ModificationId)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
