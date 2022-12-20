using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetAllAnnouncementImagesQueryHandler : IQueryHandler<GetAllAnnouncementImagesQuery, IList<AdvertisementImage>>
    {
        public readonly IAdvertisementImageRepository _announcementImageRepository;

        public GetAllAnnouncementImagesQueryHandler(IAdvertisementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }

        public IList<AdvertisementImage> Execute(GetAllAnnouncementImagesQuery query)
        {
            var result = _announcementImageRepository.GetAll().ToList();
            return result;
        }
    }
}
