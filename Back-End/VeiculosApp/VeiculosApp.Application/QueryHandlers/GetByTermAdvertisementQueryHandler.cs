using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByTermAdvertisementQueryHandler : IQueryHandler<GetByTermAdvertisementQuery, IList<Advertisement>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IUserRepository _userRepository;

        public GetByTermAdvertisementQueryHandler(IHttpContextAccessor httpContextAccessor, IAdvertisementRepository advertisementRepository, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _advertisementRepository = advertisementRepository;
            _userRepository = userRepository;
        }

        public IList<Advertisement> Execute(GetByTermAdvertisementQuery query)
        {            
            var email = _httpContextAccessor.HttpContext.User.FindFirst(x=> x.Type == ClaimTypes.Email).Value;
            var role = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.Role).Value;
            var user = _userRepository.GetUserByEmail(email);

            IList<Advertisement> advertisements;

            if (role == "ADMIN") 
            {
                advertisements = _advertisementRepository.GetBy(query.Term).ToList();
                return advertisements;
            }
            advertisements = _advertisementRepository.GetByFromSpecificUser(query.Term, user.Id).ToList();  

            return advertisements;
        }
    }
}
