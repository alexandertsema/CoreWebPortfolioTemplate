using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AlexanderTsema.Storage.Concretes.Core;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    [DbContext(typeof(StorageContext))]
    [Migration("20170128022700_Reference_ReferenceAuthot_HotFix")]
    partial class Reference_ReferenceAuthot_HotFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Certificate", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Authority");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<DateTime>("RecieveDate");

                    b.HasKey("Id");

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

                    b.Property<string>("WorkTitle");

                    b.HasKey("Id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Course", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<short?>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.PortfolioItem", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("PortfolioItem");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.PortfolioItemCategory", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PortfolioItemCategory");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Reference", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Pdf");

                    b.Property<short?>("ReferenceAuthorId");

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

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.ToTable("ReferenceAuthor");
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

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Skill", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<short>("Priority");

                    b.Property<short?>("SkillCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("SkillCategoryId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.SkillCategory", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SkillCategory");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Summary", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Summary");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Course", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.School")
                        .WithMany("Courses")
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.PortfolioItem", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.PortfolioItemCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Reference", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.ReferenceAuthor")
                        .WithMany("References")
                        .HasForeignKey("ReferenceAuthorId");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Entities.Entities.Skill", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Entities.Entities.SkillCategory", "SkillCategory")
                        .WithMany("Skills")
                        .HasForeignKey("SkillCategoryId");
                });
        }
    }
}
