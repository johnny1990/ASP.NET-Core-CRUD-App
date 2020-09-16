﻿// <auto-generated />
using System;
using CabAutomationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CabAutomationSystem.Migrations
{
    [DbContext(typeof(CabDbContext))]
    [Migration("20191005165011_CabDB")]
    partial class CabDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CabAutomationSystem.Models.Cab", b =>
                {
                    b.Property<int>("CabId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BookId");

                    b.Property<TimeSpan>("BookTime");

                    b.Property<string>("JourneyPlace")
                        .IsRequired();

                    b.Property<long>("JourneyTime");

                    b.HasKey("CabId");

                    b.ToTable("Cab");
                });

            modelBuilder.Entity("CabAutomationSystem.Models.DropPoint", b =>
                {
                    b.Property<int>("DropPointId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DropPointName")
                        .IsRequired();

                    b.Property<string>("NewDropPointName");

                    b.Property<int>("RouteId");

                    b.HasKey("DropPointId");

                    b.HasIndex("RouteId");

                    b.ToTable("DropPoint");
                });

            modelBuilder.Entity("CabAutomationSystem.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CabId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("EmployeeName")
                        .IsRequired();

                    b.Property<int>("EmployeeNo");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("ProjectName")
                        .IsRequired();

                    b.HasKey("EmpId");

                    b.HasIndex("CabId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CabAutomationSystem.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RouteName")
                        .IsRequired();

                    b.Property<string>("RouteNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("RouteId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("CabAutomationSystem.Models.DropPoint", b =>
                {
                    b.HasOne("CabAutomationSystem.Models.Route", "Route")
                        .WithMany("DropPoint_List")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CabAutomationSystem.Models.Employee", b =>
                {
                    b.HasOne("CabAutomationSystem.Models.Cab", "Cab")
                        .WithMany("Employee_List")
                        .HasForeignKey("CabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
