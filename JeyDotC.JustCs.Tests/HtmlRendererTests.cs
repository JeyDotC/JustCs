using System;
using System.Collections.Generic;
using Xunit;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Tests
{
    record AttrsExtra : Attrs
    {
        public string Nonce { get; init; }
    }

    public class HtmlRendererTests
    {
        public static IEnumerable<object[]> AllTagsNoAttributes()
        {
            yield return new object[] { new A(), "<a></a>\n" };
            yield return new object[] { new Abbr(), "<abbr></abbr>\n" };
            yield return new object[] { new Acronym(), "<acronym></acronym>\n" };
            yield return new object[] { new Address(), "<address></address>\n" };
            yield return new object[] { new Applet(), "<applet></applet>\n" };
            yield return new object[] { new Area(), "<area></area>\n" };
            yield return new object[] { new Article(), "<article></article>\n" };
            yield return new object[] { new Aside(), "<aside></aside>\n" };
            yield return new object[] { new Audio(), "<audio></audio>\n" };
            yield return new object[] { new B(), "<b></b>\n" };
            yield return new object[] { new Base(), "<base></base>\n" };
            yield return new object[] { new Basefont(), "<basefont></basefont>\n" };
            yield return new object[] { new Bb(), "<bb></bb>\n" };
            yield return new object[] { new Bdo(), "<bdo></bdo>\n" };
            yield return new object[] { new Big(), "<big></big>\n" };
            yield return new object[] { new Blockquote(), "<blockquote></blockquote>\n" };
            yield return new object[] { new Body(), "<body></body>\n" };
            yield return new object[] { new Br(), "<br />\n" };
            yield return new object[] { new Button(), "<button></button>\n" };
            yield return new object[] { new Canvas(), "<canvas></canvas>\n" };
            yield return new object[] { new Caption(), "<caption></caption>\n" };
            yield return new object[] { new Center(), "<center></center>\n" };
            yield return new object[] { new Cite(), "<cite></cite>\n" };
            yield return new object[] { new Code(), "<code></code>\n" };
            yield return new object[] { new Col(), "<col></col>\n" };
            yield return new object[] { new Colgroup(), "<colgroup></colgroup>\n" };
            yield return new object[] { new Command(), "<command></command>\n" };
            yield return new object[] { new Datagrid(), "<datagrid></datagrid>\n" };
            yield return new object[] { new Datalist(), "<datalist></datalist>\n" };
            yield return new object[] { new Dd(), "<dd></dd>\n" };
            yield return new object[] { new Del(), "<del></del>\n" };
            yield return new object[] { new Details(), "<details></details>\n" };
            yield return new object[] { new Dfn(), "<dfn></dfn>\n" };
            yield return new object[] { new Dialog(), "<dialog></dialog>\n" };
            yield return new object[] { new Dir(), "<dir></dir>\n" };
            yield return new object[] { new Div(), "<div></div>\n" };
            yield return new object[] { new Dl(), "<dl></dl>\n" };
            yield return new object[] { new Dt(), "<dt></dt>\n" };
            yield return new object[] { new Em(), "<em></em>\n" };
            yield return new object[] { new Embed(), "<embed></embed>\n" };
            yield return new object[] { new Eventsource(), "<eventsource></eventsource>\n" };
            yield return new object[] { new Fieldset(), "<fieldset></fieldset>\n" };
            yield return new object[] { new Figcaption(), "<figcaption></figcaption>\n" };
            yield return new object[] { new Figure(), "<figure></figure>\n" };
            yield return new object[] { new Font(), "<font></font>\n" };
            yield return new object[] { new Footer(), "<footer></footer>\n" };
            yield return new object[] { new Form(), "<form></form>\n" };
            yield return new object[] { new Frame(), "<frame></frame>\n" };
            yield return new object[] { new Frameset(), "<frameset></frameset>\n" };
            yield return new object[] { new H1(), "<h1></h1>\n" };
            yield return new object[] { new H2(), "<h2></h2>\n" };
            yield return new object[] { new H3(), "<h3></h3>\n" };
            yield return new object[] { new H4(), "<h4></h4>\n" };
            yield return new object[] { new H5(), "<h5></h5>\n" };
            yield return new object[] { new H6(), "<h6></h6>\n" };
            yield return new object[] { new Head(), "<head></head>\n" };
            yield return new object[] { new Header(), "<header></header>\n" };
            yield return new object[] { new Hgroup(), "<hgroup></hgroup>\n" };
            yield return new object[] { new Hr(), "<hr />\n" };
            yield return new object[] { new JustCs.Html.Html(), "<html></html>\n" };
            yield return new object[] { new I(), "<i></i>\n" };
            yield return new object[] { new Iframe(), "<iframe></iframe>\n" };
            yield return new object[] { new Img(), "<img />\n" };
            yield return new object[] { new Input(), "<input />\n" };
            yield return new object[] { new Ins(), "<ins></ins>\n" };
            yield return new object[] { new Isindex(), "<isindex></isindex>\n" };
            yield return new object[] { new Kbd(), "<kbd></kbd>\n" };
            yield return new object[] { new Keygen(), "<keygen></keygen>\n" };
            yield return new object[] { new Label(), "<label></label>\n" };
            yield return new object[] { new Legend(), "<legend></legend>\n" };
            yield return new object[] { new Li(), "<li></li>\n" };
            yield return new object[] { new Link(), "<link />\n" };
            yield return new object[] { new Map(), "<map></map>\n" };
            yield return new object[] { new Mark(), "<mark></mark>\n" };
            yield return new object[] { new Menu(), "<menu></menu>\n" };
            yield return new object[] { new Meta(), "<meta />\n" };
            yield return new object[] { new Meter(), "<meter></meter>\n" };
            yield return new object[] { new Nav(), "<nav></nav>\n" };
            yield return new object[] { new Noframes(), "<noframes></noframes>\n" };
            yield return new object[] { new Noscript(), "<noscript></noscript>\n" };
            yield return new object[] { new JustCs.Html.Object(), "<object></object>\n" };
            yield return new object[] { new Ol(), "<ol></ol>\n" };
            yield return new object[] { new Optgroup(), "<optgroup></optgroup>\n" };
            yield return new object[] { new Option(), "<option></option>\n" };
            yield return new object[] { new Output(), "<output></output>\n" };
            yield return new object[] { new P(), "<p></p>\n" };
            yield return new object[] { new Param(), "<param></param>\n" };
            yield return new object[] { new Pre(), "<pre></pre>\n" };
            yield return new object[] { new Progress(), "<progress></progress>\n" };
            yield return new object[] { new Q(), "<q></q>\n" };
            yield return new object[] { new Rp(), "<rp></rp>\n" };
            yield return new object[] { new Rt(), "<rt></rt>\n" };
            yield return new object[] { new Ruby(), "<ruby></ruby>\n" };
            yield return new object[] { new S(), "<s></s>\n" };
            yield return new object[] { new Samp(), "<samp></samp>\n" };
            yield return new object[] { new Script(), "<script></script>\n" };
            yield return new object[] { new Section(), "<section></section>\n" };
            yield return new object[] { new Select(), "<select></select>\n" };
            yield return new object[] { new Small(), "<small></small>\n" };
            yield return new object[] { new Source(), "<source></source>\n" };
            yield return new object[] { new Span(), "<span></span>\n" };
            yield return new object[] { new Strike(), "<strike></strike>\n" };
            yield return new object[] { new Strong(), "<strong></strong>\n" };
            yield return new object[] { new Style(), "<style></style>\n" };
            yield return new object[] { new Sub(), "<sub></sub>\n" };
            yield return new object[] { new Sup(), "<sup></sup>\n" };
            yield return new object[] { new Table(), "<table></table>\n" };
            yield return new object[] { new Tbody(), "<tbody></tbody>\n" };
            yield return new object[] { new Td(), "<td></td>\n" };
            yield return new object[] { new Textarea(), "<textarea></textarea>\n" };
            yield return new object[] { new Tfoot(), "<tfoot></tfoot>\n" };
            yield return new object[] { new Th(), "<th></th>\n" };
            yield return new object[] { new Thead(), "<thead></thead>\n" };
            yield return new object[] { new Time(), "<time></time>\n" };
            yield return new object[] { new Title(), "<title></title>\n" };
            yield return new object[] { new Tr(), "<tr></tr>\n" };
            yield return new object[] { new Track(), "<track></track>\n" };
            yield return new object[] { new Tt(), "<tt></tt>\n" };
            yield return new object[] { new U(), "<u></u>\n" };
            yield return new object[] { new Ul(), "<ul></ul>\n" };
            yield return new object[] { new Variable(), "<variable></variable>\n" };
            yield return new object[] { new Video(), "<video></video>\n" };
            yield return new object[] { new Wbr(), "<wbr></wbr>\n" };
        }

        public static IEnumerable<object[]> TagsWithAttributes()
        {
            #region String Attributes
            // No Attribute set
            yield return new object[] { new A(), "<a></a>\n" };
            yield return new object[] { new Img(), "<img />\n" };

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Src = null } }, "<a></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = null } }, "<img />\n" };

            // Attribute set to empty
            yield return new object[] { new A { Attributes = new Attrs { Src = "" } }, "<a src=\"\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = "" } }, "<img src=\"\" />\n" };

            // Attribute include quote
            yield return new object[] { new A { Attributes = new Attrs { Src = "\"" } }, "<a src=\"&quot;\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = "\"" } }, "<img src=\"&quot;\" />\n" };

            // Attribute set to a value
            yield return new object[] { new A { Attributes = new Attrs { Src = "foo" } }, "<a src=\"foo\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Src = "foo" } }, "<img src=\"foo\" />\n" };
            #endregion

            #region Boolean Attributes

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Contenteditable = null } }, "<a></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Contenteditable = null } }, "<img />\n" };

            // Attribute set to true
            yield return new object[] { new A { Attributes = new Attrs { Contenteditable = true } }, "<a contenteditable></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Contenteditable = true } }, "<img contenteditable />\n" };

            // Attribute set to false
            yield return new object[] { new A { Attributes = new Attrs { Contenteditable = false } }, "<a></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Contenteditable = false } }, "<img />\n" };
            #endregion

            #region Int Attributes

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Tabindex = null } }, "<a></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Tabindex = null } }, "<img />\n" };

            // Attribute set to 1
            yield return new object[] { new A { Attributes = new Attrs { Tabindex = 1 } }, "<a tabindex=\"1\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Tabindex = 1 } }, "<img tabindex=\"1\" />\n" };

            // Attribute set to 0
            yield return new object[] { new A { Attributes = new Attrs { Tabindex = 0 } }, "<a tabindex=\"0\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Tabindex = 0 } }, "<img tabindex=\"0\" />\n" };
            #endregion

            #region Enum Attributes

            // Attribute set to null
            yield return new object[] { new A { Attributes = new Attrs { Dir = null } }, "<a></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = null } }, "<img />\n" };

            // Attribute set to auto
            yield return new object[] { new A { Attributes = new Attrs { Dir = DirValues.Auto } }, "<a dir=\"auto\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = DirValues.Auto } }, "<img dir=\"auto\" />\n" };

            // Attribute set to ltr
            yield return new object[] { new A { Attributes = new Attrs { Dir = DirValues.Ltr } }, "<a dir=\"ltr\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = DirValues.Ltr } }, "<img dir=\"ltr\" />\n" };

            // Attribute set to rtl
            yield return new object[] { new A { Attributes = new Attrs { Dir = DirValues.Rtl } }, "<a dir=\"rtl\"></a>\n" };
            yield return new object[] { new Img { Attributes = new Attrs { Dir = DirValues.Rtl } }, "<img dir=\"rtl\" />\n" };
            #endregion

            #region Special-named Attributes

            yield return new object[] { new Form { Attributes = new Attrs { AcceptCharset = "utf-8" } }, "<form accept-charset=\"utf-8\"></form>\n" };
            yield return new object[] { new Meta { Attributes = new Attrs { HttpEquiv = "content-type" } }, "<meta http-equiv=\"content-type\" />\n" };
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
                "<div><a></a>\n" +
                "</div>\n",
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
                "<div><a></a>\n" +
                "<a></a>\n" +
                "<a></a>\n" +
                "</div>\n",
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
                "<div><div><a></a>\n" +
                "<a></a>\n" +
                "</div>\n" +
                "<a></a>\n" +
                "</div>\n",
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
                "<div>StringTrue5-5-200200-300300-60060000a10.110.2</div>\n",
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
                "<div>String<a></a>\n" +
                "-300</div>\n",
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
                "<div><a></a>\n" +
                "<a></a>\n" +
                "<a></a>\n" +
                "</div>\n",
            };

            // Conditionally rendered elements
            yield return new object[] {
                new Div
                {
                    Children = new Element[]{
                        // All the types bellow get implicitly converted into TextElement objects.
                        // Only the tuples which first element is boolean true will be rendered.
                        (true, "Text"),
                        (false, "Text (Not added!)"),

                        (true, new P{ Children = new Element[]{ "Paragraph" }}),
                        (false, new P{ Children = new Element[]{ "Paragraph (Not added!)" }}),

                        // This is the func version of the above, the given func will be called only
                        // if the first guple's element is true.
                        (true, () => "Func Text"),
                        (false, () => "Func Text (Not added!)"),

                        (true, new P{ Children = new Element[]{ "Func Paragraph" }}),
                        (false, new P{ Children = new Element[]{ "Func Paragraph (Not added!)" }})
                    },
                },
                "<div>" +
                "Text" +
                "<p>Paragraph</p>\n" +
                "Func Text" +
                "<p>Func Paragraph</p>\n" +
                "</div>\n",
            };

            // Tag with null children
            yield return new object[]
            {
                new Div
                {
                    Children = new Element[]
                    {
                        new A(),
                        null,
                        new A(),
                    }
                },
                "<div><a></a>\n" +
                "<a></a>\n" +
                "</div>\n",
            };
        }

        public static IEnumerable<object[]> ElementsWithOverridenAttributes()
        {
            // Basic scenario
            yield return new object[] { new A { Attributes = new Attrs { Href = "A", _ = new { Href = "B" } } }, "<a href=\"B\"></a>\n" };

            // Different casing
            yield return new object[] { new A { Attributes = new Attrs { Href = "A", _ = new { href = "B" } } }, "<a href=\"B\"></a>\n" };

            // Multiple oveerrides
            yield return new object[] { new A { Attributes = new Attrs { Href = "A", _ = new { href = "B", Href="C" } } }, "<a href=\"C\"></a>\n" };

            // Deep oveerrides (Looks like a **very bad** practice, but it is possible)
            yield return new object[] { new A { Attributes = new Attrs { Href = "A", _ = new { href = "B", _ = new { href = "C" } } } }, "<a href=\"C\"></a>\n" };

            // Oveerride aria attributes
            yield return new object[] { new A { Attributes = new Attrs { Aria = new AriaAttrs { Describedby = "something" }, _ = new { AriaDescribedby = "nothing", } } }, "<a aria-describedby=\"nothing\"></a>\n" };

            // Oveerride data attributes
            yield return new object[] { new A { Attributes = new Attrs { DataSet = new { Describedby = "something" }, _ = new { DataDescribedby = "nothing", } } }, "<a data-describedby=\"nothing\"></a>\n" };
        }

        [Theory]
        [MemberData(nameof(AllTagsNoAttributes))]
        public void RenderAsHtml_ShouldRenderTagsWithoutAttributes(Element element, string expectedResult)
        {
            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(TagsWithAttributes))]
        public void RenderAsHtml_ShouldHandleAllAttributeTypes(Element element, string expectedResult)
        {
            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(TagWithChildren))]
        public void RenderAsHtml_ShouldHandleChildren(Element element, string expectedResult)
        {
            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(expectedResult, result);
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
                "<div data-simple=\"value\" data-simple2=\"value2\" data-to-dash-case=\"value3\" data-true data-number=\"100\"></div>\n",
                result
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
                "<div aria-activedescendant=\"value\" aria-atomic=\"true\" aria-autocomplete=\"both\" aria-busy=\"false\" aria-checked=\"mixed\" aria-controls=\"value\" aria-describedby=\"value\" aria-disabled=\"false\" aria-dropeffect=\"move\" aria-expanded=\"false\" aria-flowto=\"value\" aria-grabbed=\"false\" aria-haspopup=\"false\" aria-hidden=\"false\" aria-invalid=\"grammar\" aria-label=\"value\" aria-labelledby=\"value\" aria-level=\"10\" aria-live=\"polite\" aria-multiline=\"false\" aria-multiselectable=\"false\" aria-orientation=\"vertical\" aria-owns=\"value\" aria-posinset=\"10\" aria-pressed=\"mixed\" aria-readonly=\"false\" aria-relevant=\"value\" aria-required=\"false\" aria-selected=\"false\" aria-setsize=\"10\" aria-sort=\"ascending\" aria-valuemax=\"10\" aria-valuemin=\"10\" aria-valuenow=\"10\" aria-valuetext=\"value\"></div>\n",
                result
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

        [Fact]
        public void RenderAsHtml_ShouldAcceptExtendedAttributes()
        {
            // Arrange
            var attrsExtra = new AttrsExtra { Nonce = "extra-info", Src = "source" };
            var script = new Script
            {
                Attributes = attrsExtra
            };

            // Act
            var result = script.RenderAsHtml();

            // Assert
            Assert.Equal("<script nonce=\"extra-info\" src=\"source\"></script>\n", result);
        }

        [Fact]
        public void RenderAsHtml_ShouldAcceptAppendedAttributes()
        {
            // Arrange
            var attributes = new Attrs
            {
                Id = "my-id",
                DataSet = new
                {
                    SomeValue = "value"
                },
                Aria = new AriaAttrs
                {
                    Hidden = BooleanValues.False,
                },
                _ = new
                {
                    Nonce = "some-value",
                    ArbitraryValue = "arbitrary"
                }
            };
            var div = new Div { Attributes = attributes };

            // Act
            var result = div.RenderAsHtml();

            // Assert
            Assert.Equal("<div aria-hidden=\"false\" data-some-value=\"value\" id=\"my-id\" nonce=\"some-value\" arbitrary-value=\"arbitrary\"></div>\n", result);

        }

        class MaliciousElement : Element
        {
            public override string Tag => "malicious /> <script>alert('evil!');</script> <malicious";
        }

        [Fact]
        public void RenderAsHtml_ShouldThrowOnInvalidTagNames()
        {
            // Arrange
            var maliciousElement = new MaliciousElement { };

            // Act
            Action action = () => maliciousElement.RenderAsHtml();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Theory]
        [MemberData(nameof(ElementsWithOverridenAttributes))]
        public void RenderAsHtml_AttributesDefinedAtSpreadPropertyShouldOverridePreviousOnes(Element element, string expectedResult)
        {
            // Act
            var result = element.RenderAsHtml();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
