using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    public partial class Skill_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Summary_SummaryId",
                table: "Skill");

            migrationBuilder.RenameColumn(
                name: "SummaryId",
                table: "Skill",
                newName: "SkillCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_SummaryId",
                table: "Skill",
                newName: "IX_Skill_SkillCategoryId");

            migrationBuilder.CreateTable(
                name: "SkillCategory",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategory", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_SkillCategory_SkillCategoryId",
                table: "Skill",
                column: "SkillCategoryId",
                principalTable: "SkillCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_SkillCategory_SkillCategoryId",
                table: "Skill");

            migrationBuilder.DropTable(
                name: "SkillCategory");

            migrationBuilder.RenameColumn(
                name: "SkillCategoryId",
                table: "Skill",
                newName: "SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_SkillCategoryId",
                table: "Skill",
                newName: "IX_Skill_SummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Summary_SummaryId",
                table: "Skill",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
