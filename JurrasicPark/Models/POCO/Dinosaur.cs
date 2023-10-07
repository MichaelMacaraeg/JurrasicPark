using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Models
{
    public class Dinosaur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesTypeId { get; set; }
        public int FoodTypeId { get; set; }
        public int CageId { get; set; }
    }
}
