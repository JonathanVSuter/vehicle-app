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
    public class GetAllAdvertisementImagesQueryHandler : IQueryHandler<GetAllAnnouncementImagesQuery, IList<AdvertisementImage>>
    {
        public readonly IAdvertisementImageRepository _advertisementImageRepository;

        public GetAllAdvertisementImagesQueryHandler(IAdvertisementImageRepository advertisementImageRepository)
        {
            _advertisementImageRepository = advertisementImageRepository;
        }

        public IList<AdvertisementImage> Execute(GetAllAnnouncementImagesQuery query)
        {
            var result = _advertisementImageRepository.GetAll().ToList();
            return result;
        }
    }
}
