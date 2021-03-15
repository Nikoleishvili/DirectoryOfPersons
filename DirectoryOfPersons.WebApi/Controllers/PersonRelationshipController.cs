using DirectoryOfPersons.Application.Features.Commands.PersonRelationships;
using DirectoryOfPersons.Application.Features.Queries.PersonRelationships;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryOfPersons.WebApi.Controllers
{
    public class PersonRelationshipController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreatePersonRelationshipCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePersonRelationshipDetails([FromBody] UpdatePersonRelationshipCommand item)
        {
            var response = await Mediator.Send(item);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePersonRelationship(int id)
        {
            var response = await Mediator.Send(new DeletePersonRelationshipCommand() { Id = id });
            return Ok(response);
        }

        [HttpGet("Report")]
        public async Task<IActionResult> GetPersonRelationships(int pageNumber, int pageSize)
        {
            var response = await Mediator.Send(new GetPersonRelationshipsQuery { PageNumber = pageNumber, PageSize = pageSize });
            return Ok(response);
        }
    }
}
