using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Contracts.Repository;
using Test.Entities.Models;
using Test.Repository.Repository.Base;

namespace Test.Repository.Repository
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(TestDbContext _db) : base(_db)
        {
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }
       
        public async Task<IEnumerable<Article>> GetAllArticlesWithDetailsAsync(bool trackChanges)
        {
            var data = await FindAll(trackChanges)
                .Include(p => p.Section)
                .Include(p => p.Subsection)
                .Include(p => p.Multimedia).ThenInclude(p => p.ImageFormat)
                .Include(p => p.ArticleFacet).ThenInclude(p =>p.Facet)
                .ToListAsync();
            return data;
        }
        public async Task<Article> GetArticleAsync(int sectionId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(sectionId), trackChanges).SingleOrDefaultAsync();
        }
        public async Task<Article> GetByUrlAsync(string url)
        {
            return await FindByCondition(c => c.Url.Equals(url), false).SingleOrDefaultAsync();
        }
        public void CreateArticle(Article article)
        {
            Create(article);
        }

    }
}
