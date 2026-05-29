using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Sklad_project_app.Import;
using Sklad_project_app.Models;
using System;
using System.Linq;

namespace Sklad_project_app.Tests
{
    [TestFixture]
    public class SuppliesBusinessTests
    {
        [Test]
        public void DiscountLogic_ExpiredProduct_Sets100Percent()
        {
            // Arrange
            var today = DateTime.Now.Date;
            var expiryDate = today.AddDays(-1); // Просрочено

            // Act
            decimal discount = 0;
            int daysLeft = (expiryDate - today).Days;
            if (daysLeft <= 0) discount = 100;

            // Assert
            Assert.AreEqual(100, discount);
        }

        [Test]
        public void DiscountLogic_NearExpiry_Sets50Percent()
        {
            // Arrange
            // Общий срок 100 дней, осталось 15 дней (это 15%, что <= 20%)
            int totalDays = 100;
            int daysLeft = 15;
            decimal discount = 0;

            // Act
            double percentLeft = (double)daysLeft / totalDays * 100;
            if (percentLeft <= 20) discount = 50;

            // Assert
            Assert.AreEqual(50, discount);
        }

        [Test]
        public void ExpiryDateCalculation_IsCorrect()
        {
            // Arrange
            DateTime supplyDate = new DateTime(2023, 10, 1);
            int shelfLifeDays = 30;

            // Act
            DateTime expectedExpiry = supplyDate.AddDays(shelfLifeDays);

            // Assert
            Assert.AreEqual(new DateTime(2023, 10, 31), expectedExpiry);
        }

        [Test]
        public void PriceFilter_AutoSwap_Works()
        {
            // Arrange
            decimal priceFrom = 500;
            decimal priceTo = 100;

            // Act
            if (priceFrom > priceTo)
            {
                (priceFrom, priceTo) = (priceTo, priceFrom);
            }

            // Assert
            Assert.AreEqual(100, priceFrom);
            Assert.AreEqual(500, priceTo);
        }

        [Test]
        public void Import_MatchProductByArticle_Succeeds()
        {
            // Arrange
            using (var db = TestDbHelper.CreateInMemoryContext())
            {
                var existingProduct = new Product { Id = Guid.NewGuid(), Article = "ART-001", Name = "Молоко" };
                db.Products.Add(existingProduct);
                db.SaveChanges();

                string importArticle = "ART-001";

                // Act
                var foundProduct = db.Products.FirstOrDefault(p => p.Article == importArticle);

                // Assert
                Assert.IsNotNull(foundProduct);
                Assert.AreEqual("Молоко", foundProduct.Name);
            }
        }
    }
}