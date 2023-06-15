using Microsoft.AspNetCore.Mvc;
using tetris_api.Models;

namespace tetris_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ResultModel>> GetAllResults()
        {
            return Ok();
        }
    }
}