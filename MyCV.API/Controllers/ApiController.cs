
using ErrorOr;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCV.API.Common.Http;

namespace MyCV.API.Controllers
{
    [ApiController]
    public class ApiController: ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if(errors.Count is 0){
                return Problem();
            }

            if(errors.All(error => error.Type == ErrorType.Validation)){
                return ValidationProblem(errors);
            }

            HttpContext.Items[HttpContextItemKeys.Error] = errors;
            return Problem(errors[0]);
        }
    

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation  => StatusCodes.Status400BadRequest,
                ErrorType.NotFound  => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult  ValidationProblem(List<Error> errors)
        {
            var mdoelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                mdoelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem(mdoelStateDictionary);
        }   
    }
}