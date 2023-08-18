
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCV.Application.Profiles.GetAll;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : ApiController
    {
        private readonly ISender _mediator;

        public ProfilesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(){

              var listExperienceResult = await _mediator.Send(new GetAllProfilesQuery());

              return listExperienceResult.Match(
                exp  => Ok(exp),
                errors => Problem(errors)
              );
        }
    }
}