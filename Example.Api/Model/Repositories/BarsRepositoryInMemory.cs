using System;
using System.Collections.Generic;
using System.Linq;
using Example.Api.Model.Models;

namespace Example.Api.Model.Repositories
{
    public class BarsRepositoryInMemory : IBarsRepository
    {
        private readonly Store _store;

        public BarsRepositoryInMemory(Store store)
        {
            _store = store;
        }

        public void AddBar(Bar bar)
        {
            bar.BarId = _store.LastBarsId;

            _store.BarsTable[_store.LastBarsId] = new ValueTuple<string, int>(bar.Name, bar.Foo.FooId);

            _store.LastBarsId++;
        }

        public IEnumerable<Bar> ListBars() => _store.BarsTable.Select(kv => new Bar
        {
            BarId = kv.Key,
            Name = kv.Value.Item1
        });

        public Bar FindById(int barId)
        {
            var (name, fooId) = _store.BarsTable[barId];

            var fooName = _store.FoosTable[fooId].Item1;

            return new Bar
            {
                BarId = barId,
                Name = name,
                Foo = new Foo { FooId = fooId, Name = fooName }
            };
        }
    }
}
