using Microsoft.AspNetCore.Mvc;

namespace JeyDotC.JustCs.Mvc
{
    public static class DependencyInjection
    {
        public static MvcOptions WithJustCs(this MvcOptions options)
        {
            options.OutputFormatters.Insert(0, new HtmlOutputFormatter());

            return options;
        }
    }
}
