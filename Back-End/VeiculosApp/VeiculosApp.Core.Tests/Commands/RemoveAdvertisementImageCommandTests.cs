using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class RemoveAdvertisementImageCommandTests
    {
        [Fact]
        public void RemoveAdvertisementImageCommand_IdLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException()
        {            
            int id = 0;            
            Assert.Throws<ArgumentOutOfRangeException>(() => new RemoveAdvertisementImageCommand(id));
        }
        [Fact]
        public void RemoveAdvertisementImageCommand_IdGreaterThanZero_IdPropertyIsSet()
        {
            int id = 1;                
            var command = new RemoveAdvertisementImageCommand(id);            
            Assert.Equal(id,command.Id);
        }
    }
}
