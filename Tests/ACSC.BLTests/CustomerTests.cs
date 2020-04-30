using System;
using System.Linq;
using ACSC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACSC.BLTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void FullNameValid()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                FirstName = "Anthony",
                LastName = "Cang"
            };
            string expected = "Anthony Cang";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomerValid()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                FirstName = "Anthony",
                LastName = "Cang",
                PhoneNumber = "+67523923324"
            };
            bool expected = true;

            //-- Act
            bool actual = customer.IsValid;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidColumnsTest()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                FirstName = "Anthony",
                LastName = "Cang",
                PhoneNumber = "+67523923324"
            };
            var expected = 3;

            //-- Act
            var actual = customer.ValidateSearchField;

            //-- Assert
            Assert.AreEqual(expected, actual.Count());
        }
    }
}
