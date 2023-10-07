﻿using JurrasicPark.Helper;
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
            dinosaur.FoodTypeId = createdDinosaur.SpeciesTypeId;
            dinosaur.Id = createdDinosaur.FoodTypeId;

            _jurrasicParkDBContext.Set<Dinosaur>().Add(dinosaur);
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

            //Check is power on.
            if (cage.IsPowered == false)
            {
               return RulesStatusCodes.CagePoweredDown;
            }


            //Check is Cage Full
            if(cage.MaxCapacity< dinoList.Count)
            {
                return RulesStatusCodes.MaxCapacity;
            }


            //search for carnivor and type
            var carnivor = dinoList.Find(item => item.FoodTypeId == 1); //Is Carnivor
            var type = dinoList.All(item => item.SpeciesTypeId == editedDinosaur.SpeciesTypeId); //Not all same Species
            if (carnivor != null && type == false) 
            {
                return RulesStatusCodes.CageDangerous;
            }

            //check if dinosaur found.
            if(editedDinosaur == null)
            {
                return RulesStatusCodes.DinosaurNotFound;
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
