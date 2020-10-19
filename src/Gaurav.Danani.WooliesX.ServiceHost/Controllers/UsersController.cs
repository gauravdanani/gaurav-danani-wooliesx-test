using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Users.Queries.GetUserDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gaurav.Danani.WooliesX.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetailModel>> Get()
        {
            return Ok(await _mediator.Send(new GetUserDetailQuery()));
        }
    }
}