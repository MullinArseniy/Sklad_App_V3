using System;
using System.Drawing;
using NUnit.Framework;
using Sklad_project_app;
using Sklad_project_app.Models;

namespace Sklad_project_app.Tests
{
    public class HeatMapTests
    {
        [SetUp]
        public void PrepareCurrentUser()
        {
            // Создаем тестовую роль "Кладовщик"
            var storekeeperRole = new Role
            {
                Id = Guid.NewGuid(),
                RoleName = "Кладовщик" // Названия ролей должны совпадать с тем, что в приложении
            };

            var testUser = new User
            {
                Id = Guid.NewGuid(),
                Surname = "Тестов",
                Name = "Иван",
                Patronymic = "Иванович",
                Role_id = storekeeperRole.Id,
                Role = storekeeperRole,
                Login = "test_user",
                Password = "password"
            };

            CurrentUser.User = testUser;
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsNegative_ReturnsDarkRed()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = -5; // Товар просрочен

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(220, 50, 50), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsTwo_ReturnsRed()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 2;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(255, 80, 80), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsFive_ReturnsOrange()
        {
            // Arrange
            HeatMapForm form = new HeatMapForm();
            int daysLeft = 5;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(255, 160, 0), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsTen_ReturnsYellow()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 10;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(255, 230, 0), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsTwenty_ReturnsLightGreen()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 20;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(150, 220, 100), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsForty_ReturnsGreen()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 40;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(80, 200, 80), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsThree_ReturnsRed()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 3;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(255, 80, 80), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsSeven_ReturnsOrange()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 7;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(255, 160, 0), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsFourteen_ReturnsYellow()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 14;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(255, 230, 0), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsThirty_ReturnsLightGreen()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 30;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(150, 220, 100), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsVeryLarge_ReturnsGreen()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 1000;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(80, 200, 80), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsExtremelyNegative_ReturnsDarkRed()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = -1000;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(220, 50, 50), resultColor);
        }

        [Test]
        public void GetCellColor_WhenDaysLeftIsZero_ReturnsDarkRed()
        {
            // Arrange
            var form = new HeatMapForm();
            int daysLeft = 0;

            // Act
            Color resultColor = form.GetCellColor(daysLeft);

            // Assert
            Assert.AreEqual(Color.FromArgb(220, 50, 50), resultColor);
        }
    }
}