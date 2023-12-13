using DAL.Entities;
using Microsoft.EntityFrameworkCore;
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
        public void GetById_InputId_CalledFindMethodOfDnSetWithInputId()
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
    }
}
