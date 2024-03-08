using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.DAL.TableEntitys;

namespace PizzaDelivery.DAL.Configuration;

public class AuthTokensConfiguration : IEntityTypeConfiguration<AuthTokens>
{
    public void Configure(EntityTypeBuilder<AuthTokens> builder)
    {
        builder
        .HasKey(ex => ex.Id);

        builder
        .Property(ex => ex.Id)
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder
        .HasOne(ex => ex.Customer)
        .WithMany(ex => ex.Tokens)
        .HasPrincipalKey(ex => ex.Id)
        .HasForeignKey(ex => ex.OwnerId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .Property(ex => ex.Token)
        .HasColumnType("varchar");

        builder
        .Property(ex => ex.EndOfLife)
        .HasColumnType("timestampz");

    }
}
