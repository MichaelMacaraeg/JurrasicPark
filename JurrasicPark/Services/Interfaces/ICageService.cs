using JurrasicPark.Models;
using JurrasicPark.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Services.Interfaces
{
    public interface ICageService
    {
        List<Cage> GetAllCages();
        Cage GetCageByID(int id);
        Cage CreateCage(CreateCage createdCage);
        string GetCageCapacity(int cageId);
        ActionResult<Cage> UpdateCagePower(int cageId, bool isOn);
        Cage UpdateCage(Cage updatedDetail);
    }
}
