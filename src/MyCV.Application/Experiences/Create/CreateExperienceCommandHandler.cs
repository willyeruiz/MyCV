
using MediatR;
using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Identificators;
using MyCV.Domain.Repositories;
using MyCV.Domain.Entities;
using ErrorOr;
using MyCV.Domain.Entities.DomainErrors;

namespace MyCV.Application.Experiences.Create;

    public sealed class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, ErrorOr<Guid>>
    {
        private readonly IExperienceRepository _ExperienceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExperienceCommandHandler(IExperienceRepository ExperienceRepository, IUnitOfWork unitOfWork)
        {
            _ExperienceRepository = ExperienceRepository ?? throw new System.ArgumentNullException(nameof(ExperienceRepository));
            _unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Description.Length < 3)
                    return Errors.Experience.ShortDescriptionValidation;

                if (request.Description.Length > 500)
                    return Errors.Experience.LongDescriptionValidation;

                var newExperience = new Experience(
                                            new ExperienceId(Guid.NewGuid()),
                                            request.Company,
                                            request.From,
                                            request.To,
                                            request.Position,
                                            request.Description);

                await _ExperienceRepository.AddAsync(newExperience);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return newExperience.Id.value;
            }
            catch (Exception e)
            {
               return Error.Failure($"Error while creating new Experience, Details: {e.Message}");
            }
        }
}
