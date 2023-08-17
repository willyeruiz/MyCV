
using ErrorOr;
using MediatR;

namespace MyCV.Application.Studies.GetAll;

    public record GetAllStudiesQuery() : IRequest<ErrorOr<IReadOnlyList<StudyResponse>>>;

