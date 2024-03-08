using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Customer)
        .WithMany(ex => ex.Orders)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.CustomerId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .Property(ex => ex.TotalPrice)
        .HasColumnType("money");

        builder
        .Property(ex => ex.OrderTime)
        .HasColumnType("timestampz");

        builder
        .Property(ex => ex.DeliveryTime)
        .HasColumnType("timestampz");
        builder
        .Property(ex => ex.AwaitedTime)
        .HasColumnType("timestampz");

        builder
        .HasOne(ex => ex.Addres)
        .WithMany(ex => ex.Orders)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.AddresId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .Property(ex => ex.CommentForDelivery)
        .HasColumnType("text");

    }
}
