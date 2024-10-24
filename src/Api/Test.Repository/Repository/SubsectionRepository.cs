using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Contracts.Repository;
using Test.Entities.Models;
using Test.Repository.Repository.Base;
using static System.Collections.Specialized.BitVector32;

namespace Test.Repository.Repository
{
    public class SubsectionRepository : RepositoryBase<Subsection>, ISubsectionRepository
    {
        public SubsectionRepository(TestDbContext _db) : base(_db)
        {
        }

        public void CreateSubsection(Subsection subsection)
        {
            Create(subsection);
        }

        public async Task<Subsection> GetByNameAsync(string name)
        {
            return await FindByCondition(c => c.Name.Equals(name), false).SingleOrDefaultAsync();
        }
    }
}
