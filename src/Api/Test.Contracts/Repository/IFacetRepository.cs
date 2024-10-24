using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Models;

namespace Test.Contracts.Repository;

public interface IFacetRepository
{
    Task<Facet> GetByNameAsync(string name);
    void CreateFacet(Facet facet);
}
