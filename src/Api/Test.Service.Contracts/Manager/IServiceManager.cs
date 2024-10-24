
using Test.Service.Contracts.Nytimes;

namespace Test.Service.Contracts.Manager;

public interface IServiceManager
{
    ISectionService SectionService { get; }
    IArticleService ArticleService { get; }
    INYTimesService NYTimesService { get; }
}
