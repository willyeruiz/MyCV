
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCV.Application.Experiences.Create;
using MyCV.Application.Experiences.GetAll;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    public class ExperiencesController : ApiController
    {
        private readonly ISender _mediator;

        public ExperiencesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExperienceCommand command)
        {
            var newExperience = await _mediator.Send(command);
                return newExperience.Match(
                success => Ok(),
                errors => Problem(errors)
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){

              var listExperienceResult = await _mediator.Send(new GetAllExperiencesQuery());

              return listExperienceResult.Match(
                exp  => Ok(exp),
                errors => Problem(errors)
              );
        }
    }
}