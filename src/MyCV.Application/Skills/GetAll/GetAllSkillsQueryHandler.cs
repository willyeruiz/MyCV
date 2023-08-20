using System.Reflection.Metadata;
using ErrorOr;
using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;
using MediatR;
using MyCV.Domain.Entities.DomainErrors;


namespace MyCV.Application.Skills.GetAll;
public sealed class GetAllSkillsQueryHandler: IRequestHandler<GetAllSkillsQuery, ErrorOr<IReadOnlyList<SkillResponse>>>
{
    private readonly ISkillRepository _SkillRepository;

    public GetAllSkillsQueryHandler(ISkillRepository SkillRepository)
    {
        _SkillRepository = SkillRepository;
    }
    public async Task<ErrorOr<IReadOnlyList<SkillResponse>>> Handle(GetAllSkillsQuery query, CancellationToken cancellationToken)
    {

        try
        {
            IReadOnlyList<Skill?> listSkills = await _SkillRepository.GetAllAsync();

            if (listSkills is null){
            return Errors.Skill.NothingToReturn;
            }

            return listSkills.Select(e => new SkillResponse(
                    e.Id.value,
                    e.Name,
                    e.Level,
                    e.Type,
                    e.Percentage
            )).ToList();

        }
        catch (Exception e)
        {
           return Error.Failure($"Error while tried to search the information, Details: {e.Message}");
        }
    }

}