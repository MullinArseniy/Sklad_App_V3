using Sklad_project_app.Models;
using NUnit.Framework.Legacy;

namespace Sklad_project_app.Tests
{
    [TestFixture]
    public class ShipmentTests
    {
        [Test]
        public void CanCreateShipment()
        {
            // Arrange
            using (var db = TestDbHelper.CreateInMemoryContext())
            {
                TestDbHelper.SeedTestData(db);

                var client = db.Clients.FirstOrDefault();
                var user = db.Users.FirstOrDefault();
                var product = db.Products.FirstOrDefault();

                Assert.IsNotNull(client);
                Assert.IsNotNull(user);
                Assert.IsNotNull(product);

                var newShipment = new Shipment
                {
                    Id = Guid.NewGuid(),
                    ClientId = client.Id,
                    UserId = user.Id,
                    ShipmentDate = DateTime.Today
                };

                // Act
                db.Shipments.Add(newShipment);
                db.SaveChanges();

                var shipmentItem = new ShipmentItem
                {
                    Id = Guid.NewGuid(),
                    ShipmentId = newShipment.Id,
                    ProductId = product.Id,
                    Quantity = 2
                };

                db.ShipmentItems.Add(shipmentItem);

                var stock = db.Stocks
                    .Where(stockItem => stockItem.ProductId == product.Id)
                    .FirstOrDefault();

                if (stock != null)
                {
                    stock.Rest -= 2;
                }

                db.SaveChanges();

                var allShipments = db.Shipments.ToList();
                var allItems = db.ShipmentItems.ToList();
                var updatedStock = db.Stocks
                    .Where(stockItem => stockItem.ProductId == product.Id)
                    .FirstOrDefault();

                // Assert
                Assert.AreEqual(1, allShipments.Count);
                Assert.AreEqual(1, allItems.Count);
                Assert.AreEqual(12, updatedStock.Rest);
            }
        }

        [Test]
        public void CanGetShipmentsByUser()
        {
            // Arrange
            using (var db = TestDbHelper.CreateInMemoryContext())
            {
                TestDbHelper.SeedTestData(db);

                var client = db.Clients.FirstOrDefault();
                var user = db.Users.FirstOrDefault();

                var shipment1 = new Shipment
                {
                    Id = Guid.NewGuid(),
                    ClientId = client.Id,
                    UserId = user.Id,
                    ShipmentDate = DateTime.Today
                };

                var shipment2 = new Shipment
                {
                    Id = Guid.NewGuid(),
                    ClientId = client.Id,
                    UserId = user.Id,
                    ShipmentDate = DateTime.Today
                };

                db.Shipments.Add(shipment1);
                db.Shipments.Add(shipment2);
                db.SaveChanges();

                // Act
                var allShipments = db.Shipments.ToList();
                var userShipments = new System.Collections.Generic.List<Shipment>();

                foreach (var shipment in allShipments)
                {
                    if (shipment.UserId == user.Id)
                    {
                        userShipments.Add(shipment);
                    }
                }

                // Assert
                Assert.AreEqual(2, userShipments.Count);
            }
        }

        [Test]
        public void GetWeatherWarning_MinTempBelowMinus15_ReturnsSevereFreezeWarning()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal minTemperature = -20m;
            decimal maxTemperature = 5m;

            // Act
            var result = shipmentForm.GetWeatherWarning(minTemperature, maxTemperature);

            // Assert
            StringAssert.Contains("ВНИМАНИЕ! Аномальный мороз!", result);
        }

        [Test]
        public void GetWeatherWarning_MaxTempAbove35_ReturnsSevereHeatWarning()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal minTemperature = 10m;
            decimal maxTemperature = 40m;

            // Act
            var result = shipmentForm.GetWeatherWarning(minTemperature, maxTemperature);

            // Assert
            StringAssert.Contains("ВНИМАНИЕ! Аномальная жара!", result);
        }

        [Test]
        public void GetWeatherWarning_ComfortableConditions_ReturnsGoodWeatherMessage()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal minTemperature = 15m;
            decimal maxTemperature = 25m;

            // Act
            var result = shipmentForm.GetWeatherWarning(minTemperature, maxTemperature);

            // Assert
            StringAssert.Contains("Погодные условия благоприятны для доставки.", result);
        }

        [Test]
        public void GetWeatherWarning_ExtremelyLowTemperature_ReturnsSevereFreezeWarning()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal minTemperature = -50m;
            decimal maxTemperature = -10m;

            // Act
            var result = shipmentForm.GetWeatherWarning(minTemperature, maxTemperature);

            // Assert
            StringAssert.Contains("ВНИМАНИЕ! Аномальный мороз!", result);
        }

        [Test]
        public void GetWeatherWarning_ExtremelyHighTemperature_ReturnsSevereHeatWarning()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal minTemperature = 30m;
            decimal maxTemperature = 50m;

            // Act
            var result = shipmentForm.GetWeatherWarning(minTemperature, maxTemperature);

            // Assert
            StringAssert.Contains("ВНИМАНИЕ! Аномальная жара!", result);
        }

        [Test]
        public void GetWeatherWarning_EqualZeroTemperatures_ReturnsNormalCondition()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal temperature = 0m;

            // Act
            var result = shipmentForm.GetWeatherWarning(temperature, temperature);

            // Assert
            StringAssert.Contains("Погодные условия благоприятны для доставки.", result);
        }

        [Test]
        public void GetWeatherWarning_NegativeMaxTemperature_ReturnsColdWarning()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal minTemperature = -20m;
            decimal maxTemperature = -10m;

            // Act
            var result = shipmentForm.GetWeatherWarning(minTemperature, maxTemperature);

            // Assert
            StringAssert.Contains("ВНИМАНИЕ! Аномальный мороз!", result);
        }

        [Test]
        public void GetWeatherWarning_MixedZeroTemperatures_ReturnsNormalCondition()
        {
            // Arrange
            var shipmentForm = new ShipmentForm();
            decimal minTemperature = -5m;
            decimal maxTemperature = 5m;

            // Act
            var result = shipmentForm.GetWeatherWarning(minTemperature, maxTemperature);

            // Assert
            StringAssert.Contains("Погодные условия благоприятны для доставки.", result);
        }
    }
}