using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBeholder.Business.Interfaces;

namespace TheBeholder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IDetailRepository _detailRepository;

        public TicketController(IDetailRepository detailRepository) => this._detailRepository = detailRepository;

         [HttpGet("{ticket}")]
         public async Task<ActionResult> Get(string ticket)        
        {        
            var detail = await _detailRepository.GetByTicketAsync(ticket);

            return Ok(detail);

        }

    }
}