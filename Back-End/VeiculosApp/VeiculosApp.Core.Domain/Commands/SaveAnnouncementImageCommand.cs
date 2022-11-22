using System;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class SaveAnnouncementImageCommand : ICommand
    {
        public int IdAnnouncement { get; set; }
        public IList<AnnoucementImage> AnnoucementImages { get; set; }
        public SaveAnnouncementImageCommand(IList<AnnoucementImage> annoucementImages, int idAnnoucement)
        {
            if (annoucementImages == null) throw new ArgumentNullException($"parameter {nameof(annoucementImages)} is null.");
            if (annoucementImages.Any()) throw new ArgumentException($"parameter {nameof(annoucementImages)} has must be at least one element.");
            if (idAnnoucement <= 0) throw new ArgumentException($"parameter {nameof(annoucementImages)} has must be at least one element.");

            foreach (var item in annoucementImages)
            {
                if (!item.IdAnnouncement.HasValue) throw new ArgumentNullException($"parameter {nameof(item.IdAnnouncement)} at position {annoucementImages.IndexOf(item)} could not be zero.");
                if (item.IdAnnouncement.HasValue && item.IdAnnouncement <= 0) throw new ArgumentException($"parameter {nameof(item.IdAnnouncement)} at position {annoucementImages.IndexOf(item)} could not be zero or less.");
                if (item.Name == null) throw new ArgumentNullException($"parameter {nameof(item.Name)} at position {annoucementImages.IndexOf(item)} could not be null.");
                if (item.Name == string.Empty) throw new ArgumentNullException($"parameter {nameof(item.Name)} at position {annoucementImages.IndexOf(item)} could not be empty.");
                if (item.Photo == null) throw new ArgumentNullException($"parameter {nameof(item.Photo)} at position {annoucementImages.IndexOf(item)} could not be empty.");
            }
            AnnoucementImages = annoucementImages;
        }
    }
}
