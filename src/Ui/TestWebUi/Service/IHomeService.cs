using Test.Shared.Dto.Api;

namespace TestWebUi.Service;

public interface IHomeService
{
    Task<ResponseDto> FatchThirdPartDataAsync(string key);
    Task<ResponseDto> GetAllDataAsync();
}
