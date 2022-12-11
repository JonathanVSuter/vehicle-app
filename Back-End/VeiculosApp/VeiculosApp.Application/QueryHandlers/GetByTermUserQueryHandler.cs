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
    public class GetByTermUserQueryHandler : IQueryHandler<GetByTermUserQuery, IList<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetByTermUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> Execute(GetByTermUserQuery query)
        {
            var result = _userRepository.GetBy(query.Term).ToList();
            return result;
        }
    }
}
