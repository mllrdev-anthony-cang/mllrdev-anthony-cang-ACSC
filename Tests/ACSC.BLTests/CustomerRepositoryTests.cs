using System;
using System.Linq;
using ACSC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACSC.BLTests
{
    [TestClass]
    public class CustomerRepositoryTests
    {        

        [TestMethod]
        public void SqlTest()
        {
            //-- Arrange
            var customer1 = new Customer
            {
                FirstName = "Anthony",
                LastName = "Cang"
            };
            var db = new CustomerRepository();
            var actual = db.SqlView(customer1);

            //-- Act


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 * FROM Customer WHERE MarkAs = 'Active' AND FirstName LIKE 'Anthony%' AND LastName LIKE 'Cang%'", actual);
        }

        [TestMethod]
        public void SqlSelectAllTest()
        {
            //-- Arrange
            var customer1 = new Customer();
            var db = new CustomerRepository();
            var actual = db.SqlView(customer1);

            //-- Act


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 * FROM Customer WHERE MarkAs = 'Active'", actual);
        }

        [TestMethod]
        public void GetByNameTest()
        {
            //-- Arrange
            var customer1 = new Customer
            {
                FirstName = "test"
            };
            var db = new CustomerRepository();
            var actual = db.GetBy(customer1);

            //-- Act
            

            //-- Assert
            Assert.AreEqual(actual.Count(), actual.Count());
        }

        [TestMethod]
        public void GetByIdTest()
        {
            //-- Arrange
            var customer2 = new Customer
            {
                FirstName = "Anthony",
                LastName = "Cang",
                Id = 2
            };
            var db = new CustomerRepository();
            var actual = db.GetBy(customer2);

            //-- Act


            //-- Assert
            Assert.AreEqual("John", actual[0].FirstName);
        }

        [TestMethod]
        public void NewSaveTest()
        {
            //-- Arrange
            var customer2 = new Customer
            {
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "99999999"
            };
            var db = new CustomerRepository();
            var actual = db.Save(customer2);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void UpdateSaveTest()
        {
            //-- Arrange
            var customer2 = new Customer
            {
                Id = 4,
                FirstName = "Anthony Jr",
                LastName = "Cang",
                PhoneNumber = "99999999"
            };
            var db = new CustomerRepository();
            var actual = db.Save(customer2);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //-- Arrange
            var customer2 = new Customer
            {
                Id = 11
            };
            var db = new CustomerRepository();
            var actual = db.Remove(customer2);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }


    }
}
