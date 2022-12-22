using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByTermAdvertisementImageQueryHandler : IQueryHandler<GetByTermAdvertisementImageQuery, IList<AdvertisementImage>>
    {
        public readonly IAdvertisementImageRepository _advertisementImageRepository;

        public GetByTermAdvertisementImageQueryHandler(IAdvertisementImageRepository advertisementImageRepository)
        {
            _advertisementImageRepository = advertisementImageRepository;
        }

        public IList<AdvertisementImage> Execute(GetByTermAdvertisementImageQuery query)
        {
            var images = _advertisementImageRepository.GetAllAdvertisementImagesByTerm(query.Term);
            return images;
        }
    }
}
