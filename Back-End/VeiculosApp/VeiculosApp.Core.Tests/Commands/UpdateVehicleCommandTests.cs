using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class UpdateVehicleCommandTests
    {
        [Fact]
        public void UpdateVehicleCommand_Should_Throws_ArgumentNullException_If_Vehicle_Is_Null()
        {
            Vehicle vehicle = null;
            Assert.Throws<ArgumentNullException>(() => new UpdateVehicleCommand(vehicle));
        }
        [Fact]
        public void UpdateVehicleCommand_Should_Throws_ArgumentOutOfRangeException_If_Id_Is_Less_Than_Zero()
        {
            Vehicle vehicle = new Vehicle { Id = -1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpdateVehicleCommand(vehicle));
        }
        [Fact]
        public void UpdateVehicleCommand_Should_Throws_ArgumentOutOfRangeException_If_Id_Is_Zero()
        {
            Vehicle vehicle = new Vehicle { Id = 0 };
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpdateVehicleCommand(vehicle));
        }
        [Fact]
        public void UpdateVehicleCommand_Should_Throws_ArgumentNullException_If_Name_Is_Null()
        {
            Vehicle vehicle = new Vehicle { Id = 1,Name = null };
            Assert.Throws<ArgumentNullException>(() => new UpdateVehicleCommand(vehicle));
        }
        [Theory]
        [InlineData("", "brand")]
        [InlineData(" ", "brand")]
        public void UpdateVehicleCommand_Should_Throws_ArgumentException_If_Name_Is_Empty_Or_Whitespace(string name, string brand)
        {
            Vehicle vehicle = new Vehicle { Id = 1, Name = name, Brand = brand };
            Assert.Throws<ArgumentException>(() => new UpdateVehicleCommand(vehicle));
        }
        [Fact]
        public void UpdateVehicleCommand_Should_Throws_ArgumentNullException_If_Brand_Is_Null()
        {
            Vehicle vehicle = new Vehicle { Id = 1, Name = "name", Brand = null };
            Assert.Throws<ArgumentNullException>(() => new UpdateVehicleCommand(vehicle));
        }
        [Theory]
        [InlineData("name", "")]
        [InlineData("name", " ")]
        public void UpdateVehicleCommand_Should_Throws_ArgumentException_If_Brand_Is_Empty_Or_Whitespace(string name, string brand)
        {
            Vehicle vehicle = new Vehicle { Id = 1, Name = name, Brand = brand };
            Assert.Throws<ArgumentException>(() => new UpdateVehicleCommand(vehicle));
        }
    }
}
