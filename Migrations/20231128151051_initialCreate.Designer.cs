﻿// <auto-generated />
using InterstellarApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterstellarApp.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231128151051_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InterstellarApp.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kilometers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Third planet from the sun",
                            Kilometers = 12742,
                            Name = "Earth"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fourth planet from the sun",
                            Kilometers = 6779,
                            Name = "Mars"
                        });
                });

            modelBuilder.Entity("InterstellarApp.Models.PlanetVisitors", b =>
                {
                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.HasKey("VisitorId", "PlanetId");

                    b.HasIndex("PlanetId");

                    b.ToTable("Registrations");

                    b.HasData(
                        new
                        {
                            VisitorId = 1,
                            PlanetId = 1
                        },
                        new
                        {
                            VisitorId = 2,
                            PlanetId = 1
                        },
                        new
                        {
                            VisitorId = 2,
                            PlanetId = 2
                        });
                });

            modelBuilder.Entity("InterstellarApp.Models.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visitors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane Smith"
                        });
                });

            modelBuilder.Entity("InterstellarApp.Models.PlanetVisitors", b =>
                {
                    b.HasOne("InterstellarApp.Models.Planet", "Planet")
                        .WithMany("PlanetVisitors")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InterstellarApp.Models.Visitor", "Visitor")
                        .WithMany("PlanetVisitors")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("InterstellarApp.Models.Planet", b =>
                {
                    b.Navigation("PlanetVisitors");
                });

            modelBuilder.Entity("InterstellarApp.Models.Visitor", b =>
                {
                    b.Navigation("PlanetVisitors");
                });
#pragma warning restore 612, 618
        }
    }
}
