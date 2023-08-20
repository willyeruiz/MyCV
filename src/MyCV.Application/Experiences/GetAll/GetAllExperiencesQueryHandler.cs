using System.Reflection.Metadata;
using ErrorOr;
using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;
using MediatR;
using MyCV.Domain.Entities.DomainErrors;

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
        try
        {
            IReadOnlyList<Experience?> listExperiences = await _experienceRepository.GetAllAsync();

            if (listExperiences is null || listExperiences?.Count == 0 ){
            return Errors.Experience.NothingToReturn;
            }

            return listExperiences.Select(e => new ExperienceResponse(
                e.Id.value,
                e.Company,
                e.From,
                e.To,
                e.Position,
                e.Description)).ToList();
        }
        catch (Exception e)
        {
           return Error.Failure($"Error while tried to search the information, Details: {e.Message}");
        }
    }

}