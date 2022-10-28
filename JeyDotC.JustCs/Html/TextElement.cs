using System;
namespace JeyDotC.JustCs.Html
{
    public sealed class TextElement : Element
    {
        private readonly string? _data;

        public override string Tag => "#Text";

        public string? Data { get => _data; init
            {
                var scapedValue = (value ?? "").Replace("<", "&lt;").Replace(">", "&gt;");
                _data = scapedValue;
            }
        }
    }
}
