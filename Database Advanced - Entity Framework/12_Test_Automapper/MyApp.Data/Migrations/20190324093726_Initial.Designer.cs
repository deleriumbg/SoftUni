﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp.Data;

namespace MyApp.Data.Migrations
{
    [DbContext(typeof(EmployeesMappingContext))]
    [Migration("20190324093726_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("ManagerId");

                    b.Property<decimal>("Salary");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Georgi",
                            LastName = "Georgiev",
                            Salary = 12131.44m
                        },
                        new
                        {
                            Id = 2,
                            Address = "Neznam",
                            Birthday = new DateTime(2019, 3, 9, 11, 37, 25, 959, DateTimeKind.Local).AddTicks(5936),
                            FirstName = "Maria",
                            LastName = "Marieva",
                            Salary = 999.10m
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alisia",
                            LastName = "Alisieva",
                            Salary = 11111.11m
                        },
                        new
                        {
                            Id = 4,
                            Address = "Neznam2",
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Pesho",
                            LastName = "Peshov",
                            Salary = 431.44m
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(2018, 3, 24, 11, 37, 25, 962, DateTimeKind.Local).AddTicks(493),
                            FirstName = "Vyara",
                            LastName = "Marinova",
                            Salary = 2000.44m
                        });
                });

            modelBuilder.Entity("MyApp.Models.Employee", b =>
                {
                    b.HasOne("MyApp.Models.Employee", "Manager")
                        .WithMany("ManagedEmployees")
                        .HasForeignKey("ManagerId");
                });
#pragma warning restore 612, 618
        }
    }
}
