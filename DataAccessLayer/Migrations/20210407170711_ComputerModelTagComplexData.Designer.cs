﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210407170711_ComputerModelTagComplexData")]
    partial class ComputerModelTagComplexData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerManufacturer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ComputerManufacturers");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ComputerManufacturerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerManufacturerId");

                    b.ToTable("ComputerModels");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerModelTag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ComputerModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TagInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerModelId");

                    b.ToTable("ComputerModelTags");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerModel", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.ComputerManufacturer", null)
                        .WithMany("ComputerModels")
                        .HasForeignKey("ComputerManufacturerId");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerModelTag", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.ComputerModel", "ComputerModel")
                        .WithMany("ComputerModelTags")
                        .HasForeignKey("ComputerModelId");

                    b.OwnsOne("DataAccessLayer.Entities.SalesInfo", "SalesInfo", b1 =>
                        {
                            b1.Property<string>("ComputerModelTagId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("DepartmentLocation")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DepartmentZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SalesDepartment")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ComputerModelTagId");

                            b1.ToTable("ComputerModelTags");

                            b1.WithOwner()
                                .HasForeignKey("ComputerModelTagId");
                        });

                    b.Navigation("ComputerModel");

                    b.Navigation("SalesInfo");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerManufacturer", b =>
                {
                    b.Navigation("ComputerModels");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerModel", b =>
                {
                    b.Navigation("ComputerModelTags");
                });
#pragma warning restore 612, 618
        }
    }
}
