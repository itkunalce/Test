using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Test.Service.Contracts.Nytimes;
using Test.Shared.Dto.NYTimes;

namespace Test.Service.NYTimes;

public class NYTimesService : INYTimesService
{
    public NYTimesService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("NyTimesApiClient");
    }
    private readonly HttpClient _httpClient;

    public async Task<NYTResponse> FatchNYTimesHomeTopStories(string Key)
    {
        // Assuming a third-party API endpoint URL
        string requestUrl = $"https://api.nytimes.com/svc/topstories/v2/home.json?api-key={Key}";

        HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
        NYTResponse NytData = new();
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            NytData = JsonSerializer.Deserialize<NYTResponse>(content, options);
            NytData.isSuccess = true;
        }
        else
        {

            NytData.isSuccess = false;
            NytData.message = response.StatusCode.ToString();
        }
        return NytData;
    }
}
 
