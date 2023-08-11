using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;

namespace MyCV.Domain.Repositories
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>?> GetAllAsync();
        
        Task<Experience?> GetByIdAsync(ExperienceId id);
        
        Task AddAsync(Experience experience);

        // Task<Experience> UpdateAsync(Experience experience);

        // Task<bool> DeleteAsync(Experience experience);
    }
};


