using System.Net;
using System.Threading.Tasks;
using BB360TestBrief.Core.Commands.Register;
using BB360TestBrief.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BB360TestBrief.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class RecruitmentController : ControllerBase
   {
      private IMediator _mediator;
      private IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

		/// <summary>
      /// Submit a new job application
      /// </summary>
      /// <param name="command"></param>
      /// <returns>A created job application object</returns>
      /// <response code="201">Job application created successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.Created)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpPost("Apply")]
		public async Task<IActionResult> Register([FromBody] RegisterCommand command)
      {
         var response = await Mediator.Send(command);
         if (!response.Status)
            return BadRequest(response);

         return Created("", response);
      }
   }
}