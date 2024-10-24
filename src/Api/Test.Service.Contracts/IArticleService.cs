using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Shared.Dto;
using Test.Shared.Dto.NYTimes;

namespace Test.Service.Contracts
{
    public interface IArticleService
    {
        Task<bool> InsertArticleAsync(NYTArticle nytArticle);
        Task<IEnumerable<ArticleDto>> GetAllDetailAsync(bool trackChanges);
    }
}
