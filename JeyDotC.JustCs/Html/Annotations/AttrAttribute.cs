using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeyDotC.JustCs.Html.Annotations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class AttrAttribute : Attribute
    {
        // This is a positional argument
        public AttrAttribute(NameTransform nameTransform = NameTransform.DashCase)
        {
           NameTransform = nameTransform;
        }

        public NameTransform NameTransform { get; init; }
    }
}
