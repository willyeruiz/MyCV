
using MediatR;
using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Entities;
using MyCV.Domain.Identificators;
using MyCV.Domain.Repositories;

namespace MyCV.Application.Skills.Create
{
    internal sealed class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Unit>
    {
        private readonly ISkillRepository _SkillRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSkillCommandHandler(ISkillRepository SkillRepository, IUnitOfWork unitOfWork)
        {
            _SkillRepository = SkillRepository ?? throw new System.ArgumentNullException(nameof(SkillRepository));
            _unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Unit> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
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
    }
}