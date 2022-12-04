using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Queries
{
    public class GetByIdUserQuery : IQuery<User>
    {
        public int Id { get; set; }
        public GetByIdUserQuery(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException($"");            
            Id = id;
        }
    }
}
