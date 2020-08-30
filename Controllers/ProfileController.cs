using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BB360TestBrief.Core.Commands.AcademicQualifications;
using BB360TestBrief.Core.Commands.ProfessionalExperience;
using BB360TestBrief.Core.Commands.Profile;
using BB360TestBrief.Core.Queries.Profile;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BB360TestBrief.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   [Authorize(AuthenticationSchemes = "JwtBearer")]
   public class ProfileController : ControllerBase
   {
      private IMediator _mediator;
      private IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

      /// <summary>
      /// Fetchs customers profile information
      /// </summary>
      /// <returns>A user profile information object</returns>
      /// <response code="200">Profile information object retrieved successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<ProfileDTO>), (int)HttpStatusCode.OK)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpGet]
      public async Task<IActionResult> Get()
      {
         var query = new GetUserProfileQuery
         {
				UserId = User.Identity.GetProfileId(),
				BaseUrl = $"{this.Request.Scheme}://{this.Request.Host}"
         };
         var response = await Mediator.Send(query);
         if (!response.Status)
            return BadRequest(response);

         return Ok(response);
      }

		/// <summary>
      /// Adds or Updates user profile information
      /// </summary>
		/// <param name="command"></param>
      /// <returns>A user profile information object</returns>
      /// <response code="201">Profile information object retrieved successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<ProfileDTO>), (int)HttpStatusCode.Created)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpPost]
      public async Task<IActionResult> Post([FromBody]PostProfileCommand command)
      {
			command.UserId = User.Identity.GetProfileId();
         var response = await Mediator.Send(command);
         if (!response.Status)
            return BadRequest(response);

         return Created("", response);
      }

		/// <summary>
      /// Posts user academic qualifications
      /// </summary>
		/// <param name="command"></param>
      /// <returns>A user academic qualifcation object</returns>
      /// <response code="201">User academic qualification object retrieved successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<List<AcademicQualificatonDTO>>), (int)HttpStatusCode.Created)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpPost("AcademicQualifications")]
      public async Task<IActionResult> Post([FromBody]PostAcademicQualificationsCommand command)
      {
			command.UserId = User.Identity.GetProfileId();
         var response = await Mediator.Send(command);
         if (!response.Status)
            return BadRequest(response);

         return Created("", response);
      }

		/// <summary>
      /// Posts user professional experience
      /// </summary>
		/// <param name="command"></param>
      /// <returns>A user professional experience object</returns>
      /// <response code="201">User professional experience object retrieved successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<List<ProfessionalExperienceDTO>>), (int)HttpStatusCode.Created)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpPost("ProfessionalExperience")]
      public async Task<IActionResult> Post([FromBody]PostProfessionalExperienceCommand command)
      {
			command.UserId = User.Identity.GetProfileId();
         var response = await Mediator.Send(command);
         if (!response.Status)
            return BadRequest(response);

         return Created("", response);
      }
   }
}