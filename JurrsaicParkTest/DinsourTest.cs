using JurrasicPark.Models;
using JurrasicPark.Models.RequestModel;
using JurrasicPark.Repository;
using JurrasicPark.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JurrsaicParkTest
{
    [TestClass]
    public class DinsourTest
    {
        [TestMethod]
        public void GetAllDinosaurs_ReturnList()
        {
            //Arrange
         
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new DinosaurService(repo); 
            var result = service.GetAllDinosaurs();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDinosaursById_ReturnDinosaur()
        {
            var dinosaurId = 1;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new DinosaurService(repo);
            var result = service.GetDinosaursById(dinosaurId);

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void MoveDinosaur_ReturnDinosaur()
        {
            //Arrange
            var dinosaurId = 1;
            var cageId = 5;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new DinosaurService(repo);
            var result = service.MoveDinosaur(dinosaurId,cageId);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MoveDinosaur_ReturnNull()
        {
            //Herbivore To Carnivore
            //Arrange
            var dinosaurId = 3;
            var cageId = 5;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new DinosaurService(repo);
            var result = service.MoveDinosaur(dinosaurId, cageId);
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CreateDinosaur_ReturnDinosaur()
        {
            //Arrange
            CreateDinosaur dinosaur = new CreateDinosaur();
            dinosaur.Name = "Rex";
            dinosaur.FoodTypeId = 1;
            dinosaur.SpeciesTypeId = 8;
            dinosaur.CageId = 0;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new DinosaurService(repo);
            var result = service.CreateDinosaur(dinosaur);

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetListDinosaursCagedById_ReturnList()
        {
            var cageId = 5;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new DinosaurService(repo);
            var result = service.GetListDinosaursCagedById(cageId);
            //Assert
            Assert.IsNotNull(result);
        }

        public void GetListDinosaursCagedByIdEmpty_ReturnList()
        {
            //Gets cage that is empty
            var cageId = 1;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new DinosaurService(repo);
            var result = service.GetListDinosaursCagedById(cageId);
            //Assert
            Assert.IsNull(result);
        }
    }
}
