using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void GetById_InputId_CalledFindMethodOfDbSetWithInputId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FoodAppDbContext>().Options;
            var mockContext = new Mock<FoodAppDbContext>(opt);
            var mockDbSet = new Mock<DbSet<Menu>>();

            mockContext
               .Setup(context =>
                   context.Set<Menu>(
                       ))
               .Returns(mockDbSet.Object);

            Menu expectedMenu = new Menu() { Id = 1, Name = "Дієтичне меню" };

            mockDbSet
                .Setup(mock => 
                    mock.Find(expectedMenu.Id))
                .Returns(expectedMenu);

            var repository = new TestMenuRepository(mockContext.Object);

            // Act
            var actionResult = repository.GetById(expectedMenu.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(expectedMenu.Id), Times.Once
                );
            Assert.Equal(expectedMenu, actionResult);
        }

        [Fact]
        public void Delete_InputId_CalledGetByIdAndRemoveMethods()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FoodAppDbContext>().Options;
            var mockContext = new Mock<FoodAppDbContext>(opt);
            var mockDbSet = new Mock<DbSet<Menu>>();

            mockContext
               .Setup(context =>
                   context.Set<Menu>(
                       ))
               .Returns(mockDbSet.Object);

            Menu expectedMenu = new Menu() { Id = 1, Name = "Дієтичне меню" };

            var mockRepository = new Mock<TestMenuRepository>(mockContext.Object);

            mockRepository.Setup(repo =>
                repo.GetById(expectedMenu.Id)
                ).Returns(expectedMenu);

            var repository = mockRepository.Object;

            // Act
            repository.Delete(expectedMenu.Id);

            // Assert
            mockRepository.Verify(
                repo => repo.GetById(expectedMenu.Id), Times.Once
                );

            mockDbSet.Verify(
                dbSet => dbSet.Remove(expectedMenu), Times.Once
                );
        }

        [Fact]
        public void Update_InputMenu_CalledUpdateMethodOfDbSetWithInputMenu()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FoodAppDbContext>().Options;
            var mockContext = new Mock<FoodAppDbContext>(opt);
            var mockDbSet = new Mock<DbSet<Menu>>();

            mockContext
               .Setup(context =>
                   context.Set<Menu>(
                       ))
               .Returns(mockDbSet.Object);

            Menu expectedMenu = new Menu() { Id = 1, Name = "Дієтичне меню" };

            var mockRepository = new Mock<TestMenuRepository>(mockContext.Object);

            mockRepository.Setup(repo =>
                repo.GetById(expectedMenu.Id)
                ).Returns(expectedMenu);

            var repository = new TestMenuRepository(mockContext.Object);

            // Act
            repository.Update(expectedMenu);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Update(expectedMenu), Times.Once
                );
        }
    }
}
