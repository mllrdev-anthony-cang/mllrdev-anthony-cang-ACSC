using System;
using ACSC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACSC.BLTests
{
    [TestClass]
    public class OrderRepositoryTest
    {

        [TestMethod]
        public void SqlTest()
        {
            //-- Arrange
            var orderdate = DateTime.Now;
            var minDate = DateTime.Parse("03/03/2020");
            var maxDate = DateTime.Parse("03/04/2020");
            var order = new Order
            {
                Id = 0,
                CustomerId = 1,
                AddressId = 1,
                OrderDate = orderdate,
                TotalAmount = 999,
                MinOrderDate = minDate.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                MaxOrderDate = maxDate.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                CustomerName = "An",
                CustomerPhoneNumber = "090",
                ShippingAddress = "da"
            };
            var db = new OrderRepository();
            var actual = db.SqlView(order);

            //-- Act


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 O.Id, O.AddressId, O.CustomerId, O.TotalAmount, O.OrderDate, C.FirstName, C.LastName, C.PhoneNumber, A.Barangay, A.CityMunicipality, A.HouseBuildingStreet, A.Province FROM [Order] AS O INNER JOIN [Customer] AS C ON C.Id = O.CustomerId INNER JOIN [Address] AS A ON A.Id = O.AddressId WHERE O.MarkAs = 'Active' AND O.CustomerId = 1 AND O.AddressId = 1 AND O.OrderDate BETWEEN '2020-03-03 00:00:00.000' AND '2020-04-03 00:00:00.000'", actual);
        }

        [TestMethod]
        public void SqlSelectAllTest()
        {
            //-- Arrange
            var order = new Order();
            var db = new OrderRepository();
            var actual = db.SqlView(order);


            //-- Assert
            Assert.AreEqual("SELECT TOP 1000 * FROM Order WHERE MarkAs = 'Active'", actual);
        }

        [TestMethod]
        public void NewSaveTest()
        {
            //-- Arrange
            var order = new Order
            {
                Id = 0,
                CustomerId = 1,
                AddressId = 1,
                OrderDate = DateTime.Now,
                TotalAmount = 999,
                //MinOrderDate = DateTime.Now,
                //MaxOrderDate = DateTime.Now
            };
            var db = new OrderRepository();
            var actual = db.Save(order);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void UpdateSaveTest()
        {
            //-- Arrange
            var order = new Order
            {
                Id = 1,
                CustomerId = 1,
                AddressId = 1,
                OrderDate = DateTime.Now,
                TotalAmount = 888,
                //MinOrderDate = DateTime.Now,
                //MaxOrderDate = DateTime.Now
            };
            var db = new OrderRepository();
            var actual = db.Save(order);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //-- Arrange
            var order = new Order
            {
                Id = 1,
                CustomerId = 1,
                AddressId = 1,
                OrderDate = DateTime.Now,
                TotalAmount = 888,
                //MinOrderDate = DateTime.Now,
                //MaxOrderDate = DateTime.Now
            };
            var db = new OrderRepository();
            var actual = db.Remove(order);

            //-- Act


            //-- Assert
            Assert.AreEqual(true, actual);
        }
    }
}
