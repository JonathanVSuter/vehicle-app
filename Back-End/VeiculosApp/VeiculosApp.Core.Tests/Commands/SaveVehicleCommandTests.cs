using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class SaveVehicleCommandTests
    {
        [Fact]
        public void Throws_ArgumentNullException_If_Vehicle_Is_Null()
        {            
            Vehicle vehicle = null;            
            Assert.Throws<ArgumentNullException>(() => new SaveVehicleCommand(vehicle));
        }
        [Fact]
        public void Throws_ArgumentOutOfRangeException_If_Id_Is_Greater_Than_Zero()
        {            
            Vehicle vehicle = new Vehicle { Id = 1 };         
            Assert.Throws<ArgumentOutOfRangeException>(() => new SaveVehicleCommand(vehicle));
        }
        [Fact]
        public void Throws_ArgumentNullException_If_Name_Is_Null()
        {            
            Vehicle vehicle = new Vehicle { Name = null };                        
            Assert.Throws<ArgumentNullException>(() => new SaveVehicleCommand(vehicle));
        } 
        [Theory]
        [InlineData("", "brand")]
        [InlineData(" ", "brand")]
        public void Throws_ArgumentException_If_Name_Is_Empty_Or_Whitespace(string name, string brand)
        {
            Vehicle vehicle = new Vehicle { Name = name, Brand = brand };
            Assert.Throws<ArgumentException>(() => new SaveVehicleCommand(vehicle));
        }
        [Fact]
        public void Throws_ArgumentNullException_If_Brand_Is_Null()
        {
            Vehicle vehicle = new Vehicle { Name = "name", Brand = null };
            Assert.Throws<ArgumentNullException>(() => new SaveVehicleCommand(vehicle));
        }
        [Theory]
        [InlineData("name", "")]
        [InlineData("name", " ")]
        public void Throws_ArgumentException_If_Brand_Is_Empty_Or_Whitespace(string name, string brand)
        {
            Vehicle vehicle = new Vehicle { Name = name, Brand = brand };
            Assert.Throws<ArgumentException>(() => new SaveVehicleCommand(vehicle));
        }
    }
}
