using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AlexanderTsema.Storage.Concretes.Core;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    [DbContext(typeof(StorageContext))]
    [Migration("20161111000202_CourseCanHaveOnlyOneSchool")]
    partial class CourseCanHaveOnlyOneSchool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlexanderTsema.Storage.Models.Models.Course", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<short?>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Models.Models.School", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Degree");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<double>("Gpa");

                    b.Property<string>("GraduationWork");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("AlexanderTsema.Storage.Models.Models.Course", b =>
                {
                    b.HasOne("AlexanderTsema.Storage.Models.Models.School", "School")
                        .WithMany("Courses")
                        .HasForeignKey("SchoolId");
                });
        }
    }
}
