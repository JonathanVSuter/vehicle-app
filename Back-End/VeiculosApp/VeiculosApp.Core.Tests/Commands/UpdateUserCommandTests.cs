using System;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class UpdateUserCommandTests
    {
        [Fact]
        public void UpdateUserCommand_ShouldThrownException()
        {
            var user = new User { Id = 1, Name = "Test User", Email = "test@email.com", Password = "password" };
            var command = new UpdateUserCommand(user);
            var exception = Record.Exception(() => new UpdateUserCommand(user));
            Assert.Null(exception);
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdateUserCommand_ShouldThrownArgumentException_WhenNameIsEmptyOrWhitespace(string name)
        {
            var user = new User { Id = 1, Name = name, Email = "test@email.com", Password = "password" };
            Assert.Throws<ArgumentException>(() => new UpdateUserCommand(user));
        }
        [Fact]
        public void UpdateUserCommand_ShouldThrownArgumentNullException_WhenNameIsNull()
        {
            var user = new User { Id = 1, Name = null, Email = "test@email.com", Password = "password" };
            Assert.Throws<ArgumentNullException>(() => new UpdateUserCommand(user));
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdateUserCommand_ShouldThrownArgumentException_WhenEmailIsEmptyOrWhitespace(string email)
        {
            var user = new User { Id = 1, Name = "Test User", Email = email, Password = "password" };
            Assert.Throws<ArgumentException>(() => new UpdateUserCommand(user));
        }
        [Fact]
        public void UpdateUserCommand_ShouldThrownArgumentNullException_WhenEmailIsNull()
        {
            var user = new User { Id = 1, Name = "Test User", Email = null, Password = "password" };
            Assert.Throws<ArgumentNullException>(() => new UpdateUserCommand(user));
        }        
    }
}
