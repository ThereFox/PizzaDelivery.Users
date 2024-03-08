using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class OrderListsConfiguration : IEntityTypeConfiguration<OrderLists>
{
    public void Configure(EntityTypeBuilder<OrderLists> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Order)
        .WithMany(ex => ex.OrderElements)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.Order)
        .WithMany(ex => ex.OrderElements)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.Id)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
