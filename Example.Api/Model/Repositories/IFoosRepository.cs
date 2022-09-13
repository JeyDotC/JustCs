using System;
using System.Collections.Generic;
using Example.Api.Model.Models;

namespace Example.Api.Model.Repositories
{
    public interface IFoosRepository
    {
        Foo FindById(int fooId);

        IEnumerable<Foo> ListFoos();

        void UpdateFoo(Foo foo);

        void AddFoo(Foo foo);

        void DeleteFoo(int fooId);
    }
}
