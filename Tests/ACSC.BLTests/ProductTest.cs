using System;
using System.Linq;
using ACSC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACSC.BLTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ValidColumnTest()
        {
            //-- Arrange
            decimal _currentPrice;
            decimal _maxPrice;
            decimal _minPrice;

            Product product = new Product
            {
                Name = "Test",
                Description = "Test",
                MaxPrice = decimal.TryParse(".5", out _maxPrice) ? _maxPrice : _maxPrice,
                MinPrice = decimal.TryParse(".5", out _minPrice) ? _minPrice : _minPrice

            };

            product.CurrentPrice = decimal.TryParse(string.Empty, out _currentPrice) ? _currentPrice : _currentPrice;
            var actual = product.ValidateSearchField;

            //-- Act


            //-- Assert
            Assert.AreEqual(3, actual.Count());
            //Assert.AreEqual(2, product.MaxPrice);
        }

        [TestMethod]
        public void ValidTest()
        {
            //-- Arrange
            decimal _currentPrice;
            decimal _maxPrice;
            decimal _minPrice;

            Product product = new Product
            {
                Name = "Test",
                Description = "Test",
                MaxPrice = decimal.TryParse(".5", out _maxPrice) ? _maxPrice : _maxPrice,
                MinPrice = decimal.TryParse(".5", out _minPrice) ? _minPrice : _minPrice

            };

            product.CurrentPrice = decimal.TryParse(".01", out _currentPrice) ? _currentPrice : _currentPrice;
            var actual = product.Validate;

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
            //Assert.AreEqual(2, product.MaxPrice);
        }

    }
}
