using JurrasicPark.Models.RequestModel;
using JurrasicPark.Repository;
using JurrasicPark.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurrsaicParkTest
{
    [TestClass]
    public class CageTest
    {
        [TestMethod]
        public void GetAllCages_ReturnList()
        {
            // Gets All Cage Data
            //Arrange
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new CageService(repo);
            var result = service.GetAllCages();
            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetCageById_ReturnCage()
        {
            //Gets Cage Data
            //Arrange
            var cageId = 1;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new CageService(repo);
            var result = service.GetCageByID(cageId);
            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetCageCapacity_ReturnString()
        {
            //Get String with text 
            //Arrange
            var cageId = 1;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new CageService(repo);
            var result = service.GetCageCapacity(cageId);
            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void CreateCage_ReturnCage()
        {
            //Creates Cage with new ID
            CreateCage cage = new CreateCage();
            cage.IsPowered = false;
            cage.MaxCapacity = 15;
            //Arrange
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new CageService(repo);
            var result = service.CreateCage(cage);
            //Assert
            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void EditCagePowerOn_ReturnCage()
        {
            //Updates Cage to power on 
            //Arrange
            var cageId = 5;
            bool isPowered = true;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new CageService(repo);
            var result = service.UpdateCagePower(cageId, isPowered);
            //Assert
            Assert.IsNotNull(result.Value);

        }


        [TestMethod]
        public void EditCagePoweroff_ReturnCage()
        {
            //Dinosaur in cage and not able to turn off.
            var cageId = 5;
            bool isPowered = true;
            //Act
            var repo = new JurrasicParkDbContext();
            var service = new CageService(repo);
            var result = service.UpdateCagePower(cageId, isPowered);
            //Assert
            Assert.IsNull(result.Value);

        }
    }
}
