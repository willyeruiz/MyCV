
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCV.Application.Skills.Create;
using MyCV.Application.Skills.GetAll;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : ApiController
    {
        private readonly ISender _mediator;

        public SkillsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateSkillCommand command)
        // {
        //     var newSkill = await _mediator.Send(command);
        //         return newSkill.Match(
        //         success => Ok(),
        //         errors => Problem(errors)
        //     );
        // }

        [HttpGet]
        public async Task<IActionResult> GetAll(){

              var listSkillResult = await _mediator.Send(new GetAllSkillsQuery());

              return listSkillResult.Match(
                exp  => Ok(exp),
                errors => Problem(errors)
              );
        }
    }
}