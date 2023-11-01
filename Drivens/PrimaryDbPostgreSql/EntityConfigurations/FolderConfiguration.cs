using Application.Domain.Entities;
using Application.Domain.ValueObjects.Folder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrimaryDbPostgreSql.EntityConfigurations;

internal class FolderConfiguration : BaseEntityConfiguration<Folder, FolderId>
{
    public override void Configure(EntityTypeBuilder<Folder> builder)
    {
        base.Configure(builder);

        #region Indexes

        builder
            .HasIndex(e => new
            {
                e.Name,
                e.SpaceId
            })
            .IsUnique();
        
        builder
            .HasIndex(e => new
            {
                e.Name,
                e.RootFolderId
            })
            .IsUnique();

        builder
            .HasOne(e => e.Space)
            .WithMany(e => e.FolderList)
            .HasForeignKey(e => e.SpaceId);

        builder
            .HasOne(e => e.RootFolder)
            .WithMany(e => e.SubFolderList)
            .HasForeignKey(e => e.RootFolderId);

        builder
            .HasMany(e => e.SubFolderList)
            .WithOne(e => e.RootFolder)
            .HasForeignKey(e => e.RootFolderId);

        #endregion
        
        #region Columns

        builder
            .Property(e => e.Name)
            .HasConversion(
                name => name.Val,
                nameVal => new(nameVal))
            .HasColumnType("varchar");

        builder
            .Property(e => e.SpaceId)
            .HasConversion<Guid?>(
                spaceId => spaceId != null ? spaceId.Val : null,
                spaceIdVal => spaceIdVal != null ? new ((Guid)spaceIdVal) : null)
            .IsRequired(false);
        
        builder
            .Property(e => e.RootFolderId)
            .HasConversion<Guid?>(
                rootFolderId => rootFolderId != null ? rootFolderId.Val : null,
                rootFolderIdVal => rootFolderIdVal != null ? new ((Guid)rootFolderIdVal) : null)
            .IsRequired(false);

        #endregion
    }
}