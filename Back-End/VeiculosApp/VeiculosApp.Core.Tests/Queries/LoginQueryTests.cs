using System;
using VeiculosApp.Core.Domain.Queries;
using Xunit;

namespace VeiculosApp.Core.Tests.Queries
{
    public class LoginQueryTests
    {
        [Fact]
        public void LoginQuery_Should_Not_Throws_xception_When_Email_And_Passoword_Is_Filled()
        {            
            string email = "test@example.com";
            string password = "password";
            
            var query = new LoginQuery(email, password);
         
            Assert.Equal(email, query.Email);
            Assert.Equal(password, query.Password);
        }

        [Theory]
        [InlineData("")]        
        [InlineData(" ")]
        public void LoginQuery_Should_Throws_ArgumentException_When_Email_Is_Empty_Or_Whitespace(string email)
        {            
            string password = "password";
            
            Assert.Throws<ArgumentException>(() => new LoginQuery(email, password));            
        }
        [Fact]
        public void LoginQuery_Should_Throws_ArgumentException_When_Email_Is_Null()
        {
            string password = "password";
            
            Assert.Throws<ArgumentNullException>(() => new LoginQuery(null, password));
        }

        [Theory]
        [InlineData("")]        
        [InlineData(" ")]
        public void LoginQuery_Should_Throws_ArgumentException_When_Password_Is__Empty_Or_Whitespace(string password)
        {            
            string email = "test@example.com";
            
            Assert.Throws<ArgumentException>(() => new LoginQuery(email, password));            
        }
        [Fact]
        public void LoginQuery_Should_Throws_ArgumentException_When_Password_Is_Null()
        {
            string email = "test@example.com";

            Assert.Throws<ArgumentNullException>(() => new LoginQuery(email, null));
        }
    }
}
