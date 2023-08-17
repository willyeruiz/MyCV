
using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;

using MyCV.Domain.Repositories;

namespace MyCV.Infrastructure.Persistence.Repositories
{
    public class ExperienceJson : IExperienceRepository
    {
         private readonly ApplicationJsonRepository<Experience> JsonRepo ;

        public ExperienceJson()
        {
           JsonRepo = new ApplicationJsonRepository<Experience> ("../MyCV.Infrastructure/Data/Experiences.json");
        }

        public async Task<List<Experience>?> GetAllAsync() =>  await JsonRepo.ReadJsonFile();

        public async Task<Experience?> GetByIdAsync(ExperienceId id) {
            var experiences = await JsonRepo.ReadJsonFile();
            return experiences.SingleOrDefault(s => s.Id == id);
        }

        public async Task AddAsync(Experience experience) => await JsonRepo.WriteJsonFile(experience);

        public Task<Experience> UpdateAsync(Experience experience)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Experience experience)
        {
            throw new NotImplementedException();
        }
    }
}