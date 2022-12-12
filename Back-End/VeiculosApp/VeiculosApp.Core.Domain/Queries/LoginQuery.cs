using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;

namespace VeiculosApp.Core.Domain.Queries
{
    public class LoginQuery : IQuery<LoginSucessDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginQuery(string email, string password)
        {
            if (email == string.Empty) throw new ArgumentException($"User e-mail could not be empty.");
            if (email == null) throw new ArgumentNullException($"User e-mail could not be null.");
            if (email == " ") throw new ArgumentException($"User e-mail could not be whitespace.");
            if (password == string.Empty) throw new ArgumentException($"User password could not be empty.");
            if (password == null) throw new ArgumentNullException($"User password could not be null.");
            if (Password == " ") throw new ArgumentException($"User password could not be whitespace.");

            Email = email;
            Password = password;
        }
    }
}
