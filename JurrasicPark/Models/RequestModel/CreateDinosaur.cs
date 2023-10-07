using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Models.RequestModel
{
    public class CreateDinosaur
    {
        public string Name { get; set; }
        public int SpeciesTypeId { get; set; }
        public int FoodTypeId { get; set; }
        public int CageId { get; set; }
    }
}
