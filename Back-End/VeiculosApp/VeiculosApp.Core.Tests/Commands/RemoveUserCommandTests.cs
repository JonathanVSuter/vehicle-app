using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Commands;
using Xunit;

namespace VeiculosApp.Core.Tests.Commands
{
    public class RemoveUserCommandTests
    {
        [Fact]
        public void RemoveUserCommand_IdUserLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException()
        {            
            int idUser = 0;            
            Assert.Throws<ArgumentOutOfRangeException>(() => new RemoveUserCommand(idUser));
        }

        [Fact]
        public void RemoveUserCommand_IdUserGreaterThanZero_SetsIdUserProperty()
        {            
            int idUser = 1;
            var command = new RemoveUserCommand(idUser);            
            Assert.Equal(idUser, command.IdUser);
        }
    }
}
