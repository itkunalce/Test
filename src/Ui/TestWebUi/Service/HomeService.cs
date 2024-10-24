using System.Text.Json.Serialization;
using System.Text.Json;
using Test.Shared.Dto.Api;
using Test.Shared.Dto.NYTimes;

namespace TestWebUi.Service
{
    public class HomeService(HttpClient client) : IHomeService
    {

        public async Task<ResponseDto> FatchThirdPartDataAsync(string key)
        {
            var response = await client.GetAsync($"api/Nytimes?key={key}");
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var data = JsonSerializer.Deserialize<ResponseDto>(content, options);
            return data;
        }
        public async Task<ResponseDto> GetAllDataAsync()
        {
            var response = await client.GetAsync($"api/home");
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var data = JsonSerializer.Deserialize<ResponseDto>(content, options);
            return data;
        }
    }
}
