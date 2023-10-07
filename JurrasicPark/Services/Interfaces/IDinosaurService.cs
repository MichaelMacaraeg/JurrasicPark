using JurrasicPark.Models;
using JurrasicPark.Models.POCO.ResponseModel;
using JurrasicPark.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Services.Interfaces
{
    public interface IDinosaurService
    {
        List<ResponseDinosaur> GetAllDinosaurs();
        ResponseDinosaur GetDinosaursById(int id);
        ResponseDinosaur CreateDinosaur(CreateDinosaur createdDinosaur);
        List<ResponseDinosaur> GetListDinosaursCagedById(int cageId);
        ActionResult<ResponseDinosaur> MoveDinosaur(int dinosaurId, int cageId);
    }
}
