using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Api.Model;
using Example.Api.Views.App;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("/")]
    public class AppController : Controller
    {
        [HttpGet]
        public IView Index() => new View<Views.App.Index>();

        [HttpGet("data-list")]
        public IView DataList() => new View<DataList>(new DataListProps {
            Results = new Data[]
            {
                new Data{ Id = 1, Name = "Name 1", Description = "Some cool info", Quantity = 5 },
                new Data{ Id = 2, Name = "Name 2", Description = "Some cooler info", Quantity = 9 },
                new Data{ Id = 3, Name = "Name 3", Description = "Some even cooler info", Quantity = 8 },
                new Data{ Id = 4, Name = "Name 4", Description = "Some not so cool info", Quantity = 10 },
                new Data{ Id = 5, Name = "Name 5", Description = "Some extra-cool info", Quantity = 11 },
                new Data{ Id = 6, Name = "Name 6", Description = "Some regular info", Quantity = 2 },
                new Data{ Id = 7, Name = "Name 7", Description = "Some strategic info", Quantity = 73 },
            }
        });
    }
}
