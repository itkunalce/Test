using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Contracts.Manager;
using Test.Contracts;
using Test.Service.Contracts;
using Test.Service.Contracts.Manager;
using AutoMapper;
using Test.Service.Contracts.Nytimes;
using Test.Service.NYTimes;

namespace Test.Service.Manager;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ISectionService> section;
    private readonly Lazy<INYTimesService> NYTimes;
    private readonly Lazy<IArticleService> article;
    public ServiceManager(
        IRepositoryManager repositoryManager, 
        ILoggerManager logger,
        IMapper mapper,
        IHttpClientFactory httpClientFactory)
    {
        section = new Lazy<ISectionService>(() => new SectionService(repositoryManager, logger, mapper));
        article = new Lazy<IArticleService>(() => new ArticleService(repositoryManager, logger, mapper));
        NYTimes = new Lazy<INYTimesService>(() => new NYTimesService(httpClientFactory));
    }

    public ISectionService SectionService => section.Value;
    public IArticleService ArticleService => article.Value;
    public INYTimesService NYTimesService => NYTimes.Value;
}
