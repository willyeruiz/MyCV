
using System.Diagnostics;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCV.API.Common.Http;

namespace MyCV.API.Common.Errors
{
    public class MyCVProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;

        public MyCVProblemDetailsFactory(ApiBehaviorOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override ProblemDetails CreateProblemDetails( HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            statusCode ??= 500;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };
            
            ApplyProblemDetailsDafaults(httpContext, problemDetails, statusCode.Value); 
            
            return problemDetails;
        }
        

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            if(modelStateDictionary is null)
            {
                throw new ArgumentNullException(nameof(modelStateDictionary));
            }

            statusCode ??= 400; 

            var problemDetails = new ValidationProblemDetails(modelStateDictionary)
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            if(title != null){
                problemDetails.Title = title;
            }

            ApplyProblemDetailsDafaults(httpContext, problemDetails, statusCode.Value); 
            
            return problemDetails;
        }

        private void ApplyProblemDetailsDafaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;
            
            if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            
            if(traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            } 

            var errors = httpContext?.Items[HttpContextItemKeys.Error] as List<Error>;
            if(errors is null)
            {
                problemDetails.Extensions.Add("errorsCodes", errors.Select(e => e.Code));
            }
        }
    }
}