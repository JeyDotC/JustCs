using System;
using System.Collections.Generic;
using Xunit;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Tests
{
    public class HtmlRendererTests
    {
        public static IEnumerable<object[]> AllTagsNoAttributes()
        {
            yield return new object[] { new A(), "<a></a>" };
            yield return new object[] { new Abbr(), "<abbr></abbr>" };
            yield return new object[] { new Acronym(), "<acronym></acronym>" };
            yield return new object[] { new Address(), "<address></address>" };
            yield return new object[] { new Applet(), "<applet></applet>" };
            yield return new object[] { new Area(), "<area></area>" };
            yield return new object[] { new Article(), "<article></article>" };
            yield return new object[] { new Aside(), "<aside></aside>" };
            yield return new object[] { new Audio(), "<audio></audio>" };
            yield return new object[] { new B(), "<b></b>" };
            yield return new object[] { new Base(), "<base></base>" };
            yield return new object[] { new Basefont(), "<basefont></basefont>" };
            yield return new object[] { new Bb(), "<bb></bb>" };
            yield return new object[] { new Bdo(), "<bdo></bdo>" };
            yield return new object[] { new Big(), "<big></big>" };
            yield return new object[] { new Blockquote(), "<blockquote></blockquote>" };
            yield return new object[] { new Body(), "<body></body>" };
            yield return new object[] { new Br(), "<br />" };
            yield return new object[] { new Button(), "<button></button>" };
            yield return new object[] { new Canvas(), "<canvas></canvas>" };
            yield return new object[] { new Caption(), "<caption></caption>" };
            yield return new object[] { new Center(), "<center></center>" };
            yield return new object[] { new Cite(), "<cite></cite>" };
            yield return new object[] { new Code(), "<code></code>" };
            yield return new object[] { new Col(), "<col></col>" };
            yield return new object[] { new Colgroup(), "<colgroup></colgroup>" };
            yield return new object[] { new Command(), "<command></command>" };
            yield return new object[] { new Datagrid(), "<datagrid></datagrid>" };
            yield return new object[] { new Datalist(), "<datalist></datalist>" };
            yield return new object[] { new Dd(), "<dd></dd>" };
            yield return new object[] { new Del(), "<del></del>" };
            yield return new object[] { new Details(), "<details></details>" };
            yield return new object[] { new Dfn(), "<dfn></dfn>" };
            yield return new object[] { new Dialog(), "<dialog></dialog>" };
            yield return new object[] { new Dir(), "<dir></dir>" };
            yield return new object[] { new Div(), "<div></div>" };
            yield return new object[] { new Dl(), "<dl></dl>" };
            yield return new object[] { new Dt(), "<dt></dt>" };
            yield return new object[] { new Em(), "<em></em>" };
            yield return new object[] { new Embed(), "<embed></embed>" };
            yield return new object[] { new Eventsource(), "<eventsource></eventsource>" };
            yield return new object[] { new Fieldset(), "<fieldset></fieldset>" };
            yield return new object[] { new Figcaption(), "<figcaption></figcaption>" };
            yield return new object[] { new Figure(), "<figure></figure>" };
            yield return new object[] { new Font(), "<font></font>" };
            yield return new object[] { new Footer(), "<footer></footer>" };
            yield return new object[] { new Form(), "<form></form>" };
            yield return new object[] { new Frame(), "<frame></frame>" };
            yield return new object[] { new Frameset(), "<frameset></frameset>" };
            yield return new object[] { new H1(), "<h1></h1>" };
            yield return new object[] { new H2(), "<h2></h2>" };
            yield return new object[] { new H3(), "<h3></h3>" };
            yield return new object[] { new H4(), "<h4></h4>" };
            yield return new object[] { new H5(), "<h5></h5>" };
            yield return new object[] { new H6(), "<h6></h6>" };
            yield return new object[] { new Head(), "<head></head>" };
            yield return new object[] { new Header(), "<header></header>" };
            yield return new object[] { new Hgroup(), "<hgroup></hgroup>" };
            yield return new object[] { new Hr(), "<hr />" };
            yield return new object[] { new JustCs.Html.Html(), "<html></html>" };
            yield return new object[] { new I(), "<i></i>" };
            yield return new object[] { new Iframe(), "<iframe></iframe>" };
            yield return new object[] { new Img(), "<img />" };
            yield return new object[] { new Input(), "<input />" };
            yield return new object[] { new Ins(), "<ins></ins>" };
            yield return new object[] { new Isindex(), "<isindex></isindex>" };
            yield return new object[] { new Kbd(), "<kbd></kbd>" };
            yield return new object[] { new Keygen(), "<keygen></keygen>" };
            yield return new object[] { new Label(), "<label></label>" };
            yield return new object[] { new Legend(), "<legend></legend>" };
            yield return new object[] { new Li(), "<li></li>" };
            yield return new object[] { new Link(), "<link />" };
            yield return new object[] { new Map(), "<map></map>" };
            yield return new object[] { new Mark(), "<mark></mark>" };
            yield return new object[] { new Menu(), "<menu></menu>" };
            yield return new object[] { new Meta(), "<meta />" };
            yield return new object[] { new Meter(), "<meter></meter>" };
            yield return new object[] { new Nav(), "<nav></nav>" };
            yield return new object[] { new Noframes(), "<noframes></noframes>" };
            yield return new object[] { new Noscript(), "<noscript></noscript>" };
            yield return new object[] { new JustCs.Html.Object(), "<object></object>" };
            yield return new object[] { new Ol(), "<ol></ol>" };
            yield return new object[] { new Optgroup(), "<optgroup></optgroup>" };
            yield return new object[] { new Option(), "<option></option>" };
            yield return new object[] { new Output(), "<output></output>" };
            yield return new object[] { new P(), "<p></p>" };
            yield return new object[] { new Param(), "<param></param>" };
            yield return new object[] { new Pre(), "<pre></pre>" };
            yield return new object[] { new Progress(), "<progress></progress>" };
            yield return new object[] { new Q(), "<q></q>" };
            yield return new object[] { new Rp(), "<rp></rp>" };
            yield return new object[] { new Rt(), "<rt></rt>" };
            yield return new object[] { new Ruby(), "<ruby></ruby>" };
            yield return new object[] { new S(), "<s></s>" };
            yield return new object[] { new Samp(), "<samp></samp>" };
            yield return new object[] { new Script(), "<script></script>" };
            yield return new object[] { new Section(), "<section></section>" };
            yield return new object[] { new Select(), "<select></select>" };
            yield return new object[] { new Small(), "<small></small>" };
            yield return new object[] { new Source(), "<source></source>" };
            yield return new object[] { new Span(), "<span></span>" };
            yield return new object[] { new Strike(), "<strike></strike>" };
            yield return new object[] { new Strong(), "<strong></strong>" };
            yield return new object[] { new Style(), "<style></style>" };
            yield return new object[] { new Sub(), "<sub></sub>" };
            yield return new object[] { new Sup(), "<sup></sup>" };
            yield return new object[] { new Table(), "<table></table>" };
            yield return new object[] { new Tbody(), "<tbody></tbody>" };
            yield return new object[] { new Td(), "<td></td>" };
            yield return new object[] { new Textarea(), "<textarea></textarea>" };
            yield return new object[] { new Tfoot(), "<tfoot></tfoot>" };
            yield return new object[] { new Th(), "<th></th>" };
            yield return new object[] { new Thead(), "<thead></thead>" };
            yield return new object[] { new Time(), "<time></time>" };
            yield return new object[] { new Title(), "<title></title>" };
            yield return new object[] { new Tr(), "<tr></tr>" };
            yield return new object[] { new Track(), "<track></track>" };
            yield return new object[] { new Tt(), "<tt></tt>" };
            yield return new object[] { new U(), "<u></u>" };
            yield return new object[] { new Ul(), "<ul></ul>" };
            yield return new object[] { new Variable(), "<variable></variable>" };
            yield return new object[] { new Video(), "<video></video>" };
            yield return new object[] { new Wbr(), "<wbr></wbr>" };
        }

        public static IEnumerable<object[]> TagsWithAttributes()
        {
            #region String Attributes
            // No Attribute set
            yield return new object[] { new A(), "<a></a>" };
            yield return new object[] { new Img(), "<img />" };

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Src = null } }, "<a></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = null } }, "<img />" };

            // Attribute set to empty
            yield return new object[] { new A { Attributes = new Attrs { Src = "" } }, "<a src=\"\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = "" } }, "<img src=\"\" />" };

            // Attribute include quote
            yield return new object[] { new A { Attributes = new Attrs { Src = "\"" } }, "<a src=\"&quot;\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = "\"" } }, "<img src=\"&quot;\" />" };

            // Attribute set to a value
            yield return new object[] { new A { Attributes = new Attrs { Src = "foo" } }, "<a src=\"foo\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = "foo" } }, "<img src=\"foo\" />" };
            #endregion

            #region Boolean Attributes

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Contenteditable = null } }, "<a></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Contenteditable = null } }, "<img />" };

            // Attribute set to true
            yield return new object[] { new A { Attributes = new Attrs { Contenteditable = true } }, "<a contenteditable></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Contenteditable = true } }, "<img contenteditable />" };

            // Attribute set to false
            yield return new object[] { new A { Attributes = new Attrs { Contenteditable = false } }, "<a></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Contenteditable = false } }, "<img />" };
            #endregion

            #region Int Attributes

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Tabindex = null } }, "<a></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Tabindex = null } }, "<img />" };

            // Attribute set to 1
            yield return new object[] { new A { Attributes = new Attrs { Tabindex = 1 } }, "<a tabindex=\"1\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Tabindex = 1 } }, "<img tabindex=\"1\" />" };

            // Attribute set to 0
            yield return new object[] { new A { Attributes = new Attrs { Tabindex = 0 } }, "<a tabindex=\"0\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Tabindex = 0 } }, "<img tabindex=\"0\" />" };
            #endregion

            #region Enum Attributes

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Dir = null } }, "<a></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = null } }, "<img />" };

            // Attribute set to auto
            yield return new object[] { new A { Attributes = new Attrs { Dir = DirValues.Auto } }, "<a dir=\"auto\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = DirValues.Auto } }, "<img dir=\"auto\" />" };

            // Attribute set to ltr
            yield return new object[] { new A { Attributes = new Attrs { Dir = DirValues.Ltr } }, "<a dir=\"ltr\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = DirValues.Ltr } }, "<img dir=\"ltr\" />" };

            // Attribute set to rtl
            yield return new object[] { new A { Attributes = new Attrs { Dir = DirValues.Rtl } }, "<a dir=\"rtl\"></a>" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = DirValues.Rtl } }, "<img dir=\"rtl\" />" };
            #endregion

            #region Special-named Attributes

            yield return new object[] { new Form { Attributes = new Attrs { AcceptCharset = "utf-8" } }, "<form accept-charset=\"utf-8\"></form>" };
            yield return new object[] { new Meta { Attributes = new Attrs { HttpEquiv = "content-type" } }, "<meta http-equiv=\"content-type\" />" };
            #endregion
        }

        public static IEnumerable<object[]> TagWithChildren()
        {
            // Simple with one child.
            yield return new object[] {
                new Div
                {
                    Children = new Element[]{
                        new A()
                    },
                },
                "<div><a></a>\n</div>",
            };

            // Simple with multiple children.
            yield return new object[] {
                new Div
                {
                    Children = new Element[]{
                        new A(),
                        new A(),
                        new A(),
                    },
                },
                "<div><a></a>\n<a></a>\n<a></a>\n</div>",
            };

            // Nested children.
            yield return new object[] {
                new Div
                {
                    Children = new Element[]{
                        new Div
                        {
                            Children = new Element[]
                            {
                                new A(),
                                new A(),
                            }
                        },
                        new A(),
                    },
                },
                "<div><div><a></a>\n<a></a>\n</div>\n<a></a>\n</div>",
            };

            // Text nodes
            yield return new object[] {
                new Div
                {
                    Children = new Element[]{
                        // All the types bellow get implicitly converted into TextElement objects.
                        "String",
                        true,
                        (byte)5,
                        (sbyte)-5,
                        (short)-200,
                        (ushort)200,
                        -300, 
                        (uint)300,
                        (long)-600,
                        (ulong)600,
                        IntPtr.Zero,
                        UIntPtr.Zero,
                        'a',
                        10.1,
                        (float)10.2,
                        (string)null
                    },
                },
                @"<div>StringTrue5-5-200200-300300-60060000a10.110.2</div>",
            };

            // Mix Text and element nodes
            yield return new object[] {
                new Div
                {
                    Children = new Element[]{
                        "String",
                        new A(),
                        -300,
                    },
                },
                "<div>String<a></a>\n-300</div>",
            };

            // Fragment special element
            yield return new object[] {
                new Div
                {
                    Children = new Element[]{
                        // Fragment children must be rendered as direct children
                        // of Div
                        new Fragment{
                            Children = new Element[]{
                                new A(),
                                new A(),
                                new A(),
                            }
                        },
                    },
                },
                "<div><a></a>\n<a></a>\n<a></a>\n</div>",
            };
        }

        [Theory]
        [MemberData(nameof(AllTagsNoAttributes))]
        public void RenderAsHtml_ShouldRenderTagsWithoutAttributes(Element element, string expectedResult)
        {
            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(expectedResult, result.TrimEnd('\n'));
        }

        [Theory]
        [MemberData(nameof(TagsWithAttributes))]
        public void RenderAsHtml_ShouldHandleAllAttributeTypes(Element element, string expectedResult)
        {
            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(expectedResult, result.TrimEnd('\n'));
        }

        [Theory]
        [MemberData(nameof(TagWithChildren))]
        public void RenderAsHtml_ShouldHandleChildren(Element element, string expectedResult)
        {
            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(expectedResult, result.TrimEnd('\n'));
        }

        [Fact]
        public void RenderAsHtml_ShouldHandleDataSetProperties()
        {
            // Arrange
            var dataset = new
            {
                simple = "value",
                Simple2 = "value2",
                ToDashCase = "value3",
                // This should not appear
                Nullish = (string)null,
                // This should just be present (without value)
                True = true,
                // This should not appear
                False = false,
                Number = 100
            };

            var element = new Div
            {
                Attributes = new Attrs
                {
                    DataSet = dataset,
                },
            };

            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(
                "<div data-simple=\"value\" data-simple2=\"value2\" data-to-dash-case=\"value3\" data-true data-number=\"100\"></div>",
                result.TrimEnd('\n')
            );
        }

        [Fact]
        public void RenderAsHtml_ShouldHandleAriaProperties()
        {
            // Arrange
            var ariaProperties = new AriaAttrs
            {
                Activedescendant = "value",
                Atomic = BooleanValues.True,
                Autocomplete = AriaAutoCompleteValues.Both,
                Busy = BooleanValues.False,
                Checked = TriState.Mixed,
                Controls = "value",
                Describedby = "value",
                Disabled = BooleanValues.False,
                Dropeffect = AriaDropEffectValues.Move,
                Expanded = BooleanValues.False,
                Flowto = "value",
                Grabbed = BooleanValues.False,
                Haspopup = BooleanValues.False,
                Hidden = BooleanValues.False,
                Invalid = AriaInvalidValues.Grammar,
                Label = "value",
                Labelledby = "value",
                Level = 10,
                Live = AriaLiveValues.Polite,
                Multiline = BooleanValues.False,
                Multiselectable = BooleanValues.False,
                Orientation = AriaOrientationValues.Vertical,
                Owns = "value",
                Posinset = 10,
                Pressed = TriState.Mixed,
                Readonly = BooleanValues.False,
                Relevant = "value",
                Required = BooleanValues.False,
                Selected = BooleanValues.False,
                Setsize = 10,
                Sort = AriaSortValues.Ascending,
                Valuemax = 10,
                Valuemin = 10,
                Valuenow = 10,
                Valuetext = "value",
            };

            var element = new Div
            {
                Attributes = new Attrs
                {
                    Aria = ariaProperties,
                },
            };

            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(
                "<div aria-activedescendant=\"value\" aria-atomic=\"true\" aria-autocomplete=\"both\" aria-busy=\"false\" aria-checked=\"mixed\" aria-controls=\"value\" aria-describedby=\"value\" aria-disabled=\"false\" aria-dropeffect=\"move\" aria-expanded=\"false\" aria-flowto=\"value\" aria-grabbed=\"false\" aria-haspopup=\"false\" aria-hidden=\"false\" aria-invalid=\"grammar\" aria-label=\"value\" aria-labelledby=\"value\" aria-level=\"10\" aria-live=\"polite\" aria-multiline=\"false\" aria-multiselectable=\"false\" aria-orientation=\"vertical\" aria-owns=\"value\" aria-posinset=\"10\" aria-pressed=\"mixed\" aria-readonly=\"false\" aria-relevant=\"value\" aria-required=\"false\" aria-selected=\"false\" aria-setsize=\"10\" aria-sort=\"ascending\" aria-valuemax=\"10\" aria-valuemin=\"10\" aria-valuenow=\"10\" aria-valuetext=\"value\"></div>",
                result.TrimEnd('\n')
            );
        }

        [Fact]
        public void RenderAsHtml_ShouldThrowWhenElementIsNull()
        {
            // Arrange
            Element invalidElement = null;

            // Act
            Action action = () => invalidElement.RenderAsHtml();

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("element", exception.ParamName);
        }
    }
}
