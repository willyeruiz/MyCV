
using ErrorOr;
using MediatR;
using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Entities;
using MyCV.Domain.Identificators;
using MyCV.Domain.Repositories;

namespace MyCV.Application.Skills.Create
{
    internal sealed class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, ErrorOr<Unit>>
    {
        private readonly ISkillRepository _SkillRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSkillCommandHandler(ISkillRepository SkillRepository, IUnitOfWork unitOfWork)
        {
            _SkillRepository = SkillRepository ?? throw new System.ArgumentNullException(nameof(SkillRepository));
            _unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newSkill =  new Skill( 
                                new SkillId(Guid.NewGuid()), 
                                request.name, 
                                request.level, 
                                request.type, 
                                request.percentage
                            );
           
                await _SkillRepository.AddAsync(newSkill);     
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (System.Exception)
            {
                 return Error.Failure("Error while creating new Skill");
            }  
        }
    }
}