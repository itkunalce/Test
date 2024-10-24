using Microsoft.AspNetCore.Mvc;
using Test.Service.Contracts.Manager;
using Test.Shared.Dto.Api;
using Test.Shared.Dto;
using Microsoft.AspNetCore.Http.Features.Authentication;


namespace Test.PresentationApi.Controllers
{
    [Route("api/Nytimes")]
    [ApiController]
    public class NytimesController(IServiceManager service) : ControllerBase
    {

        [HttpGet(Name = "TopHomeStories")]
        public async Task<ResponseDto> TopHomeStories([FromQuery] string key)
        {

            var response = new ResponseDto();

            if (string.IsNullOrEmpty(key))
            {
                response.IsSuccess = false;
                response.Message = "Key is blank";
                return response;
            }

            try
            {
                //Fatch NyTimesTopHomeStories
                var NytResult = await service.NYTimesService.FatchNYTimesHomeTopStories(key);
                //sresponse.Result = NytResult;

                //Insert Data In DataBase For Each Articale
                if (NytResult is not null)
                {
                    response.IsSuccess = NytResult.isSuccess;
                    response.Message = NytResult.message;
                    int Inserted = 0;
                    //Insert Data In DataBase For Each Articale
                    if (response.IsSuccess)
                    {
                        foreach (var item in NytResult.results)
                        {
                            if (await service.ArticleService.InsertArticleAsync(item))
                            {
                                Inserted++;
                            }
                        }
                        response.Message = $"Record fatch. Total record {Inserted}";
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }

}
