using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class IngridientsConfiguration : IEntityTypeConfiguration<Ingridients>
{
    public void Configure(EntityTypeBuilder<Ingridients> builder)
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
        .HasMany(ex => ex.ProductIngridients)
        .WithOne(ex => ex.Ingridient)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.IngridientId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .HasMany(ex => ex.ModificationsWithThisIngridients)
        .WithOne(ex => ex.Ingridient)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.IngridientId)
        .OnDelete(DeleteBehavior.SetNull);
    }
}
