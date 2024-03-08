using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
{
    public void Configure(EntityTypeBuilder<Customers> builder)
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
        .Property(ex => ex.PhoneNumber)
        .HasColumnType("varchar");

        builder
        .Property(ex => ex.PasswordHash)
        .HasColumnType("byte");

        builder
        .HasOne(ex => ex.DefaultAddres)
        .WithMany(ex => ex.UsersWithThisAddresAsDefault)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.DefaultAddresId)
        .OnDelete(DeleteBehavior.SetNull);


    }
}
