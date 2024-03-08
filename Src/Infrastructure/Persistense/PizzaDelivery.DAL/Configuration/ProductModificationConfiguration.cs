using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class ProductModificationConfiguration : IEntityTypeConfiguration<ProductModifications>
{
    public void Configure(EntityTypeBuilder<ProductModifications> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Ingridient)
        .WithMany(ex => ex.ModificationsWithThisIngridients)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.IngridientId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .Property(ex => ex.PriceChange)
        .HasColumnType("money");

        builder
        .Property(ex => ex.WeightChange)
        .HasColumnType("int");

        builder
        .Property(ex => ex.Name)
        .HasColumnType("varchar");

    }
}
