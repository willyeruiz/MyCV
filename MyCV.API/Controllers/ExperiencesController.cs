using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCV.Application.Experiences.Create;

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
        
        
    }
}