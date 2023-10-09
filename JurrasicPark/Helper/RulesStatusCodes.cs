using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Helper
{
    public class RulesStatusCodes
    {
        public static ActionResult PoweringDownRestricted => new ObjectResult(new { Error = "Unable to turn power off cage is occupied." })
        { StatusCode = 500 };
        public static ActionResult MaxCapacity => new ObjectResult(new { Error = "Cage is at maximum capacity." })
        { StatusCode = 500 };
        public static ActionResult CageDangerous => new ObjectResult(new { Error = "Identical species carnivore only cage." })
        { StatusCode = 500 };
        public static ActionResult CagePoweredDown => new ObjectResult(new { Error = "Cage is powered down." })
        { StatusCode = 500 };
        public static ActionResult DinosaurNotFound => new ObjectResult(new { Error = "Dinosaur not found." })
        { StatusCode = 500 };
        public static ActionResult CagePowerOn => new ObjectResult(new { Error = "Power is already on." })
        { StatusCode = 200 };
    }
}
