
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByIdAnnouncementImageQueryHandler : IQueryHandler<GetByIdAnnouncementImageQuery, AdvertisementImage>
    {
        public readonly IAdvertisementImageRepository _announcementImageRepository;

        public GetByIdAnnouncementImageQueryHandler(IAdvertisementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }

        public AdvertisementImage Execute(GetByIdAnnouncementImageQuery query)
        {
            var result = _announcementImageRepository.GetById(query.Id);
            return result;
        }
    }
}
