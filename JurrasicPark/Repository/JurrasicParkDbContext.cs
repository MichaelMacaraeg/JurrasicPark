using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurrasicPark.Models;
using Microsoft.EntityFrameworkCore;

namespace JurrasicPark.Repository
{
    public class JurrasicParkDbContext : DbContext
    {
        public JurrasicParkDbContext()
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source = C:\temp\JurrassicParkDB.db");


        public DbSet<Cage> Cage { get; set; }
        public DbSet<Dinosaur> Dinosaur { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<SpeciesType> SpeciesType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dinosaur>().HasData(
               new Dinosaur
               {
                   Id = 1,
                   Name = "T-Rex",
                   SpeciesTypeId = 8,
                   FoodTypeId = 1,
                   CageId = 1,
               },
                new Dinosaur
                {
                    Id = 2,
                    Name = "Raptor",
                    SpeciesTypeId = 9,
                    FoodTypeId = 1,
                    CageId = 2,
                },
                new Dinosaur
                {
                    Id = 3,
                    Name = "Stego",
                    SpeciesTypeId = 2,
                    FoodTypeId = 2,
                    CageId = 3,
                });

           modelBuilder.Entity<Cage>().HasData(
                new Cage
                {
                    Id = 1,
                    MaxCapacity = 10,
                    IsPowered = true
                },

                new Cage
                {
                    Id = 2,
                    MaxCapacity = 5,
                    IsPowered = true
                },
                new Cage
                {
                    Id = 3,
                    MaxCapacity = 5,
                    IsPowered = true
                },
                new Cage
                {
                    Id = 4,
                    MaxCapacity = 7,
                    IsPowered = true
                },
                new Cage
                {
                    Id = 5,
                    MaxCapacity = 10,
                    IsPowered = true
                }
            );


            modelBuilder.Entity<SpeciesType>().HasData(
               new SpeciesType
               {
                   id = 1,
                   SpeciesTypeName = "Pachycephalosaurus",

               },

               new SpeciesType
               {
                   id = 2,
                   SpeciesTypeName = "Stegosaurus",

               },
                new SpeciesType
                {
                    id = 3,
                    SpeciesTypeName = "Tenontosaurus",

                },
                 new SpeciesType
                 {
                     id = 4,
                     SpeciesTypeName = "Brachiosaurus",

                 },
                  new SpeciesType
                  {
                      id = 5,
                      SpeciesTypeName = "Ankylosaurus",

                  }
                  , new SpeciesType
                  {
                      id = 6,
                      SpeciesTypeName = "Triceratops",

                  }
                  , new SpeciesType
                  {
                      id = 12,
                      SpeciesTypeName = "Ceratosaurus",

                  },
                   new SpeciesType
                   {
                       id = 7,
                       SpeciesTypeName = "Carnotaurus",

                   },
                    new SpeciesType
                    {
                        id = 8,
                        SpeciesTypeName = "Tyrannosaurus",

                    },
                    new SpeciesType
                    {
                        id = 9,
                        SpeciesTypeName = "Velociraptor",

                    },
                    new SpeciesType
                    {
                        id = 10,
                        SpeciesTypeName = "Spinosaurus",

                    },
                    new SpeciesType
                    {
                        id = 11,
                        SpeciesTypeName = "Megalosaurus",

                    }
           );

            modelBuilder.Entity<FoodType>().HasData(
                new FoodType
                {
                    id = 1,
                    FoodTypeDescription = "Carnivore",
                   
                },

                new FoodType
                {
                    id = 2,
                    FoodTypeDescription = "Herbivore",
                    
                }    
            );
        }


    }
}
