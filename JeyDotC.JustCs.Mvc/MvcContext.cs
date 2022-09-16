using System;
using Microsoft.AspNetCore.Http;

namespace JeyDotC.JustCs.Mvc
{
    /// <summary>
    /// This class' only purpose is to make HttpContext generally available to
    /// all components at any level.
    ///
    /// This class should be initialized only by the HtmlOutputFormatter class.
    ///
    /// Avoid using this class unless your component is expected to be
    /// <strong>tightly related</strong> to MVC.
    /// </summary>
    public static class MvcContext
    {
        private static HttpContext _context;

        /// <summary>
        /// Returns the current HttpContext. Setter is provided for tests purposes.
        /// </summary>
        public static HttpContext Context
        {
            get => _context ?? throw new InvalidOperationException("Context is not initialized, This class can only be used from within a ComponentElement after the view has been returned from the controller.");

            set => _context = value;
        }

        public static TService GetService<TService>() => (TService)Context.RequestServices.GetService(typeof(TService));
    }
}

