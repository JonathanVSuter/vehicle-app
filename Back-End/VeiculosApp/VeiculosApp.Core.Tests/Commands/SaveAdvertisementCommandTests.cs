using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class SaveAdvertisementCommandTests
    {
        [Fact]
        public void SaveAdvertisementCommand_WithNullAdvertisement_ThrowsArgumentNullException()
        {            
            Advertisement advertisement = null;
            Assert.Throws<ArgumentNullException>(() => new SaveAdvertisementCommand(advertisement));
        }

        [Fact]
        public void SaveAdvertisementCommand_WithAdvertisementIdGreaterThanZero_ThrowsArgumentOutOfRangeException()
        {            
            Advertisement advertisement = new Advertisement
            {
                Id = 1,
                IdVehicle = 1,
                IdUser = 1,
                AnnouncedValue = 1
            };            
            Assert.Throws<ArgumentOutOfRangeException>(() => new SaveAdvertisementCommand(advertisement));
        }

        [Fact]
        public void SaveAdvertisementCommand_WithAdvertisementIdVehicleLessOrEqualToZero_ThrowsArgumentOutOfRangeException()
        {            
            Advertisement advertisement = new Advertisement
            {
                Id = 0,
                IdVehicle = 0,
                IdUser = 1,
                AnnouncedValue = 1
            };
            
            Assert.Throws<ArgumentOutOfRangeException>(() => new SaveAdvertisementCommand(advertisement));
        }

        [Fact]
        public void SaveAdvertisementCommand_WithAdvertisementIdUserLessOrEqualToZero_ThrowsArgumentOutOfRangeException()
        {            
            Advertisement advertisement = new Advertisement
            {
                Id = 0,
                IdVehicle = 1,
                IdUser = 0,
                AnnouncedValue = 1
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => new SaveAdvertisementCommand(advertisement));
        }

        [Fact]
        public void SaveAdvertisementCommand_WithAdvertisementAnnouncedValueLessOrEqualToZero_ThrowsArgumentOutOfRangeException()
        {            
            Advertisement advertisement = new Advertisement
            {
                Id = 0,
                IdVehicle = 1,
                IdUser = 1,
                AnnouncedValue = 0
            };         
            Assert.Throws<ArgumentOutOfRangeException>(() => new SaveAdvertisementCommand(advertisement));
        }

        [Fact]
        public void SaveAdvertisementCommand_WithValidAdvertisement_CreatesSaveAdvertisementCommand()
        {            
            Advertisement advertisement = new Advertisement
            {
                Id = 0,
                IdVehicle = 1,
                IdUser = 1,
                AnnouncedValue = 1
            };
            var command = new SaveAdvertisementCommand(advertisement);
            Assert.Equal(advertisement, command.Advertisement);
        }
    }
}
