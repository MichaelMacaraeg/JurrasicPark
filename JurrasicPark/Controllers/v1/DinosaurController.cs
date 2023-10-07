using JurrasicPark.Models.RequestModel;
using JurrasicPark.Services;
using JurrasicPark.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class DinosaurController : ControllerBase
    {
        public IDinosaurService _dinosaurService;
        public DinosaurController(IDinosaurService dinosaurService)
        {
            _dinosaurService = dinosaurService;

        }
        [HttpGet]
        [Route("GetAllDinosaurs")]
        public ActionResult GetAllDinosaurs()
        {
            var dinosaurs = _dinosaurService.GetAllDinosaurs();
            return Ok(dinosaurs);
        }
        [HttpGet]
        [Route("GetDinosaursById")]
        public ActionResult GetDinosaursById(int dinosaurId)
        {
            var dinosaur = _dinosaurService.GetDinosaursById(dinosaurId);
            return Ok(dinosaur);
        }
        [HttpPut]
        [Route("MoveDinosaur")]
        public ActionResult MoveDinosaur(int dinosaurId, int cageId)
        {
            var movedDinosaur = _dinosaurService.MoveDinosaur(dinosaurId, cageId);
            return Ok(movedDinosaur);
        }
        [HttpPost]
        [Route("CreateDinosaur")]
        public ActionResult CreateDinosaur(CreateDinosaur createDinosaur)
        {
            var createdDinosaur = _dinosaurService.CreateDinosaur(createDinosaur);
            return Ok(createdDinosaur);
        }
        [HttpGet]
        [Route("GetListDinosaursCagedById")]
        public ActionResult GetListDinosaursCagedById(int cageId)
        {
            var dinosaurList = _dinosaurService.GetListDinosaursCagedById(cageId);
            return Ok(dinosaurList);
        }
    }
}
