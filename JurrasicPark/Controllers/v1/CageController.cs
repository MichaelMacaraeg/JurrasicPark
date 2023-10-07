using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurrasicPark.Models.RequestModel;
using JurrasicPark.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JurrasicPark.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CageController : ControllerBase
    {
        public ICageService _cageService;
        public CageController(ICageService cageService)
        {
            _cageService = cageService;
        }
        [HttpGet]
        [Route("GetAllCages")]
        public ActionResult GetAllCages()
        {
            var cages = _cageService.GetAllCages();
            return Ok(cages);
        }
        [HttpGet]
        [Route("GetCageById")]
        public ActionResult GetCageById(int cageId)
        {
            var cage = _cageService.GetCageByID(cageId);
            return Ok(cage);
        }
        [HttpGet]
        [Route("GetCageCapacity")]
        public ActionResult GetCageCapacity(int cageId)
        {
            var cage = _cageService.GetCageCapacity(cageId);
            return Ok(cage);
        }
        [HttpPost]
        [Route("CreateCage")]
        public ActionResult CreateCage(CreateCage createCage)
        {
            var cage = _cageService.CreateCage(createCage);
            return Ok(cage);
        }
        [HttpPut]
        [Route("EditCagePower")]
        public ActionResult EditCagePower(int cageId, bool isPowered)
        {
            var cage = _cageService.UpdateCagePower(cageId, isPowered);
            return Ok(cage);
        }
    }
}
