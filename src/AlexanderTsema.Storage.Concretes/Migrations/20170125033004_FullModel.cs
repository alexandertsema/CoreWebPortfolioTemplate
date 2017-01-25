using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    public partial class FullModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "SummaryId",
                table: "Skill",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactsTitle = table.Column<string>(nullable: true),
                    EducationTitle = table.Column<string>(nullable: true),
                    SummaryTitle = table.Column<string>(nullable: true),
                    TestimonialsTitle = table.Column<string>(nullable: true),
                    WorkTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "ReferenceAuthor",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyLink = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceAuthor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItem",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PortfolioItemTypeId = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioItem_PortfolioItemType_PortfolioItemTypeId",
                        column: x => x.PortfolioItemTypeId,
                        principalTable: "PortfolioItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Pdf = table.Column<string>(nullable: true),
                    ReferenceAuthorId = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reference_ReferenceAuthor_ReferenceAuthorId",
                        column: x => x.ReferenceAuthorId,
                        principalTable: "ReferenceAuthor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SummaryId",
                table: "Skill",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItem_PortfolioItemTypeId",
                table: "PortfolioItem",
                column: "PortfolioItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_ReferenceAuthorId",
                table: "Reference",
                column: "ReferenceAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Summary_SummaryId",
                table: "Skill",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Summary_SummaryId",
                table: "Skill");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "PortfolioItem");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "Summary");

            migrationBuilder.DropTable(
                name: "PortfolioItemType");

            migrationBuilder.DropTable(
                name: "ReferenceAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Skill_SummaryId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SummaryId",
                table: "Skill");
        }
    }
}
