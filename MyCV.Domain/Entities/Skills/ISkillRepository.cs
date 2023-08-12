using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;

namespace MyCV.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>?> GetAllAsync();

        Task<Skill?> GetByIdAsync(SkillId id);
        
        Task AddAsync(Skill skill);

        // Task<Skill> UpdateAsync(Skill skill);

        // Task<bool> DeleteAsync(Skill skill);
    }
}

