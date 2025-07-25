﻿// <auto-generated />
using System;
using FarmManagementTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmManagementTracker.Migrations
{
    [DbContext(typeof(FarmDbContext))]
    [Migration("20250430220504_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmManagementTracker.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Brahma",
                            Gender = "Male",
                            Name = "Ace",
                            Notes = "Leader of the flock",
                            Status = "Active",
                            Type = "Chicken"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Khaki Campbell",
                            Gender = "Male",
                            Name = "Waddles",
                            Notes = "Eats a lot",
                            Status = "Active",
                            Type = "Duck"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Rhode Island Red",
                            Gender = "Female",
                            Name = "Rosie",
                            Notes = "Calm and productive",
                            Status = "Active",
                            Type = "Chicken"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Runner Duck",
                            Gender = "Female",
                            Name = "Quackers",
                            Notes = "Very vocal",
                            Status = "Active",
                            Type = "Duck"
                        });
                });

            modelBuilder.Entity("FarmManagementTracker.Models.FarmTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NextDueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FarmTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Frequency = "Weekly",
                            NextDueDate = new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Use pine shavings",
                            TaskName = "Clean Chicken Coop"
                        },
                        new
                        {
                            Id = 2,
                            Frequency = "Daily",
                            NextDueDate = new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Done every morning",
                            TaskName = "Refill Waterers"
                        });
                });

            modelBuilder.Entity("FarmManagementTracker.Models.SupplyItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SupplyItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Feed",
                            Name = "Layer Pellets",
                            Notes = "Buy more if under 2",
                            Quantity = 3,
                            Unit = "bags"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Bedding",
                            Name = "Straw Bales",
                            Notes = "Used for coop bedding",
                            Quantity = 5,
                            Unit = "bales"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
