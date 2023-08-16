using System.Reflection.Metadata;
using ErrorOr;
using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;
using MediatR;


namespace MyCV.Application.Experiences.GetAll;
public sealed class GetAllExperiencesQueryHandler: IRequestHandler<GetAllExperiencesQuery, ErrorOr<IReadOnlyList<ExperienceResponse>>>
{
    private readonly IExperienceRepository _experienceRepository;

    public GetAllExperiencesQueryHandler(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }
    public async Task<ErrorOr<IReadOnlyList<ExperienceResponse>>> Handle(GetAllExperiencesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Experience?> listExperiences = await _experienceRepository.GetAllAsync();

        return listExperiences.Select(e => new ExperienceResponse(
            e.Id.value,
            e.Company,
            e.From,
            e.To,
            e.Position,
            e.Description)).ToList();
    }

}