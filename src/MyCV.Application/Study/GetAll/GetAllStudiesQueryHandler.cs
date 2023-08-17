using System.Reflection.Metadata;
using ErrorOr;
using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;
using MediatR;




namespace MyCV.Application.Studies.GetAll;
public sealed class GetAllStudiesQueryHandler: IRequestHandler<GetAllStudiesQuery, ErrorOr<IReadOnlyList<StudyResponse>>>
{
    private readonly IStudyRepository _studyRepository;

    public GetAllStudiesQueryHandler(IStudyRepository studyRepository)
    {
        _studyRepository = studyRepository;
    }
    public async Task<ErrorOr<IReadOnlyList<StudyResponse>>> Handle(GetAllStudiesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Study?> listStudies = await _studyRepository.GetAllAsync();

        return listStudies.Select(e => new StudyResponse(
            e.Id.value,
            e.Name,
            e.Country,
            e.City,
            e.Campus
            )).ToList();
    }

}