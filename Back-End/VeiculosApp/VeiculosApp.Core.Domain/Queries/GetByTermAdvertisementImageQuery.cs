using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Queries
{
    public class GetByTermAdvertisementImageQuery : IQuery<IList<AdvertisementImage>>
    {
        public string Term { get; set; }
        public GetByTermAdvertisementImageQuery(string term)
        {
            Term = term;
        }
    }
}
