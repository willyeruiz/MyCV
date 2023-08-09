using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;

namespace MyCV.Domain.Repositories
{
    public interface IExperienceRepository
    {
        Task<Experience> GetAllAsync(ExperienceId id);

        Task<Experience> GetByIdAsync(ExperienceId id);
        
        Task<Experience> AddAsync(Experience experience);

        Task<Experience> UpdateAsync(Experience experience);

        Task<bool> DeleteAsync(Experience experience);
    }
};


