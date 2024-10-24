using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
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
    public class MultimediaRepository : RepositoryBase<Multimedia>, IMultimediaRepository
    {
        public MultimediaRepository(TestDbContext _db) : base(_db)
        {
        }

        public void CreateMultimedia(Multimedia multimedia)
        {
            Create(multimedia);
        }

        public async Task<Multimedia> GetByUrlAsync(string url)
        {
            return await FindByCondition(c => c.Url.Equals(url), false).SingleOrDefaultAsync();
        }
    }
}
