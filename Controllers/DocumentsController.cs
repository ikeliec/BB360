using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BB360TestBrief.Core.Commands.Documents;
using BB360TestBrief.Core.Queries.Documents;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BB360TestBrief.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Authorize(AuthenticationSchemes = "JwtBearer")]
   public class DocumentsController : ControllerBase
   {
      private IMediator _mediator;
      private IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());


      /// <summary>
      /// Fetchs document templates for download
      /// </summary>
      /// <returns>A list of document templates object</returns>
      /// <response code="200">List of documents retrieved successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<List<DocumentTemplateDTO>>), (int)HttpStatusCode.OK)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpGet("Templates")]
      public async Task<IActionResult> GetDocumentTemplates()
      {
         var query = new GetDocumentTemplateQuery
         {
            BaseUrl = $"{this.Request.Scheme}://{this.Request.Host}"
         };
         var response = await Mediator.Send(query);
         if (!response.Status)
            return BadRequest(response);

         return Ok(response);
      }

      /// <summary>
      /// Uploads user document
      /// </summary>
		/// <param name="command"></param>
      /// <returns>A successful document upload message</returns>
      /// <response code="200">User document uploaded successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpPost("Customer")]
      public async Task<IActionResult> Post([FromForm] UploadDocumentCommand command)
      {
         command.UserId = User.Identity.GetProfileId();
         var response = await Mediator.Send(command);
         if (!response.Status)
            return BadRequest(response);

         return Created("", response);
      }

      /// <summary>
      /// Fetch user documents
      /// </summary>
      /// <returns>A successful user documents object</returns>
      /// <response code="200">User document retrieved successfully</response>
      /// <response code="400">If validation fails due to validation errors or application encountered an exception</response>
      [Produces("application/json")]
      [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
      [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
      [HttpGet("Customer")]
      public async Task<IActionResult> GetCustomerDocuments()
      {
         var query = new GetCustomerDocumentsQuery
         {
            UserId = User.Identity.GetProfileId(),
            BaseUrl = $"{this.Request.Scheme}://{this.Request.Host}"
         };
         var response = await Mediator.Send(query);
         if (!response.Status)
            return BadRequest(response);

         return Ok(response);
      }
   }
}