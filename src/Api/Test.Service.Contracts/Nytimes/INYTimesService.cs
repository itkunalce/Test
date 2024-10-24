 
using Test.Shared.Dto.NYTimes;

namespace Test.Service.Contracts.Nytimes;

public interface INYTimesService
{
    Task<NYTResponse> FatchNYTimesHomeTopStories(string Key);
}
