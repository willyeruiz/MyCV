using MyCV.Domain.Entities;
using MyCV.Domain.Identificators;
using MyCV.Domain.Repositories;

namespace MyCV.Infrastructure.Persistence.Repositories
{
    public class ProfileJson: IProfileRepository
    {
        private readonly ApplicationJsonRepository<Profile> JsonRepo ;
        public ProfileJson()
        {
           JsonRepo = new ApplicationJsonRepository<Profile>("../MyCV.Infrastructure/Data/Profiles.json");
        }
        public async Task<List<Profile>?> GetAllAsync() => await JsonRepo.ReadJsonFile();

       public async Task<Profile?> GetByIdAsync(ProfileId id) {
            var profiles = await JsonRepo.ReadJsonFile();
            return profiles.SingleOrDefault(s => s.Id == id);
        }

        public async Task AddAsync(Profile profile) => await JsonRepo.WriteJsonFile(profile);


        Task<Profile> IProfileRepository.UpdateAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProfileRepository.DeleteAsync(Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}