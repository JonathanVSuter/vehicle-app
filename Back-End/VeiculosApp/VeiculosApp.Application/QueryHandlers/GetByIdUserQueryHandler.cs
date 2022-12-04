using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Execute(GetByIdUserQuery query)
        {
            var result = _userRepository.GetById(query.Id);
            return result;
        }
    }
}
