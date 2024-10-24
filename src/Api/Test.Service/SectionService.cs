using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Contracts;
using Test.Contracts.Manager;
using Test.Entities.Exceptions;
using Test.Entities.Models;
using Test.Service.Contracts;
using Test.Shared.Dto;
using static System.Collections.Specialized.BitVector32;

namespace Test.Service;

public class SectionService(
    IRepositoryManager repository,
    ILoggerManager logger,
    IMapper mapper) : ISectionService
{
    public async Task<IEnumerable<SectionDto>> GetAllSectionsAsync(bool trackChanges)
    {
        var sections = await repository.Section.GetAllSectionsAsync(trackChanges);
        var sectionDtos = mapper.Map<IEnumerable<SectionDto>>(sections);

        return sectionDtos;
    }
    public async Task<SectionDto> GetSectionAsync(int sectionId, bool trackChanges)
    {
        var section = await repository.Section.GetSectionAsync(sectionId, trackChanges);
        //Check if the section is null
        if (section is null)
            throw new GeneralNotFoundException(sectionId, "Section");

        var sectionDto = mapper.Map<SectionDto>(section);
        return sectionDto;
    }

    public async Task<SectionDto> CreateSectionAsync(SectionForCreationDto section)
    {
        var sectionEntity = mapper.Map<Test.Entities.Models.Section>(section);
        repository.Section.CreateSection(sectionEntity);
        await repository.SaveAsync();
        var sectionToReturn = mapper.Map<SectionDto>(sectionEntity);
        return sectionToReturn;
    }

    public async Task<SectionDto> GetByNameAddInsert(string name)
    {
        var section = await repository.Section.GetByNameAsync(name);
        //Check if the section is null
        if (section is null)
        {
            return await CreateSectionAsync (new SectionForCreationDto (name));
        }
        var sectionDto = mapper.Map<SectionDto>(section);
        return sectionDto;
    }
}
