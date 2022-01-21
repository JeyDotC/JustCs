using System;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace MrPapaya.Api.Views.WeatherForecast
{
    class MyCoolComponent : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes) =>
            _<H2>("This is a subtitle");
    }

    class MyCoolComponent2 : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes) =>
            _<MyCoolComponent>();
    }

    class MyCoolComponent3 : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes) =>
            _<MyCoolComponent2>();
    }

    public class Home : ComponentElement
    {
        protected override Element Render(IElementAttributes props) =>

            _<Page>(new PageProps {
                    Title = "Hello World",
                    Css = new string[]{ "https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" },
                    Scripts = new string[] { "/js/weatherForecast/index.js" }
                },

                _<H1>("<strong>Evil Frame!</strong>"),
                _<H1>(15),
                // It is better to avoid this
                new MyCoolComponent(),

                // Having fun with nested components!
                _<MyCoolComponent3>(),

                _<Input>(new Attrs {
                    Name = "name",
                    Autocomplete = AutoCompleteValues.Off,
                }),

                _<Div>(new Attrs { Id = "app"}),

                _<Button>(new Attrs {
                        Class = ClassNames.From(
                            "btn",
                            "btn-primary",
                            ("btn-sm", true),
                            new { btnBlock = true, btnLg = false },
                            (new { specialClass = true }, PropertyAsClassBehavior.AsIs),
                            new { specialClass2 = true }.TransformToDashCase(),
                            new { specialClass3 = true }.AsIs()
                        ),
                    },
                    "A Nice Button"
                ),

                _<Iframe>(new Attrs {
                    Src = "http://localhost:3000/",
                    Title = "Evil iframe",
                    Style = Styles.From(new {
                        Width = 98.5.Percent(),
                        Height = 400.Px(),
                    }),
                    DataSet = new
                    {
                        evilData = "Weee",
                        SomeEvilData = "Wooo",
                        booleanData = true,
                        ThisShouldNotRender = false,
                        DataSet = "Recursive-Stuff!"
                    }
                })
            );
    }
}
