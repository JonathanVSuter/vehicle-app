using System;
using VeiculosApp.Core.Domain.Commands;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class RemoveAdvertisementCommandTests
    {
        [Fact]
        public void RemoveAdvertisementCommand_WithValidId_SetsIdProperty()
        {            
            int id = 1;            
            var command = new RemoveAdvertisementCommand(id);
            Assert.Equal(id, command.Id);
        }

        [Fact]
        public void RemoveAdvertisementCommand_WithInvalidId_ThrowsArgumentOutOfRangeException()
        {
            int id = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => new RemoveAdvertisementCommand(id));
        }
    }
}
