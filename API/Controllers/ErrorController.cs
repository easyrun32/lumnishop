using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //Overwrite the route
    [Route("errors/{code}")]
    //for swagger
    [ApiExplorerSettings(IgnoreApi = true)]
    //To fix /api/RandomRoute 
    public class ErrorController : BaseApiController
    {
        //swagger doesn't know what type of request here
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }

    }
}