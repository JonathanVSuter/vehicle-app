
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByIdAnnouncementImageQueryHandler : IQueryHandler<GetByIdAdvertisementImageQuery, AdvertisementImage>
    {
        public readonly IAdvertisementImageRepository _announcementImageRepository;

        public GetByIdAnnouncementImageQueryHandler(IAdvertisementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }

        public AdvertisementImage Execute(GetByIdAdvertisementImageQuery query)
        {
            var result = _announcementImageRepository.GetById(query.Id);
            return result;
        }
    }
}
