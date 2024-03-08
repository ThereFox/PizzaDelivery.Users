using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class AvaliableModificationConfiguration : IEntityTypeConfiguration<AvaliableModification>
{
    public void Configure(EntityTypeBuilder<AvaliableModification> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Product)
        .WithMany(ex => ex.AvaliableModification)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ex => ex.Modification)
        .WithMany(ex => ex.AvaliableForProducts)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.ModificationId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
