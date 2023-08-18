using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;

namespace MyCV.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<List<Profile>?> GetAllAsync();

        Task<Profile?> GetByIdAsync(ProfileId id);
        
        Task AddAsync(Profile profile);

        Task<Profile> UpdateAsync(Profile profile);

         Task<bool> DeleteAsync(Profile profile);
    }
}

