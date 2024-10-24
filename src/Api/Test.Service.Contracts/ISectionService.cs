using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Shared.Dto;

namespace Test.Service.Contracts;

public interface ISectionService
{
    Task<IEnumerable<SectionDto>> GetAllSectionsAsync(bool trackChanges);
    Task<SectionDto> GetSectionAsync(int sectionId, bool trackChanges);
    Task<SectionDto> CreateSectionAsync(SectionForCreationDto section);
    Task<SectionDto> GetByNameAddInsert(string name);
}
