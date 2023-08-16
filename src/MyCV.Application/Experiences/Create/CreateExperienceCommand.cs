using ErrorOr;
using MediatR;

namespace MyCV.Application.Experiences.Create
{
    public record CreateExperienceCommand(
       string Company, 
       string From, 
       string To, 
       string Position, 
       string Description
    ) : IRequest<ErrorOr<Guid>>;
  
}