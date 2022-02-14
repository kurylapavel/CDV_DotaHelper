using Business.Parser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Service.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly DbContext Context;
        private readonly IParserService _parserService;

        public TestController(DbContext context, IParserService parserService)
        {
            Context = context;
            _parserService = parserService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTest()
        {
            var result = await _parserService.Parse();

            return Ok(result);
        }
    }
}
