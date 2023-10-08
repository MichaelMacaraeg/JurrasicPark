using JurrasicPark.Helper;
using JurrasicPark.Models;
using JurrasicPark.Models.RequestModel;
using JurrasicPark.Repository;
using JurrasicPark.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurrasicPark.Services
{
    public class CageService : ICageService
    {
        private JurrasicParkDbContext _jurrasicParkDBContext;
        public CageService(JurrasicParkDbContext jurrasicParkDBContext)
        {
            _jurrasicParkDBContext = jurrasicParkDBContext;
        }

        public List<Cage> GetAllCages()
        {
            var cages = _jurrasicParkDBContext.Cage.ToList();
            return cages;
        }

        public Cage GetCageByID(int id)
        {
            var cage = _jurrasicParkDBContext.Cage.Where(x=>x.Id == id).FirstOrDefault();
            return cage;
        }


        public Cage CreateCage(CreateCage _createdCage)
        {
            //Map Fields
            Cage createdCage = new Cage();
            createdCage.IsPowered = _createdCage.IsPowered;
            createdCage.MaxCapacity = _createdCage.MaxCapacity;
            //Save New Entity
            _jurrasicParkDBContext.Set<Cage>().Add(createdCage);
            _jurrasicParkDBContext.SaveChanges();

            return createdCage;
        }


        public string GetCageCapacity(int cageId)
        {
            var dinoList = _jurrasicParkDBContext.Dinosaur.Where(x => x.CageId == cageId).ToList();
            var cage = _jurrasicParkDBContext.Cage.Where(x => x.Id == cageId).FirstOrDefault();


            //Return in text format 
            string strFormat = String.Format("{0} out of {1}", dinoList.Count, cage.MaxCapacity);


            return strFormat;
        }

        public ActionResult<Cage> UpdateCagePower(int cageId, bool isOn)
        {
            var dinoList = _jurrasicParkDBContext.Dinosaur.Where(x => x.CageId == cageId).ToList();
            var cage = _jurrasicParkDBContext.Cage.Where(x => x.Id == cageId).FirstOrDefault();
           
            //Check if any dino is in cage.
            if (dinoList.Count >= 1)
            {
                return RulesStatusCodes.PoweringDownRestricted;
            }
    
            cage.IsPowered = isOn;
            _jurrasicParkDBContext.Update(cage);
            _jurrasicParkDBContext.SaveChanges();


            return cage; 
        }

        public Cage UpdateCage(Cage updatedDetail)
        {
            _jurrasicParkDBContext.Update(updatedDetail);
            _jurrasicParkDBContext.SaveChanges();
            return updatedDetail;
        }

         
    }
}
