using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;
using MediatR;
using ErrorOr;
using MyCV.Domain.Entities.DomainErrors;

namespace MyCV.Application.Profiles.GetAll;
public sealed class GetAllProfilesQueryHandler: IRequestHandler<GetAllProfilesQuery, ErrorOr<IReadOnlyList<ProfileResponse>>>
{
    private readonly IProfileRepository _ProfileRepository;

    public GetAllProfilesQueryHandler(IProfileRepository profileRepository)
    {
        _ProfileRepository = profileRepository;
    }
    public async Task<ErrorOr<IReadOnlyList<ProfileResponse>>> Handle(GetAllProfilesQuery query, CancellationToken cancellationToken)
    {

        try
        {
            IReadOnlyList<Profile?> listProfiles = await _ProfileRepository.GetAllAsync();

            if (listProfiles is null || listProfiles?.Count == 0){
            return Errors.Profile.NothingToReturn;
            }

            return listProfiles.Select(e => new ProfileResponse(
                    e.Id.value,
                    e.Picture ,
                    e.Description,
                    e.Title,
                    e.Email,
                    e.Phone,
                    e.Address,
                    e.City
            )).ToList();
        }
        catch (Exception e)
        {
           return Error.Failure($"Error while tried to search the information, Details: {e.Message}");
        }
    }

}