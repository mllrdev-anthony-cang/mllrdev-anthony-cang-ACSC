using System;
using System.Linq;
using ACSC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACSC.BLTests
{
    [TestClass]
    public class AddressRepositoryTests
    {
        [TestMethod]
        public void SqlViewTest()
        {
            //-- Arrange
            var customer = new Customer
            {
                Id = 1
            };

            var address = new Address
            {
                CityMunicipality = "Dauin",
                Barangay = "District",
                CustomerId = customer.Id
            };
            var db = new AddressRepository();
            var actual = db.SqlView(address);

            //-- Act
            var expected = $"SELECT TOP 1000 * FROM Address WHERE MarkAs = 'Active' AND CustomerId = {address.CustomerId} AND CityMunicipality LIKE 'Dauin%'";

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByNameTest()
        {
            //-- Arrange
            var customer = new Customer
            {
                Id = 1
            };

            var address = new Address
            {
                CityMunicipality = "Dauin",
                Barangay = "District",
                CustomerId = customer.Id
            };

            var db = new AddressRepository();
            var actual = db.GetBy(address);

            //-- Act


            //-- Assert
            Assert.AreEqual(1, actual.Count());
        }

        [TestMethod]
        public void GetByIdTest()
        {
            //-- Arrange
            var customer = new Customer
            {
                Id = 1
            };

            var address = new Address
            {
                CityMunicipality = "Dauin",
                CustomerId = customer.Id,
                Id = 1
            };
            var db = new AddressRepository();
            var actual = db.GetBy(address);

            //-- Act


            //-- Assert
            Assert.AreEqual("Dauin", actual[0].CityMunicipality);
        }

        [TestMethod]
        public void NewSaveTest()
        {
            //-- Arrange
            var address = new Address
            {
                HouseBuildingStreet = "test",
                Province = "test",
                CityMunicipality="test",
                Barangay="test",
                CustomerId=1

            };
            var db = new AddressRepository();
            var actual = db.Save(address);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void UpdateSaveTest()
        {
            //-- Arrange
            var address = new Address
            {
                Id = 2,
                HouseBuildingStreet = "this street",
                Province = "test",
                CityMunicipality = "test",
                Barangay = "test",
                CustomerId = 1
            };
            var db = new AddressRepository();
            var actual = db.Save(address);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //-- Arrange
            var address = new Address
            {
                Id = 2
            };
            var db = new AddressRepository();
            var actual = db.Remove(address);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }
    }
}
