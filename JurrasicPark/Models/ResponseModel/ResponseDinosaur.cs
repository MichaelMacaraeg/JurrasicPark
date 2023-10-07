using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Models.POCO.ResponseModel
{
    public class ResponseDinosaur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpeciesTypeDescription { get; set; }
        public string FoodTypeDescription { get; set; }
        public int CageId { get; set; }
    }
}
