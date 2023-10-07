using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Models.RequestModel
{
    public class CreateCage
    {
        public bool IsPowered { get; set; }
        public int MaxCapacity { get; set; }
    }
}
