using System;
using System.Collections.Generic;

namespace Example.Api.Model.Models
{
    public class Bar
    {
        public int BarId { get; set; }

        public string Name { get; set; }

        public Foo Foo { get; set; }
    }
}
