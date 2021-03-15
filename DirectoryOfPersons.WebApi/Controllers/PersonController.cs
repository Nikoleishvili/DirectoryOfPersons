using DirectoryOfPersons.Application.Features.Commands.Persons;
using DirectoryOfPersons.Application.Features.Queries.Persons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryOfPersons.WebApi.Controllers
{
    public class PersonController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreatePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePersonDetails([FromBody] UpdatePersonCommand item)
        {
            var response = await Mediator.Send(item);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var response = await Mediator.Send(new DeletePersonCommand() { Id = id });
            return Ok(response);
        }

        [HttpPost("All")]
        public async Task<IActionResult> GetPersons(GetPersonsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var response = await Mediator.Send(new GetPersonQuery { Id = id });
            return Ok(response);
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadPhoto(int personId, IFormFile file)
        {
            var response = await Mediator.Send(new UploadPhotoCommand { PersonId = personId, File = file });
            return Ok(response);
        }
    }
}
