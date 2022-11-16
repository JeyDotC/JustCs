using System.Diagnostics.CodeAnalysis;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Testing;

public abstract class JustCsTest : ComponentElement
{
    [ExcludeFromCodeCoverage]
    protected override sealed Element Render(IElementAttributes? attributes) => throw new NotImplementedException();
}

