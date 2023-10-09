using JurrasicPark.Helper;
using JurrasicPark.Models;
using JurrasicPark.Models.POCO.ResponseModel;
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

    public class DinosaurService : IDinosaurService
    {
        public JurrasicParkDbContext _jurrasicParkDBContext;
        public DinosaurService(JurrasicParkDbContext jurrasicParkDBContext)
        {
            _jurrasicParkDBContext = jurrasicParkDBContext;
        }

        public List<ResponseDinosaur> GetAllDinosaurs()
        {
            var dinosaurs = _jurrasicParkDBContext.Dinosaur.ToList();
            return MapListResponse(dinosaurs);
        }

        public ResponseDinosaur GetDinosaursById(int id)
        {
            var dinosaur = _jurrasicParkDBContext.Dinosaur.Where(x=>x.Id == id).FirstOrDefault();
            return MapResponse(dinosaur);
        }

        public ResponseDinosaur CreateDinosaur(CreateDinosaur createdDinosaur)
        {
            Dinosaur dinosaur = new Dinosaur();
            dinosaur.CageId = createdDinosaur.CageId;
            dinosaur.Name = createdDinosaur.Name;
            dinosaur.SpeciesTypeId = createdDinosaur.SpeciesTypeId;
            dinosaur.FoodTypeId = createdDinosaur.FoodTypeId;

            _jurrasicParkDBContext.Add(dinosaur);
            _jurrasicParkDBContext.SaveChanges();

            //return dinosaur with description.
            return MapResponse(dinosaur);
        }

        public List<ResponseDinosaur> GetListDinosaursCagedById(int cageId)
        {
            var dinoList = _jurrasicParkDBContext.Dinosaur.Where(x => x.CageId == cageId).ToList();
            return MapListResponse(dinoList);
        }

        public ActionResult<ResponseDinosaur> MoveDinosaur(int dinosaurId, int cageId)
        {
            var cage = _jurrasicParkDBContext.Cage.Where(x => x.Id == cageId).FirstOrDefault(); //Grabs cage.
            var dinoList = _jurrasicParkDBContext.Dinosaur.Where(x => x.CageId == cageId).ToList();
            var editedDinosaur = _jurrasicParkDBContext.Dinosaur.Where(x => x.Id == dinosaurId).FirstOrDefault();

            var isCarnivor = dinoList.Find(item => item.FoodTypeId == 1); //Is Herbivor
            var type = dinoList.All(item => item.SpeciesTypeId == editedDinosaur.SpeciesTypeId); //Not all same Species

            //Check is power on.
            if (cage.IsPowered == false)
            {
                return RulesStatusCodes.CagePoweredDown;
            }

            //Cage is empty skip process
            if (dinoList.Count > 0)
            {
                //Check is Cage Full
                if (cage.MaxCapacity < dinoList.Count)
                {
                    return RulesStatusCodes.MaxCapacity;
                }

                //Herbivor but there is a carnivor in cage.
                if (isCarnivor != null && editedDinosaur.FoodTypeId == 2)
                {
                    return RulesStatusCodes.CageDangerous;
                }

                //Carnivore but no same species.
                if (isCarnivor != null && type == false)
                {
                    return RulesStatusCodes.CageDangerous;
                }

                //check if dinosaur found.
                if (editedDinosaur == null)
                {
                    return RulesStatusCodes.DinosaurNotFound;
                }
            }

            //Update Dinosaur
            editedDinosaur.CageId = cageId;
             _jurrasicParkDBContext.Update(editedDinosaur);
            _jurrasicParkDBContext.SaveChanges();

            //return with updated cageID
            return MapResponse(editedDinosaur);
        }

        private ResponseDinosaur MapResponse(Dinosaur createdDinosaur)
        {
            ResponseDinosaur responseDinosaur = new ResponseDinosaur();
            responseDinosaur.Id = createdDinosaur.Id;
            responseDinosaur.CageId = createdDinosaur.CageId;
            responseDinosaur.Name = createdDinosaur.Name;
            responseDinosaur.SpeciesTypeDescription = _jurrasicParkDBContext.SpeciesType.Where(x => x.id == createdDinosaur.SpeciesTypeId).Select(c => c.SpeciesTypeName).FirstOrDefault();
            responseDinosaur.FoodTypeDescription = _jurrasicParkDBContext.FoodType.Where(x => x.id == createdDinosaur.FoodTypeId).Select(c => c.FoodTypeDescription).FirstOrDefault();
            return responseDinosaur;
        }

        private List<ResponseDinosaur> MapListResponse(List<Dinosaur> createdListDinosaur)
        {
            List<ResponseDinosaur> lResponseDinosaurs = new List<ResponseDinosaur>();
            foreach(var dinosaur in createdListDinosaur)
            {
                ResponseDinosaur responseDinosaur = new ResponseDinosaur();
                responseDinosaur.Id = dinosaur.Id;
                responseDinosaur.CageId = dinosaur.CageId;
                responseDinosaur.Name = dinosaur.Name;
                responseDinosaur.SpeciesTypeDescription = _jurrasicParkDBContext.SpeciesType.Where(x => x.id == dinosaur.SpeciesTypeId).Select(c => c.SpeciesTypeName).FirstOrDefault();
                responseDinosaur.FoodTypeDescription = _jurrasicParkDBContext.FoodType.Where(x => x.id == dinosaur.FoodTypeId).Select(c => c.FoodTypeDescription).FirstOrDefault();
                lResponseDinosaurs.Add(responseDinosaur);
            }
            return lResponseDinosaurs;
        }
    }
}
