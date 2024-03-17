using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class OrdersFeedbackConfiguration : IEntityTypeConfiguration<OrderFeedbacks>
{
    public void Configure(EntityTypeBuilder<OrderFeedbacks> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.Score)
        .HasColumnType("int");

        builder
        .Property(ex => ex.Message)
        .HasColumnType("text")
        .HasMaxLength(500);

        builder
        .HasOne(ex => ex.Order)
        .WithOne(ex => ex.Feedback)
        .HasPrincipalKey<Orders>(ex => ex.Id)
        .HasForeignKey<OrderFeedbacks>(ex => ex.OrderId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
