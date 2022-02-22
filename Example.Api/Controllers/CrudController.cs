using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Api.Model;
using Example.Api.Views.App;
using JeyDotC.JustCs;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("[controller]")]
    public class CrudController : Controller
    {
        public IView Index()
        {
            return new View<DataList>(new DataListProps
            {
                Results = new Data[] { }
            });
        }
    }
}