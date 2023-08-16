
using MediatR;
using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Identificators;
using MyCV.Domain.Repositories;
using MyCV.Domain.Entities;
using ErrorOr;

namespace MyCV.Application.Experiences.Create;

    internal sealed class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, ErrorOr<Unit>>
    {
        private readonly IExperienceRepository _ExperienceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExperienceCommandHandler(IExperienceRepository ExperienceRepository, IUnitOfWork unitOfWork)
        {
            _ExperienceRepository = ExperienceRepository ?? throw new System.ArgumentNullException(nameof(ExperienceRepository));
            _unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newExperience = new Experience(new ExperienceId(Guid.NewGuid()),
                                              request.Company,
                                              request.From,
                                              request.To,
                                              request.Position,
                                              request.Description);

                await _ExperienceRepository.AddAsync(newExperience);     
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return newExperience.Id.Value;
            }
            catch (Exception e)
            {
               return Error.Failure("Error while creating new Experience");
            }
       
        }

  
}
