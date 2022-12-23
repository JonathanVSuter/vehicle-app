using System;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class UpdateUserCommandTests
    {
        [Fact]
        public void Test_Id_Greater_Zero()
        {
            var user = new User { Id = 1, Name = "Test User", Email = "test@email.com", Password = "password" };
            var command = new UpdateUserCommand(user);
            Assert.True(command.User.Id == 1);
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Name_Not_Empty_Or_Whitespace(string name)
        {
            var user = new User { Id = 1, Name = name, Email = "test@email.com", Password = "password" };
            Assert.Throws<ArgumentException>(() => new UpdateUserCommand(user));
        }
        [Fact]
        public void Test_Name_Not_Null()
        {
            var user = new User { Id = 1, Name = null, Email = "test@email.com", Password = "password" };
            Assert.Throws<ArgumentNullException>(() => new UpdateUserCommand(user));
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Email_Not_Empty_Or_Whitespace(string email)
        {
            var user = new User { Id = 1, Name = "Test User", Email = email, Password = "password" };
            Assert.Throws<ArgumentException>(() => new UpdateUserCommand(user));
        }
        [Fact]
        public void Test_Email_Not_Null()
        {
            var user = new User { Id = 1, Name = "Test User", Email = null, Password = "password" };
            Assert.Throws<ArgumentNullException>(() => new UpdateUserCommand(user));
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Password_Not_Empty_Or_Null_Or_Whitespace(string password)
        {
            var user = new User { Id = 1, Name = "Test User", Email = "test@email.com", Password = password };
            Assert.Throws<ArgumentException>(() => new UpdateUserCommand(user));
        }
        [Fact]
        public void Test_Password_Not_Null()
        {
            var user = new User { Id = 1, Name = "Test User", Email = "test@email.com", Password = null };
            Assert.Throws<ArgumentNullException>(() => new UpdateUserCommand(user));
        }
    }
}
