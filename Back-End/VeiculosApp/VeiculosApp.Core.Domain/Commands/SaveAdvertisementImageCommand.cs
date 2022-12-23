using System;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{    
    public class SaveAdvertisementImageCommand : ICommand
    {        
        public IList<AdvertisementImage> AdvertisementImages { get; set; }
        public SaveAdvertisementImageCommand(IList<AdvertisementImage> advertisementImages)
        {
            if (advertisementImages == null) throw new ArgumentNullException($"parameter {nameof(advertisementImages)} could not be null.");
            if (!advertisementImages.Any()) throw new ArgumentException($"parameter {nameof(advertisementImages)}  must be at least one element.");            

            foreach (var item in advertisementImages)
            {
                if (item.Id >0) throw new ArgumentException($"parameter {nameof(advertisementImages)} must be zero.");
                if (item.IdAdvertisement <= 0) throw new ArgumentException($"parameter {nameof(advertisementImages)} must be greater than zero (0).");
                if (item.Name == null) throw new ArgumentNullException($"parameter {nameof(item.Name)} at position {advertisementImages.IndexOf(item)} could not be null.");
                if (item.Name == string.Empty) throw new ArgumentNullException($"parameter {nameof(item.Name)} at position {advertisementImages.IndexOf(item)} could not be empty.");
                if (item.Photo == null) throw new ArgumentNullException($"parameter {nameof(item.Photo)} at position {advertisementImages.IndexOf(item)} could not be null.");
                if (item.Photo.Length <= 0) throw new ArgumentNullException($"parameter {nameof(item.Photo)} at position {advertisementImages.IndexOf(item)} could not be zero length.");
            }
            AdvertisementImages = advertisementImages;
        }
    }
}
