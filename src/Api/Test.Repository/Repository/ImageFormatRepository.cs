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
    public class ImageFormatRepository : RepositoryBase<ImageFormat>, IImageFormatRepository
    {
        public ImageFormatRepository(TestDbContext _db) : base(_db)
        {
        }

        public void CreateImageformat(ImageFormat Imageformat)
        {
            Create(Imageformat);
        }

        public async Task<ImageFormat> GetByNameAsync(string format)
        {
            return await FindByCondition(c => c.Format.Equals(format), false).SingleOrDefaultAsync();
        }
    }
}
