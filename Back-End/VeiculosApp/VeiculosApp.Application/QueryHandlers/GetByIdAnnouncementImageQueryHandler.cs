
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByIdAnnouncementImageQueryHandler : IQueryHandler<GetByIdAnnouncementImageQuery, AnnouncementImage>
    {
        public readonly IAnnouncementImageRepository _announcementImageRepository;

        public GetByIdAnnouncementImageQueryHandler(IAnnouncementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }

        public AnnouncementImage Execute(GetByIdAnnouncementImageQuery query)
        {
            var result = _announcementImageRepository.GetById(query.Id);
            return result;
        }
    }
}
