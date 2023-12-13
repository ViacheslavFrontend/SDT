using AutoMapper;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CLL.Security;
using CLL.Security.Indentity;
using DAL;
using DAL.Entities;
using DAL.Repository.Implementations;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    public class MenuServiceTests
    {
        [Fact]
        public void Ctor_InputNullMenuRepository_ThrowsArgumentNullException()
        {
            // Arrange
            IMenusRepository menusRepository = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new MenuService(menusRepository
                ));
        }

        [Fact]
        public void GetMenus_InputAdminUser_ThrowsMethodAccessException()
        {
            // Arrange
            SecurityContext.SetUser(new Admin(2, "Адміністратор тест"));

            var mockMenusRepository = new Mock<IMenusRepository>();
            var mockMenuService = new Mock<MenuService>(mockMenusRepository.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(
                () => mockMenuService.Object.GetMenus()
                );
        }

        [Fact]
        public void GetMenus_InputChiefUser_ReturnsRightDTOObjects()
        {

            // Arrange
            SecurityContext.SetUser(new Chief(1, "Шефт тест"));

            var mockMenusRepository = new Mock<IMenusRepository>();

            var menu1 = new Menu() { Name = "Дієтичне меню"};
            var menu2 = new Menu() { Name = "М'ясне меню" };

            var menusList = new List<Menu>();
            menusList.Add(menu1);
            menusList.Add(menu2);

            mockMenusRepository
                .Setup(set => set.GetAll())
                .Returns(menusList);

            var mockMenuService = new Mock<MenuService>(mockMenusRepository.Object);
            
            // Act

            var actionResult = mockMenuService.Object.GetMenus();

            // Assert 
             
            Assert.Equivalent(actionResult.ToArray()[0], menusList[0]);
            Assert.Equivalent(actionResult.ToArray()[1], menusList[1]);
        }
    }
}
