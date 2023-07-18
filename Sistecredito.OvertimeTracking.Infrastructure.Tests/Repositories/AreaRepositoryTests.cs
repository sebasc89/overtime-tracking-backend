using Microsoft.EntityFrameworkCore;
using Moq;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Infrastructure.Data;
using Sistecredito.OvertimeTracking.Infrastructure.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Tests.Repositories
{
    public class AreaRepositoryTests
    {
        [Fact]
        public async Task CreateAsync_Should_AddEntityToTable_And_SaveChanges_When_AutoSaveIsTrue()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var entityMock = new Mock<Area>();

            var dbSetMock = new Mock<DbSet<Area>>(); // Mock de DbSet<Area>
            dbContextMock.Setup(db => db.Set<Area>()).Returns(dbSetMock.Object); // Configurar el DbSet en el objeto mock

            // Configurar propiedades
            entityMock.SetupGet(x => x.AreaId).Returns(1);
            entityMock.SetupGet(x => x.Name).Returns("Prueba");

            var repository = new AreaRepository(dbContextMock.Object);

            // Act
            var result = await repository.CreateAsync(entityMock.Object, true);

            // Assert
            dbContextMock.Verify(db => db.AddAsync(entityMock.Object, default), Times.Once);
            dbContextMock.Verify(db => db.SaveChangesAsync(default), Times.Once);
            Assert.Equal(entityMock.Object, result);
        }
    }
}
