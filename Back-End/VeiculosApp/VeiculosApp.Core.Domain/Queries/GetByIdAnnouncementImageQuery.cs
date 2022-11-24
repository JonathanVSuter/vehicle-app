using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Queries
{
    public class GetByIdAnnouncementImageQuery : IQuery<AnnouncementImage>
    {    
        public int Id { get; set; }
        public GetByIdAnnouncementImageQuery(int id)
        {
            Id = id;
        }
    }
}
