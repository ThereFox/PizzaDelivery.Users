using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class AddresesConfiguration : IEntityTypeConfiguration<Addreses>
{
    public void Configure(EntityTypeBuilder<Addreses> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .Property(ex => ex.City)
        .HasColumnType("varchar");

        builder
        .Property(ex => ex.Street)
        .HasColumnType("varchar");

        builder
        .Property(ex => ex.House)
        .HasColumnType("varchar");

        builder
        .Property(ex => ex.Room)
        .HasColumnType("varchar");

        builder
        .HasMany(ex => ex.Orders)
        .WithOne(ex => ex.Addres)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.AddresId)
        .OnDelete(DeleteBehavior.SetNull);

        builder
        .HasMany(ex => ex.UsersWithThisAddresAsDefault)
        .WithOne(ex => ex.DefaultAddres)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.DefaultAddresId)
        .OnDelete(DeleteBehavior.SetNull);

    }
}
