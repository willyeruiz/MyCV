using MediatR;

namespace MyCV.Application.Skills.Create
{
    public record CreateSkillCommand(
      string name, 
      string level, 
      string type, 
      int percentage
    ) : IRequest<Unit>;
  
}