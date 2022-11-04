using VeiculosApp.Core.Domain.Mapping;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
