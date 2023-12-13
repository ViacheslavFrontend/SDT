using BLL.Services.Impl;
using CLL.Security.Indentity;
using CLL.Security;
using DAL.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL.Entities;

namespace BLL.Tests
{
    public class DishServiceTests
    {
        [Fact]
        public void Ctor_InputNullUnitOfWork_ThrowsArgumentNullException()
        {
            // Arrange
            IUnitOfWork unitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new DishService(unitOfWork
                ));
        }

        [Fact]
        public void GetDishesByMenu_InputAdminUser_ThrowsMethodAccessException()
        {
            // Arrange
            SecurityContext.SetUser(new Admin(3, "Адміністратор тест"));

            var mocлUnitOfWork = new Mock<IUnitOfWork>();
            var mockDishService = new Mock<DishService>(mocлUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(
                () => mockDishService.Object.GetDishesByMenu(13)
                );
        }


        [Fact]
        public void GetDishesByMenu_InputAccountantUser_ThrowsMethodAccessException()
        {
            // Arrange
            SecurityContext.SetUser(new Accountant(3, "Звичайний акаунт тест"));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockDishService = new Mock<DishService>(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(
                () => mockDishService.Object.GetDishesByMenu(13)
                );
        }


        [Fact]
        public void GetDishesByMenu_InputChiefUserAndNullMenuId_ThrowsMethodAccessException()
        {
            // Arrange
            SecurityContext.SetUser(new Chief(1, "Шеф тест"));

            var mockMenusRepository = new Mock<IMenusRepository>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(unit => unit.menusRepository)
                .Returns(mockMenusRepository.Object);

            var mockDishService = new Mock<DishService>(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<NullReferenceException>(
                () => mockDishService.Object.GetDishesByMenu(13)
                );
        }


        [Fact]
        public void GetDishesByMenu_InputChiefUserAndMenuId_CallsFindMethodOfDishedRepository()
        {
            // Arrange
            SecurityContext.SetUser(new Chief(1, "Шеф тест"));

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var mockMenusRepository = new Mock<IMenusRepository>();
            mockUnitOfWork
                .Setup(unit => unit.menusRepository)
                .Returns(mockMenusRepository.Object);

            var mockDishesRepository = new Mock<IDishesRepository>();
            mockUnitOfWork
                .Setup(unit => unit.dishesRepository)
                .Returns(mockDishesRepository.Object);

            mockMenusRepository
                .Setup(repo => repo.GetById(9))
                .Returns(new Menu());

            var mockDishService = new Mock<DishService>(mockUnitOfWork.Object);

            // Act
            var actionResult = mockDishService.Object.GetDishesByMenu(9);

            // Assert
            mockDishesRepository.Verify(
                repo => repo.Find(It.IsAny<Func<Dish, bool>>()), Times.Once);
        }
    }
}
