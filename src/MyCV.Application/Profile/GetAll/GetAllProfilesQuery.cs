using ErrorOr;
using MediatR;

namespace MyCV.Application.Profiles.GetAll;


public record GetAllProfilesQuery() : IRequest<ErrorOr<IReadOnlyList<ProfileResponse>>>;

