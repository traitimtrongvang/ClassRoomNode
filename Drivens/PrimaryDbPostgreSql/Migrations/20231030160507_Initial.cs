using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimaryDbPostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    OwnerUserId = table.Column<string>(type: "varchar", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    SpaceId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootFolderId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_RootFolderId",
                        column: x => x.RootFolderId,
                        principalTable: "Folders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Folders_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Name_RootFolderId",
                table: "Folders",
                columns: new[] { "Name", "RootFolderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Name_SpaceId",
                table: "Folders",
                columns: new[] { "Name", "SpaceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_RootFolderId",
                table: "Folders",
                column: "RootFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_SpaceId",
                table: "Folders",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_Name",
                table: "Spaces",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Spaces");
        }
    }
}
