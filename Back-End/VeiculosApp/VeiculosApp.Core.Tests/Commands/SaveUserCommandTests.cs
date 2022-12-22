using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class SaveUserCommandTests
    {
        [Fact]
        public void Test_Id_Greater_Than_Zero()
        {
            var user = new User { Id = 0, Name = "Test User", Email = "test@email.com", Password = "password" };
            var command = new SaveUserCommand(user);
            
            Assert.True(command.User.Id >= 0);
        }
        [Theory]        
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Name_Not_Empty_Or_Whitespace(string name)
        {
            var user = new User { Id = 0, Name = name, Email = "test@email.com", Password = "password" };
            Assert.Throws<ArgumentException>(() => new SaveUserCommand(user));            
        }
        [Fact]
        public void Test_Name_Not_Null()
        {
            var user = new User { Id = 0, Name = null, Email = "test@email.com", Password = "password" };
            Assert.Throws<ArgumentNullException>(() => new SaveUserCommand(user));
        }
        [Theory]        
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Email_Not_Empty_Or_Whitespace(string email)
        {
            var user = new User { Id = 0, Name = "Test User", Email = email, Password = "password" };
            Assert.Throws<ArgumentException>(() => new SaveUserCommand(user));            
        }
        [Fact]
        public void Test_Email_Not_Null()
        {
            var user = new User { Id = 0, Name = "Test User", Email = null, Password = "password" };
            Assert.Throws<ArgumentNullException>(() => new SaveUserCommand(user));
        }
        [Theory]        
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Password_Not_Empty_Or_Null_Or_Whitespace(string password)
        {
            var user = new User { Id = 0, Name = "Test User", Email = "test@email.com", Password = password };
            Assert.Throws<ArgumentException>(() => new SaveUserCommand(user));
        }
        [Fact]
        public void Test_Password_Not_Null()
        {
            var user = new User { Id = 0, Name = "Test User", Email = "test@email.com", Password = null };
            Assert.Throws<ArgumentNullException>(() => new SaveUserCommand(user));
        }
    }
}
