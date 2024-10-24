using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Contracts.Repository;
using Test.Entities.Models;
using Test.Repository.Repository.Base;

namespace Test.Repository.Repository
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(TestDbContext _db) : base(_db)
        {
        }

        public async Task<IEnumerable<Section>> GetAllSectionsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<Section> GetSectionAsync(int sectionId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(sectionId), trackChanges).SingleOrDefaultAsync();
        }
        public async Task<Section> GetByNameAsync(string name)
        {
            return await FindByCondition(c => c.Name.Equals(name), false).SingleOrDefaultAsync();
        }
        public void CreateSection(Section section)
        {
            Create(section);
        }

    }
}
