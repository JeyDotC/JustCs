using System;
using System.Collections.Generic;
using Example.Mvc.Model.Models;

namespace Example.Mvc.Model.Repositories
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
