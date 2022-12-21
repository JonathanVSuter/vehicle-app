using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Controllers
{
    public class CustomController : ControllerBase
    {
        public User LoggedUser 
        {
            get;set;
        }
    }
}
