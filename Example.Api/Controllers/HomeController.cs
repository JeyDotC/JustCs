
using Example.Api.Model.Repositories;
using Example.Api.Views.Home;
using JeyDotC.JustCs;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IFoosRepository _foosRepository;

        public HomeController(IFoosRepository foosRepository)
        {
            _foosRepository = foosRepository;
        }

        [HttpGet]
        public IView Index()
        {
            var allFoos = _foosRepository.ListFoos();

            return new View<Views.Home.Index>(new IndexProps
            {
                Foos = allFoos
            });
        }

        [Route("/New")]
        [HttpGet]
        public IView New()
        {
            return new View<Views.Home.New>(new NewProps());
        }

        [Route("/New")]
        [HttpPost]
        public IActionResult New([FromForm]NewProps newProps)
        {

            if (!ControllerContext.ModelState.IsValid)
            {
                return new ObjectResult(new View<Views.Home.New>(newProps with
                {
                    Validation = ControllerContext.ModelState,
                }, System.Net.HttpStatusCode.BadRequest));
            }

            _foosRepository.AddFoo(new Model.Models.Foo { Name = newProps.Name });

            return Redirect("/");
        }
    }
}