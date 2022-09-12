using System;
using System.Collections.Generic;

namespace Example.Api.Model.Repositories
{
    public class Store
    {
        public int LastFooId = 1;
        public IDictionary<int, ValueTuple<string>> FoosTable = new Dictionary<int, ValueTuple<string>>();

        public int LastBarsId = 1;
        public IDictionary<int, ValueTuple<string, int>> BarsTable = new Dictionary<int, ValueTuple<string, int>>();
    }
}
