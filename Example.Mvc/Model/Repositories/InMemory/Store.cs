﻿using System;
using System.Collections.Generic;

namespace Example.Mvc.Model.Repositories.InMemory
{
    internal class Store
    {
        public int LastFooId = 1;
        public IDictionary<int, ValueTuple<string>> FoosTable = new Dictionary<int, ValueTuple<string>>();
    }
}
