using System;
using System.Collections.Generic;
using System.Linq;
using Example.Api.Model.Models;

namespace Example.Api.Model.Repositories
{
    public class FoosRepositoryInMemory : IFoosRepository
    {
        private readonly Store _store;

        public FoosRepositoryInMemory(Store store)
        {
            _store = store;
        }

        public void AddFoo(Foo foo)
        {

            foo.FooId = _store.LastFooId;

            _store.FoosTable[_store.LastFooId] = new ValueTuple<string>(foo.Name);

            _store.LastFooId++;
        }

        public Foo FindById(int fooId)
        {
            var name = _store.FoosTable[fooId].Item1;
            var bars = _store.BarsTable.Where(kv => kv.Value.Item2 == fooId).Select(kv => new Bar
            {
                BarId = kv.Key,
                Name = kv.Value.Item1
            });

            return new Foo { Name = name, FooId = fooId, Bars = bars };
        }

        public IEnumerable<Foo> ListFoos() => _store.FoosTable.Select(kv => new Foo {
            FooId = kv.Key,
            Name = kv.Value.Item1
        });
    }
}
