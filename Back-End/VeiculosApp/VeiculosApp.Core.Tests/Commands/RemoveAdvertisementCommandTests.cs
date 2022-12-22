using System;
using VeiculosApp.Core.Domain.Commands;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class RemoveAdvertisementCommandTests
    {
        [Fact]
        public void Constructor_WithValidId_SetsIdProperty()
        {
            // Arrange
            int id = 1;

            // Act
            var command = new RemoveAdvertisementCommand(id);

            // Assert
            Assert.Equal(id, command.Id);
        }

        [Fact]
        public void Constructor_WithInvalidId_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int id = 0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new RemoveAdvertisementCommand(id));
        }
    }
}
