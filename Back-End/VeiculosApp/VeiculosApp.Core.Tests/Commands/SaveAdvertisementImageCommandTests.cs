using System;
using System.Collections.Generic;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class SaveAdvertisementImageCommandTests
    {
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenAdvertisementImagesIsNull()
        {
            IList<AdvertisementImage> advertisementImages = null;
            Assert.Throws<ArgumentNullException>(() => new SaveAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentException_WhenAdvertisementImagesIsEmpty()
        {
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>();
            Assert.Throws<ArgumentException>(() => new SaveAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentException_WhenIdIsGreaterThanZero()
        {
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = 1,
                    IdAdvertisement = 1,
                    Name = "Test",
                    Photo = new byte[1]
                }
            };
            Assert.Throws<ArgumentException>(() => new SaveAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentException_WhenIdAdvertisementIsLessThanOrEqualToZero()
        {
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = 0,
                    IdAdvertisement = 0,
                    Name = "Test",
                    Photo = new byte[1]
                }
            };
            Assert.Throws<ArgumentException>(() => new SaveAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenNameIsNull()
        {
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = 0,
                    IdAdvertisement = 1,
                    Name = null,
                    Photo = new byte[1]
                }
            };
            Assert.Throws<ArgumentNullException>(() => new SaveAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenNameIsEmpty()
        {
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = 0,
                    IdAdvertisement = 1,
                    Name = string.Empty,
                    Photo = new byte[1]
                }
            };
            Assert.Throws<ArgumentNullException>(() => new SaveAdvertisementImageCommand(advertisementImages));
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentNullException_WhenPhotoIsNull()
        {
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = 0,
                    IdAdvertisement = 1,
                    Name = "Test",
                    Photo = null
                }
            };
            Assert.Throws<ArgumentNullException>(() => new SaveAdvertisementImageCommand(advertisementImages));
        }        
    }
}
