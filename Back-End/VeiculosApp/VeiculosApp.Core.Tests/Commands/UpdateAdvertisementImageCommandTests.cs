using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class UpdateAdvertisementImageCommandTests
    {
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenAdvertisementImagesIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdateAdvertisementImageCommand(null));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentException_WhenAdvertisementImagesIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new UpdateAdvertisementImageCommand(new List<AdvertisementImage>()));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentException_WhenIdIsLessThanOrEqualToZero()
        {
            var advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage { Id = 0, IdAdvertisement = 1, Name = "test", Photo = new byte[1] }
            };
            Assert.Throws<ArgumentException>(() => new UpdateAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentException_WhenIdAdvertisementIsLessThanOrEqualToZero()
        {
            var advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage { Id = 1, IdAdvertisement = 0, Name = "test", Photo = new byte[1] }
            };
            Assert.Throws<ArgumentException>(() => new UpdateAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenNameIsNull()
        {
            var advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage { Id = 1, IdAdvertisement = 1, Name = null, Photo = new byte[1] }
            };
            Assert.Throws<ArgumentNullException>(() => new UpdateAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentException_WhenNameIsEmpty()
        {
            var advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage { Id = 1, IdAdvertisement = 1, Name = "", Photo = new byte[1] }
            };
            Assert.Throws<ArgumentException>(() => new UpdateAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenPhotoIsNull()
        {
            var advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage { Id = 1, IdAdvertisement = 1, Name = "test", Photo = null }
            };
            Assert.Throws<ArgumentNullException>(() => new UpdateAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenPhotoIsZeroLength()
        {
            var advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage { Id = 1, IdAdvertisement = 1, Name = "test", Photo = new byte[0] }
            };
            Assert.Throws<ArgumentNullException>(() => new UpdateAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void UpdateAdvertisementImageCommand_ShouldNotThrowException_WhenParametersAreValid() 
        {
            var advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage { Id = 1, IdAdvertisement = 1, Name = "test", Photo = new byte[]{1,2,3} }
            };
            var exception = Record.Exception(() => new UpdateAdvertisementImageCommand(advertisementImages));
            Assert.Null(exception);
        }        
    }
}
