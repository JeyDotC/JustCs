using System;
using System.Collections.Generic;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs
{
    public abstract class Element
    {
        public abstract string Tag { get; }

        public IElementAttributes Attributes { get; init; }

        public virtual bool SelfClosed { get; }

        public IEnumerable<Element> Children { get; init; }

        public static implicit operator Element(string data) => new TextElement { Data = data };
        public static implicit operator Element(bool data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(byte data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(sbyte data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(short data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(ushort data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(int data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(uint data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(long data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(ulong data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(IntPtr data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(UIntPtr data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(char data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(double data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
        public static implicit operator Element(float data) => new TextElement { Data = FormattableString.Invariant($"{data}") };
    }
}
