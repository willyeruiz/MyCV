
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using MyCV.Application.Studies.Create;
using MyCV.Application.Studies.GetAll;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    public class StudiesController : ApiController
    {
        private readonly ISender _mediator;

        public StudiesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateStudyCommand command)
        // {
        //     var newStudy = await _mediator.Send(command);
        //         return newStudy.Match(
        //         success => Ok(),
        //         errors => Problem(errors)
        //     );
        // }

        [HttpGet]
        public async Task<IActionResult> GetAll(){

              var listStudyResult = await _mediator.Send(new GetAllStudiesQuery());

              return listStudyResult.Match(
                exp  => Ok(exp),
                errors => Problem(errors)
              );
        }
    }
}