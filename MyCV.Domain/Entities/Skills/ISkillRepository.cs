using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;

namespace MyCV.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<Skill> GetAllAsync(SkillId id);

        Task<Skill> GetByIdAsync(SkillId id);
        
        Task<Skill> AddAsync(Skill skill);

        Task<Skill> UpdateAsync(Skill skill);

        Task<bool> DeleteAsync(Skill skill);
    }
}

