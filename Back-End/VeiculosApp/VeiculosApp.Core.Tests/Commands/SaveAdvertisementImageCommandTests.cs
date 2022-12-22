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
        [Theory]
        [InlineData(1, 0, null, new byte[] {})]
        [InlineData(1, 0, "", new byte[] { })]
        [InlineData(1, 0, "name", null)]
        [InlineData(1, 0, "name", new byte[] {})]
        [InlineData(1, 0, "name", new byte[] { 0, 1, 2 })]
        [InlineData(1, 1, null, new byte[] { })]
        [InlineData(1, 1, "", new byte[] { })]
        [InlineData(1, 1, "name", null)]
        [InlineData(1, 1, "name", new byte[] { })]
        [InlineData(1, 1, "name", new byte[] { 0, 1, 2})]
        public void SaveAdvertisementImageCommand_ShouldThrowArgumentException_WhenAdvertisementImagesIsInvalid(int id, int idAdvertisement, string name, byte[] photo)
        {            
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = id,
                    IdAdvertisement = idAdvertisement,
                    Name = name,
                    Photo = photo
                }
            };
            Assert.Throws<ArgumentException>(() => new SaveAdvertisementImageCommand(advertisementImages)); 
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldCreateInstance_WhenAdvertisementImagesIsValid()
        {
            // Arrange
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = 0,
                    IdAdvertisement = 1,
                    Name = "name",
                    Photo = new byte[] { 0, 1, 2}
                }
            };
            
            var command = new SaveAdvertisementImageCommand(advertisementImages);
                        
            Assert.IsType<SaveAdvertisementImageCommand>(command);
        }
        [Fact]
        public void SaveAdvertisementImageCommand_ShouldNotThrownArgumentException_WhenAdvertisementImagesIsValid()
        {
            // Arrange
            IList<AdvertisementImage> advertisementImages = new List<AdvertisementImage>
            {
                new AdvertisementImage
                {
                    Id = 0,
                    IdAdvertisement = 1,
                    Name = "name",
                    Photo = new byte[] { 0, 1, 2}
                }
            };

            var exception = Record.Exception(() => new SaveAdvertisementImageCommand(advertisementImages));

            Assert.Null(exception);
        }
    }
}
