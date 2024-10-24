using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Models;

namespace Test.Contracts.Repository;

public interface ISectionRepository
{
    Task<IEnumerable<Section>> GetAllSectionsAsync(bool trackChanges);
    Task<Section> GetSectionAsync(int sectionId, bool trackChanges);
    Task<Section> GetByNameAsync(string name);
    void CreateSection(Section section);

}
