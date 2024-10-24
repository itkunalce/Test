using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Models;

namespace Test.Contracts.Repository;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges);
    Task<IEnumerable<Article>> GetAllArticlesWithDetailsAsync(bool trackChanges);
    Task<Article> GetArticleAsync(int articleId, bool trackChanges);
    Task<Article> GetByUrlAsync(string url);
    void CreateArticle(Article article);

}
