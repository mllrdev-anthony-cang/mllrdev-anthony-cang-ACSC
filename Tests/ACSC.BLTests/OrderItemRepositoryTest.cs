using System;
using ACSC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACSC.BLTests
{
    [TestClass]
    public class OrderItemRepositoryTest
    {
        [TestMethod]
        public void SqlTest()
        {
            //-- Arrange
            var orderitem = new OrderItem
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 1,
                PurchasePrice = 99999
            };
            var db = new OrderItemRepository();
            var actual = db.SqlView(orderitem);

            //-- Act


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 * FROM OrderItem WHERE MarkAs = 'Active' " +
                "AND OrderId = 1 AND ProductId = 1", actual);
        }

        [TestMethod]
        public void SqlSelectAllTest()
        {
            //-- Arrange
            var orderitem = new OrderItem();
            var db = new OrderItemRepository();
            var actual = db.SqlView(orderitem);

            //-- Act


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 * FROM OrderItem WHERE MarkAs = 'Active'", actual);
        }

        [TestMethod]
        public void NewSaveTest()
        {
            //-- Arrange
            var orderitem = new OrderItem
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 1,
                PurchasePrice = 99999
            };
            var db = new OrderItemRepository();
            var actual = db.Save(orderitem);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void UpdateSaveTest()
        {
            //-- Arrange
            var orderitem = new OrderItem
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 20,
                PurchasePrice = 88888
            };
            var db = new OrderItemRepository();
            var actual = db.Save(orderitem);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //-- Arrange
            var orderitem = new OrderItem
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 20,
                PurchasePrice = 88888
            };
            var db = new OrderItemRepository();
            var actual = db.Remove(orderitem);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }
    }
}
