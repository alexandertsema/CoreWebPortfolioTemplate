using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertificateTitle = table.Column<string>(nullable: true),
                    ContactsTitle = table.Column<string>(nullable: true),
                    EducationTitle = table.Column<string>(nullable: true),
                    SummaryTitle = table.Column<string>(nullable: true),
                    TestimonialsTitle = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    WorkTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilePath = table.Column<string>(nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItemCategory",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceAuthor",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyLink = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceAuthor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PdfPath = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Degree = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Gpa = table.Column<double>(nullable: false),
                    GraduationWork = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillCategory",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ProfileImagePath = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Authority = table.Column<string>(nullable: true),
                    FileId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RecieveDate = table.Column<DateTime>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItem",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PortfolioItemCategoryId = table.Column<short>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioItem_PortfolioItemCategory_PortfolioItemCategoryId",
                        column: x => x.PortfolioItemCategoryId,
                        principalTable: "PortfolioItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    PdfPath = table.Column<string>(nullable: true),
                    ReferenceAuthorId = table.Column<short>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reference_ReferenceAuthor_ReferenceAuthorId",
                        column: x => x.ReferenceAuthorId,
                        principalTable: "ReferenceAuthor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SchoolId = table.Column<short>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Priority = table.Column<short>(nullable: false),
                    SkillCategoryId = table.Column<short>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_SkillCategory_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_FileId",
                table: "Certificate",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SchoolId",
                table: "Course",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItem_PortfolioItemCategoryId",
                table: "PortfolioItem",
                column: "PortfolioItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_ReferenceAuthorId",
                table: "Reference",
                column: "ReferenceAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillCategoryId",
                table: "Skill",
                column: "SkillCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "PortfolioItem");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Summary");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "PortfolioItemCategory");

            migrationBuilder.DropTable(
                name: "ReferenceAuthor");

            migrationBuilder.DropTable(
                name: "SkillCategory");
        }
    }
}
