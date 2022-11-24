using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByTermAnnouncementImageQueryHandler : IQueryHandler<GetByTermAnnouncementImageQuery, IList<AnnouncementImage>>
    {
        public readonly IAnnouncementImageRepository _announcementImageRepository;

        public GetByTermAnnouncementImageQueryHandler(IAnnouncementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }

        public IList<AnnouncementImage> Execute(GetByTermAnnouncementImageQuery query)
        {
            var images = _announcementImageRepository.GetAllAnnouncementImagesByTerm(query.Term);
            return images;
        }
    }
}
