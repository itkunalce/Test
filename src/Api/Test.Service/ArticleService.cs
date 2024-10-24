using AutoMapper; 
using Test.Contracts.Manager;
using Test.Contracts;
using Test.Service.Contracts;
using Test.Shared.Dto.NYTimes;
using Test.Entities.Models;
using Test.Shared.Dto;

namespace Test.Service
{
    public class ArticleService(
    IRepositoryManager repository,
    ILoggerManager logger,
    IMapper mapper) : IArticleService
    {
        public async Task<bool> InsertArticleAsync(NYTArticle nytArticle)
        {
            //Article By Url Exist Then Skip
            //Article Repo Have Function To Check Exists 

            Article article = await repository.Article.GetByUrlAsync(nytArticle.url);

            if (article is null)
            {

                //Section, Subsection If Exist Then Set Id Else Insert And Set Id
                //Section, SubSection Repo have Function GetIdByName

                var section = await repository.Section.GetByNameAsync(nytArticle.section);
                if (section is null)
                {
                    section = new Section() { Name = nytArticle.section };
                    repository.Section.CreateSection(section);
                    await repository.SaveAsync();
                }

                var subsection = await repository.Subsection.GetByNameAsync(nytArticle.subsection);
                if (subsection is null)
                {
                    subsection = new Subsection() { Name = nytArticle.subsection };
                    repository.Subsection.CreateSubsection(subsection);
                    await repository.SaveAsync();
                }

                //Insert Article
                article = new Article();
                article.Title = nytArticle.title;
                article.SectionId = section.Id;
                article.SubsectionId = subsection.Id;
                article.Abstract = nytArticle.@abstract;
                article.Url = nytArticle.url;
                article.Uri = nytArticle.uri;
                article.Byline = nytArticle.byline;
                article.ItemType = nytArticle.item_type;
                article.UpdatedDate = nytArticle.updated_date;
                article.CreatedDate = nytArticle.created_date;
                article.PublishedDate = nytArticle.published_date;
                article.MaterialTypeFacet = nytArticle.material_type_facet;
                article.Kicker = nytArticle.kicker;
                article.ShortUrl = nytArticle.short_url;

                article.ArticleFacet = new List<ArticleFacet>();

                //ArticleFacet Add Data 
                article = await InsertArticleFacetAsync(article, nytArticle.des_facet, "dec");
                article = await InsertArticleFacetAsync(article, nytArticle.org_facet, "org");
                article = await InsertArticleFacetAsync(article, nytArticle.per_facet, "per");
                article = await InsertArticleFacetAsync(article, nytArticle.geo_facet, "geo");

                article.Multimedia = new List<Multimedia>();

                //Multimedia Add Data.
                foreach (var obj in nytArticle.multimedia)
                {
                    var imageformat = await repository.Imageformat.GetByNameAsync(obj.format);

                    if (imageformat is null)
                    {
                        imageformat = new ImageFormat() { Format = obj.format, Width = obj.width, Height = obj.height };
                        repository.Imageformat.CreateImageformat(imageformat);
                        await repository.SaveAsync();
                    }

                    Multimedia multimedia = new Multimedia();

                    multimedia.Url = obj.url;
                    multimedia.Type = obj.type;
                    multimedia.Subtype = obj.subtype;
                    multimedia.Caption = obj.caption;
                    multimedia.Copyright = obj.copyright;
                    multimedia.ImageFormatId = imageformat.Id;

                    article.Multimedia.Add(multimedia);
                }

                repository.Article.CreateArticle(article);

                //Save All Data
                await repository.SaveAsync();
                return true;
            }
            return false;
            //Return True.

            
        }

        private async Task<Article> InsertArticleFacetAsync(Article article, List<string> facets, string mode)
        {
            foreach (var obj in facets)
            {
                var facet = await repository.Facet.GetByNameAsync(obj);
                if (facet is null)
                {
                    facet = new Facet() { Name = obj };
                    repository.Facet.CreateFacet(facet);
                    await repository.SaveAsync();
                }
                if(article.ArticleFacet is null)
                    article.ArticleFacet = new List<ArticleFacet>();
                ArticleFacet articleFacet = new ArticleFacet();
                articleFacet.FacetId = facet.Id;
                articleFacet.FacetType = mode;
                article.ArticleFacet.Add(articleFacet);
            }
            return article;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllDetailAsync(bool trackChanges)
        {
            var data = await repository.Article.GetAllArticlesWithDetailsAsync(false); 
            return mapper.Map<IEnumerable<ArticleDto>>(data);
        }
    }
}
