using System.Reflection.Metadata;
using ErrorOr;
using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;
using MediatR;
using MyCV.Domain.Entities.DomainErrors;




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
        try
        {

            IReadOnlyList<Study?> listStudies = await _studyRepository.GetAllAsync();

            if (listStudies is null || listStudies?.Count == 0){
                return Errors.Study.NothingToReturn;
            }

            return listStudies.Select(e => new StudyResponse(
                e.Id.value,
                e.Name,
                e.Country,
                e.City,
                e.Campus
                )).ToList();
        }
        catch (Exception e)
        {
           return Error.Failure($"Error while tried to search the information, Details: {e.Message}");
        }
    }

}