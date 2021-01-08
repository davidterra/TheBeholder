using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheBeholder.Business.Interfaces;

namespace TheBeholder.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoadController : ControllerBase
    {
        private readonly ILogger<LoadController> _logger;
        private readonly ISaveTicketsFromHtmlService _saveTicketsFromHtmlService;

        public LoadController(ILogger<LoadController> logger, ISaveTicketsFromHtmlService saveTicketsFromHtmlService )
        {
            _logger = logger;
            _saveTicketsFromHtmlService = saveTicketsFromHtmlService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _saveTicketsFromHtmlService.SaveAsync();

            return Ok();
        }

    }
}