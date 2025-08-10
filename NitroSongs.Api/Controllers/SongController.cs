using Cortex.Mediator;
using Cortex.Mediator.Queries;
using Microsoft.AspNetCore.Mvc;
using NitroSongs.ApplicationLayer.UseCases.Queries;
using NitroSongs.Common.Common;
using NitroSongs.Common.Dtos;

namespace NitroSongs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SongController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<SongDto>>> GetAll(int page = 1, int size = 10)
        {
            var query = new GetPagedQuery<SongDto>(page, size);

            var result = await _mediator.SendQueryAsync<GetPagedQuery<SongDto>, ServiceResponse<PagedResult<SongDto>>>(query);

            return Ok(result.Data);
        }
    }
}
