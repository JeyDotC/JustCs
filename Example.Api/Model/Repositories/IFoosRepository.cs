using System;
using System.Collections.Generic;
using Example.Api.Model.Models;

namespace Example.Api.Model.Repositories
{
    public interface IFoosRepository
    {
        Foo FindById(int fooId);

        IEnumerable<Foo> ListFoos();

        void AddFoo(Foo foo);
    }
}
