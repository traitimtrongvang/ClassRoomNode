using Application.Domain.Entities;
using Application.Domain.ValueObjects.Space;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrimaryDbPostgreSql.EntityConfigurations;

internal class SpaceConfiguration : BaseEntityConfiguration<Space, SpaceId>
{
    public override void Configure(EntityTypeBuilder<Space> builder)
    {
        base.Configure(builder);

        #region Indexes

        builder
            .HasIndex(e => e.Name)
            .IsUnique();

        builder
            .HasMany(e => e.FolderList)
            .WithOne(e => e.Space)
            .HasForeignKey(e => e.SpaceId);

        #endregion

        #region Columns

        builder
            .Property(e => e.Name)
            .HasConversion(
                name => name.Val,
                nameVal => new (nameVal))
            .HasColumnType("varchar");

        builder
            .Property(e => e.Type)
            .HasConversion<int>()
            .HasColumnType("smallint");

        builder
            .Property(e => e.OwnerUserId)
            .HasConversion(
                ownerUserId => ownerUserId.Val,
                ownerUserIdVal => new(ownerUserIdVal))
            .HasColumnType("varchar");

        #endregion
    }
}