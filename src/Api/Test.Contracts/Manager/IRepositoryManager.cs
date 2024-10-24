using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Contracts.Repository;
using Test.Entities.Models;

namespace Test.Contracts.Manager;

public interface IRepositoryManager
{
    IArticleRepository Article { get; }
    ISectionRepository Section { get; }
    ISubsectionRepository Subsection { get; }
    IImageFormatRepository Imageformat { get; }
    IFacetRepository Facet { get; }

    Task SaveAsync();
}
