using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    public partial class PortfolioItemCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItem_PortfolioItemType_PortfolioItemTypeId",
                table: "PortfolioItem");

            migrationBuilder.DropTable(
                name: "PortfolioItemType");

            migrationBuilder.RenameColumn(
                name: "PortfolioItemTypeId",
                table: "PortfolioItem",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioItem_PortfolioItemTypeId",
                table: "PortfolioItem",
                newName: "IX_PortfolioItem_CategoryId");

            migrationBuilder.CreateTable(
                name: "PortfolioItemCategory",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItemCategory", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItem_PortfolioItemCategory_CategoryId",
                table: "PortfolioItem",
                column: "CategoryId",
                principalTable: "PortfolioItemCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioItem_PortfolioItemCategory_CategoryId",
                table: "PortfolioItem");

            migrationBuilder.DropTable(
                name: "PortfolioItemCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "PortfolioItem",
                newName: "PortfolioItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioItem_CategoryId",
                table: "PortfolioItem",
                newName: "IX_PortfolioItem_PortfolioItemTypeId");

            migrationBuilder.CreateTable(
                name: "PortfolioItemType",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desktop = table.Column<bool>(nullable: false),
                    Mobile = table.Column<bool>(nullable: false),
                    Web = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItemType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioItem_PortfolioItemType_PortfolioItemTypeId",
                table: "PortfolioItem",
                column: "PortfolioItemTypeId",
                principalTable: "PortfolioItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
