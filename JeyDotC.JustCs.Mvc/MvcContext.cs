using System;
using Microsoft.AspNetCore.Http;

namespace JeyDotC.JustCs.Mvc
{
    public static class MvcContext
    {
        private static HttpContext _context;

        public static HttpContext Context
        {
            get => _context ?? throw new InvalidOperationException("Context is not initialized, This class can only be used from within a ComponentElement after the view has been returned from the controller.");
            internal set => _context = value;
        }

        public static TService GetService<TService>() => (TService)Context.RequestServices.GetService(typeof(TService));
    }
}

