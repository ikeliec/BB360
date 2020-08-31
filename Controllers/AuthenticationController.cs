using System.Net;
using System.Threading.Tasks;
using BB360TestBrief.Core.Commands.Login;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Jwt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BB360TestBrief.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AuthenticationController : ControllerBase
   {
      private IMediator _mediator;
      private IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

		/// <summary>
      /// Authenticates a successful candidate
      /// </summary>
      /// <param name="command"></param>
      /// <returns>A authenticated user object including jwt token</returns>
      /// <response code="200">authenticated user object including jwt token is returnedy</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<JsonWebToken>), (int)HttpStatusCode.OK)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpPost("Login")]
		public async Task<IActionResult> ZimvestSavings([FromBody] LoginCommand command)
      {
         var response = await Mediator.Send(command);
         if (!response.Status)
            return BadRequest(response);

         return Ok(response);
      }
   }
}