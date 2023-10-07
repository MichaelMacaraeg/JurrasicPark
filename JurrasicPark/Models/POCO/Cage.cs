using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Models
{
    public class Cage
    {
        public int Id { get; set; }
        public bool IsPowered { get; set; }
        public int MaxCapacity { get; set; }
    }
}
