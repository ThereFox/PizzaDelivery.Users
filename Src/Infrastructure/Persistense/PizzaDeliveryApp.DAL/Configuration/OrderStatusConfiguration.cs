using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.Name)
        .HasColumnType("varchar");

        builder
        .Property(ex => ex.isEnded)
        .HasColumnType("boolean");

        builder
        .HasMany(ex => ex.OrdersWithThisStatus)
        .WithOne(ex => ex.Status)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.StatusId)
        .OnDelete(DeleteBehavior.SetNull);
    }
}
