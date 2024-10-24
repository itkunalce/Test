using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Models;

namespace Test.Contracts.Repository;

public interface IMultimediaRepository
{
    Task<Multimedia> GetByUrlAsync(string url);
    void CreateMultimedia(Multimedia multimedia);
}
