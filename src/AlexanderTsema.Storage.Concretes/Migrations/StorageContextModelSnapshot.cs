using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Enums;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Certificate", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Authority");

                    b.Property<short>("FileId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("RecieveDate");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Content", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CertificateTitle");

                    b.Property<string>("ContactsTitle");

                    b.Property<string>("EducationTitle");

                    b.Property<string>("SummaryTitle");

                    b.Property<string>("TestimonialsTitle");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("WorkTitle");

                    b.HasKey("Id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Course", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<short>("SchoolId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.File", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilePath");

                    b.Property<int>("FileType");

                    b.Property<string>("Name");

                    b.Property<long>("Size");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.PortfolioItem", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<short>("PortfolioItemCategoryId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioItemCategoryId");

                    b.ToTable("PortfolioItem");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.PortfolioItemCategory", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("PortfolioItemCategory");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Reference", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("PdfPath");

                    b.Property<short>("ReferenceAuthorId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceAuthorId");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.ReferenceAuthor", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyLink");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("ReferenceAuthor");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Resume", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PdfPath");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.School", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Degree");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<double>("Gpa");

                    b.Property<string>("GraduationWork");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Skill", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<short>("Priority");

                    b.Property<short>("SkillCategoryId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("SkillCategoryId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.SkillCategory", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("SkillCategory");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Summary", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ProfileImagePath");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Summary");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Certificate", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.File", "Image")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Course", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.School", "School")
                        .WithMany("Courses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.PortfolioItem", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.PortfolioItemCategory", "PortfolioItemCategory")
                        .WithMany("PortfolioItems")
                        .HasForeignKey("PortfolioItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Reference", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.ReferenceAuthor", "ReferenceAuthor")
                        .WithMany("References")
                        .HasForeignKey("ReferenceAuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Skill", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.SkillCategory", "SkillCategory")
                        .WithMany("Skills")
                        .HasForeignKey("SkillCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
