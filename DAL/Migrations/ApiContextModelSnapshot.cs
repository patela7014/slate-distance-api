﻿// <auto-generated />
using System;
using DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Core.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Class");

                    b.Property<string>("Country");

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<int>("ProjectId");

                    b.Property<string>("State");

                    b.Property<string>("Submarket");

                    b.Property<string>("Title");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastUpdatedBy");

                    b.HasIndex("ProjectId");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("DAL.Core.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Designation");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastUpdatedBy");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DAL.Core.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastUpdatedBy");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("DAL.Core.Models.ProjectionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuildingAddress");

                    b.Property<string>("BuildingCity");

                    b.Property<string>("BuildingCountry");

                    b.Property<string>("BuildingState");

                    b.Property<string>("BuildingTitle");

                    b.Property<string>("BuildingZip");

                    b.Property<string>("Class");

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Designation");

                    b.Property<float>("Distance");

                    b.Property<float>("Duration");

                    b.Property<string>("Email");

                    b.Property<string>("EmployeeAddress");

                    b.Property<string>("EmployeeCity");

                    b.Property<string>("EmployeeCountry");

                    b.Property<string>("EmployeeState");

                    b.Property<string>("EmployeeZip");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Phone");

                    b.Property<int?>("ReportId");

                    b.Property<string>("Submarket");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastUpdatedBy");

                    b.HasIndex("ReportId");

                    b.ToTable("ProjectionData");
                });

            modelBuilder.Entity("DAL.Core.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AverageDistance");

                    b.Property<float>("AverageDuration");

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastUpdatedBy");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("DAL.Core.Models.ReportProjection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<int>("ProjectionDataId");

                    b.Property<int>("ReportId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastUpdatedBy");

                    b.HasIndex("ProjectionDataId");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportProjection");
                });

            modelBuilder.Entity("DAL.Core.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("HomePhone");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MidName");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DAL.Core.Models.Building", b =>
                {
                    b.HasOne("DAL.Core.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DAL.Core.Models.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("LastUpdatedBy");

                    b.HasOne("DAL.Core.Models.Project", "Project")
                        .WithMany("Buildings")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Core.Models.Employee", b =>
                {
                    b.HasOne("DAL.Core.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DAL.Core.Models.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("LastUpdatedBy");
                });

            modelBuilder.Entity("DAL.Core.Models.Project", b =>
                {
                    b.HasOne("DAL.Core.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DAL.Core.Models.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("LastUpdatedBy");
                });

            modelBuilder.Entity("DAL.Core.Models.ProjectionData", b =>
                {
                    b.HasOne("DAL.Core.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DAL.Core.Models.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("LastUpdatedBy");

                    b.HasOne("DAL.Core.Models.Report")
                        .WithMany("Projections")
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("DAL.Core.Models.Report", b =>
                {
                    b.HasOne("DAL.Core.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DAL.Core.Models.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("LastUpdatedBy");
                });

            modelBuilder.Entity("DAL.Core.Models.ReportProjection", b =>
                {
                    b.HasOne("DAL.Core.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DAL.Core.Models.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("LastUpdatedBy");

                    b.HasOne("DAL.Core.Models.ProjectionData", "ProjectionData")
                        .WithMany()
                        .HasForeignKey("ProjectionDataId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Core.Models.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
