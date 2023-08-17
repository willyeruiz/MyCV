using System.Reflection.Metadata;
using ErrorOr;
using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;
using MediatR;


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
        IReadOnlyList<Skill?> listSkills = await _SkillRepository.GetAllAsync();

        return listSkills.Select(e => new SkillResponse(
                e.Id.value,
                e.Name,
                e.Level,
                e.Type,
                e.Percentage
          )).ToList();
    }

}