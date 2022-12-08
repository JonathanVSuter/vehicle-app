using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class UpdateAnnouncementImageCommand : ICommand
    {
        public IList<AnnouncementImage> AnnoucementImages { get; set; }
        public UpdateAnnouncementImageCommand(IList<AnnouncementImage> annoucementImages)
        {
            if (annoucementImages == null) throw new ArgumentNullException($"parameter {nameof(annoucementImages)} could not be null.");
            if (annoucementImages.Any()) throw new ArgumentException($"parameter {nameof(annoucementImages)}  must be at least one element.");            

            foreach (var item in annoucementImages)
            {
                if (item.Id <= 0) new ArgumentException($"parameter {nameof(item.Id)} at position {annoucementImages.IndexOf(item)} must be greater than zero.");
                if (item.IdAnnouncement <= 0) throw new ArgumentException($"parameter {nameof(item.IdAnnouncement)} at position {annoucementImages.IndexOf(item)} must be greater than zero (0).");
                if (item.Name == null) throw new ArgumentNullException($"parameter {nameof(item.Name)} at position {annoucementImages.IndexOf(item)} could not be null.");
                if (item.Name == string.Empty) throw new ArgumentNullException($"parameter {nameof(item.Name)} at position {annoucementImages.IndexOf(item)} could not be empty.");
                if (item.Photo == null) throw new ArgumentNullException($"parameter {nameof(item.Photo)} at position {annoucementImages.IndexOf(item)} could not be null.");
                if (item.Photo.Length <= 0) throw new ArgumentNullException($"parameter {nameof(item.Photo)} at position {annoucementImages.IndexOf(item)} could not be zero length.");
            }
            AnnoucementImages = annoucementImages;
        }
    }
}
