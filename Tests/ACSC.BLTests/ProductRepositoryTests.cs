using System;
using ACSC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACSC.BLTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void SqlTest()
        {
            //-- Arrange
            var product = new Product
            {
                Name = "test",
                Description = "test",
                MinPrice = 1,
                MaxPrice = 99999
            };
            var db = new ProductRepository();
            var actual = db.SqlView(product);

            //-- Act


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 * FROM Product WHERE MarkAs = 'Active' " +
                "AND Name LIKE 'test%' AND Description LIKE 'test%' AND CurrentPrice BETWEEN 1 AND 99999", actual);
        }

        [TestMethod]
        public void SqlSelectAllTest()
        {
            //-- Arrange
            var product = new Product();
            var db = new ProductRepository();
            var actual = db.SqlView(product);

            //-- Act


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 * FROM Product WHERE MarkAs = 'Active'", actual);
        }

        [TestMethod]
        public void NewSaveTest()
        {
            //-- Arrange
            var product = new Product
            {
                Name = "test",
                Description = "test",
                CurrentPrice = 1000
            };
            var db = new ProductRepository();
            var actual = db.Save(product);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void UpdateSaveTest()
        {
            //-- Arrange
            var product = new Product
            {
                Id = 2,
                Name = "testUpdate",
                Description = "testUpdate",
                CurrentPrice = 500
            };
            var db = new ProductRepository();
            var actual = db.Save(product);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //-- Arrange
            var product = new Product
            {
                Id = 2
            };
            var db = new ProductRepository();
            var actual = db.Remove(product);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }
    }
}
