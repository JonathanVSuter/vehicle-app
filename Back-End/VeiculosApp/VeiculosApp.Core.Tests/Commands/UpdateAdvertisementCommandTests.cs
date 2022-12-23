using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class UpdateAdvertisementCommandTests
    {
        [Fact]
        public void UpdateAdvertisementCommand_ThrowsArgumentNullException_WhenAdvertisementIsNull()
        {            
            Advertisement advertisement = null;         
            Assert.Throws<ArgumentNullException>(() => new UpdateAdvertisementCommand(advertisement));
        }

        [Fact]
        public void UpdateAdvertisementCommand_ThrowsArgumentOutOfRangeException_WhenIdIsZeroOrNegative()
        {
            var advertisement = new Advertisement
            {
                Id = 0,
                IdVehicle = 1,
                IdUser = 1,
                AnnouncedValue = 1
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpdateAdvertisementCommand(advertisement));
        }

        [Fact]
        public void UpdateAdvertisementCommand_ThrowsArgumentOutOfRangeException_WhenIdVehicleIsZeroOrNegative()
        {           
            var advertisement = new Advertisement
            {
                Id = 1,
                IdVehicle = 0,
                IdUser = 1,
                AnnouncedValue = 1
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpdateAdvertisementCommand(advertisement));
        }

        [Fact]
        public void UpdateAdvertisementCommand_ThrowsArgumentOutOfRangeException_WhenIdUserIsZeroOrNegative()
        {            
            var advertisement = new Advertisement
            {
                Id = 1,
                IdVehicle = 1,
                IdUser = 0,
                AnnouncedValue = 1
            };            
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpdateAdvertisementCommand(advertisement));
        }

        [Fact]
        public void UpdateAdvertisementCommand_ThrowsArgumentOutOfRangeException_WhenAnnouncedValueIsZeroOrNegative()
        {            
            var advertisement = new Advertisement
            {
                Id = 1,
                IdVehicle = 1,
                IdUser = 1,
                AnnouncedValue = 0
            };         
            Assert.Throws<ArgumentOutOfRangeException>(() => new UpdateAdvertisementCommand(advertisement));
        }

        [Fact]
        public void UpdateAdvertisementCommand_SetsAdvertisementProperty_WhenArgumentsAreValid()
        {           
            var advertisement = new Advertisement
            {
                Id = 1,
                IdVehicle = 1,
                IdUser = 1,
                AnnouncedValue = 1
            };                      
            var command = new UpdateAdvertisementCommand(advertisement);
            Assert.Equal(advertisement, command.Advertisement);
        }
    }
}
