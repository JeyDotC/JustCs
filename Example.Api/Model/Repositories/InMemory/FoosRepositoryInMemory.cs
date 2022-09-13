using System;
using System.Collections.Generic;
using System.Linq;
using Example.Api.Model.Models;

namespace Example.Api.Model.Repositories.InMemory
{
    internal class FoosRepositoryInMemory : IFoosRepository
    {
        private readonly Store _store;

        public FoosRepositoryInMemory(Store store)
        {
            _store = store;
        }

        public void UpdateFoo(Foo foo)
        {
            _store.FoosTable[foo.FooId] = new ValueTuple<string>(foo.Name);
        }

        public void AddFoo(Foo foo)
        {

            foo.FooId = _store.LastFooId;

            _store.FoosTable[_store.LastFooId] = new ValueTuple<string>(foo.Name);

            _store.LastFooId++;
        }

        public Foo FindById(int fooId)
        {
            ValueTuple<string>? fooRow = _store.FoosTable[fooId];

            if(!fooRow.HasValue)
            {
                return null;
            }

            var name = fooRow.Value.Item1;

            return new Foo { Name = name, FooId = fooId };
        }

        public IEnumerable<Foo> ListFoos() => _store.FoosTable.Select(kv => new Foo {
            FooId = kv.Key,
            Name = kv.Value.Item1
        });

        public void DeleteFoo(int fooId) => _store.FoosTable.Remove(fooId);
    }
}
