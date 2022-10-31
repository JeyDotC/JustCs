using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Configuration.Decorators;
using JeyDotC.JustCs.Mvc.Extensions;
using Microsoft.AspNetCore.Builder;
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

        public static IApplicationBuilder UseJustCs(this IApplicationBuilder app)
        {
            JustCsSettings.AttributeDecorators.Add(
                new DefaultPropsDecorator()
            );

            JustCsSettings.AttributeDecorators.Add(
                new ServiceProviderAttributesDecorator(app.ApplicationServices).WithHttpContextAccessor()
            );

            return app;
        }
    }
}
