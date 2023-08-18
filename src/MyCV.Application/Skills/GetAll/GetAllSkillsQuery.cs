
using ErrorOr;
using MediatR;

namespace MyCV.Application.Skills.GetAll;


public record GetAllSkillsQuery() : IRequest<ErrorOr<IReadOnlyList<SkillResponse>>>;

