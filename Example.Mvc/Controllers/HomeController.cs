
using System.Net;
using Example.Mvc.Model.Models;
using Example.Mvc.Model.Repositories;
using Example.Mvc.Views.Home;
using JeyDotC.JustCs;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace Example.Mvc.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IFoosRepository _foosRepository;
        private readonly IAntiforgery _antiforgery;

        public HomeController(IFoosRepository foosRepository, IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
            _foosRepository = foosRepository;
        }

        [HttpGet]
        public IView Index()
        {
            var allFoos = _foosRepository.ListFoos();

            return new View<Index>(new IndexProps
            {
                Foos = allFoos,
                // Manually add our antiforgery token
                __RequestVerificationToken = _antiforgery.GetTokens(HttpContext).RequestToken
            });
        }

        [Route("/New")]
        [HttpGet]
        public IView New()
        {
            return new View<New>(new NewProps {
                // Manually add our antiforgery token
                __RequestVerificationToken = _antiforgery.GetTokens(HttpContext).RequestToken
            });
        }

        [Route("/New")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New([FromForm]NewProps newProps)
        {
            if (!ControllerContext.ModelState.IsValid)
            {
                return new ObjectResult(new View<New>(newProps with
                {
                    Validation = ControllerContext.ModelState,
                }, HttpStatusCode.BadRequest));
            }

            _foosRepository.AddFoo(new Foo { Name = newProps.Name });

            return Redirect("/");
        }

        [Route("/Edit/{id:int}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var foo = _foosRepository.FindById(id);

            if(foo == null)
            {
                return NotFound();
            }

            return new ObjectResult(new View<Edit>(new EditProps {
                Id = foo.FooId,
                Name = foo.Name,
                // Manually add our antiforgery token
                __RequestVerificationToken = _antiforgery.GetTokens(HttpContext).RequestToken
            }));
        }

        [Route("/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] EditProps editProps)
        {
            var foo = _foosRepository.FindById(editProps.Id);

            if (foo == null)
            {
                return NotFound();
            }

            if (!ControllerContext.ModelState.IsValid)
            {
                return new ObjectResult(new View<Edit>(editProps with
                {
                    Validation = ControllerContext.ModelState,
                }, HttpStatusCode.BadRequest));
            }

            _foosRepository.UpdateFoo(new Foo {
                FooId = editProps.Id,
                Name = editProps.Name,
            });

            return Redirect("/");
        }

        [Route("/Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] DeleteFooData deleteData)
        {
            var foo = _foosRepository.FindById(deleteData.Id);

            if(foo == null)
            {
                return NotFound();
            }

            _foosRepository.DeleteFoo(foo.FooId);

            return Redirect("/");
        }
    }
}