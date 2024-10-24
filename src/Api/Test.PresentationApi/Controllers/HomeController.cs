using Microsoft.AspNetCore.Mvc;
using Test.Service.Contracts.Manager;
using Test.Shared.Dto.Api;


namespace Test.PresentationApi.Controllers
{
    [Route("api/Home")]
    [ApiController]
    public class HomeController(IServiceManager service) : ControllerBase
    {
        [HttpGet]
        public async Task<ResponseDto> GetHomeData()
        {
            var response = new ResponseDto();

            try
            {
                response.Result = await service.ArticleService.GetAllDetailAsync(trackChanges: false);
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
