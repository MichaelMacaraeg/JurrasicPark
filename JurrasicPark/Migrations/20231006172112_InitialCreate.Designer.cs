﻿// <auto-generated />
using JurrasicPark.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JurrasicPark.Migrations
{
    [DbContext(typeof(JurrasicParkDbContext))]
    [Migration("20231006172112_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("JurrasicPark.Models.Cage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPowered")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsPowered = true,
                            MaxCapacity = 10
                        },
                        new
                        {
                            Id = 2,
                            IsPowered = true,
                            MaxCapacity = 5
                        },
                        new
                        {
                            Id = 3,
                            IsPowered = true,
                            MaxCapacity = 5
                        },
                        new
                        {
                            Id = 4,
                            IsPowered = true,
                            MaxCapacity = 7
                        },
                        new
                        {
                            Id = 5,
                            IsPowered = true,
                            MaxCapacity = 10
                        });
                });

            modelBuilder.Entity("JurrasicPark.Models.Dinosaur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpeciesTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Dinosaur");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CageId = 1,
                            FoodTypeId = 1,
                            Name = "T-Rex",
                            SpeciesTypeId = 8
                        },
                        new
                        {
                            Id = 2,
                            CageId = 2,
                            FoodTypeId = 1,
                            Name = "Raptor",
                            SpeciesTypeId = 9
                        },
                        new
                        {
                            Id = 3,
                            CageId = 3,
                            FoodTypeId = 2,
                            Name = "Stego",
                            SpeciesTypeId = 2
                        });
                });

            modelBuilder.Entity("JurrasicPark.Models.FoodType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FoodTypeDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("FoodType");

                    b.HasData(
                        new
                        {
                            id = 1,
                            FoodTypeDescription = "Carnivore"
                        },
                        new
                        {
                            id = 2,
                            FoodTypeDescription = "Herbivore"
                        });
                });

            modelBuilder.Entity("JurrasicPark.Models.SpeciesType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpeciesTypeName")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("SpeciesType");

                    b.HasData(
                        new
                        {
                            id = 1,
                            SpeciesTypeName = "Pachycephalosaurus"
                        },
                        new
                        {
                            id = 2,
                            SpeciesTypeName = "Stegosaurus"
                        },
                        new
                        {
                            id = 3,
                            SpeciesTypeName = "Tenontosaurus"
                        },
                        new
                        {
                            id = 4,
                            SpeciesTypeName = "Brachiosaurus"
                        },
                        new
                        {
                            id = 5,
                            SpeciesTypeName = "Ankylosaurus"
                        },
                        new
                        {
                            id = 6,
                            SpeciesTypeName = "Triceratops"
                        },
                        new
                        {
                            id = 12,
                            SpeciesTypeName = "Ceratosaurus"
                        },
                        new
                        {
                            id = 7,
                            SpeciesTypeName = "Carnotaurus"
                        },
                        new
                        {
                            id = 8,
                            SpeciesTypeName = "Tyrannosaurus"
                        },
                        new
                        {
                            id = 9,
                            SpeciesTypeName = "Velociraptor"
                        },
                        new
                        {
                            id = 10,
                            SpeciesTypeName = "Spinosaurus"
                        },
                        new
                        {
                            id = 11,
                            SpeciesTypeName = "Megalosaurus"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
