using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class RemoveVehicleCommandTests
    {
        [Fact]
        public void RemoveVehicleCommand_IdGreaterThanZero_ShouldCreateInstance()
        {            
            int id = 1;
            var command = new RemoveVehicleCommand(id);
            Assert.Equal(id, command.Id);
        }
        [Fact]
        public void RemoveVehicleCommand_IdLessThanOrEqualToZero_ShouldThrowArgumentOutOfRangeException()
        {            
            int id = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => new RemoveVehicleCommand(id));
        }
    }
}
