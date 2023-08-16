
using ErrorOr;
using MediatR;

namespace MyCV.Application.Experiences.GetAll;


    public record GetAllExperiencesQuery() : IRequest<ErrorOr<IReadOnlyList<ExperienceResponse>>>;

