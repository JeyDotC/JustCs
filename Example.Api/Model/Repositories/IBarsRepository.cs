using System;
using System.Collections.Generic;
using Example.Api.Model.Models;

namespace Example.Api.Model.Repositories
{
    public interface IBarsRepository
    {
        Bar FindById(int fooId);

        IEnumerable<Bar> ListBars();

        void AddBar(Bar bar);
    }
}
