
using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Experience>?> GetAllAsync() {
            var JsonExperience = new ApplicationJsonRepository<Experience>("../MyCV.Infrastructure/Data/Experiences.json");
            var temp = await JsonExperience.ReadJsonFile();
            return await JsonRepo.ReadJsonFile();
        }

        public async Task<Experience?> GetByIdAsync(ExperienceId id) {
            var experiences = await JsonRepo.ReadJsonFile();
            return experiences.SingleOrDefault(s => s.Id == id);
        }

        public async Task AddAsync(Experience experience) => await JsonRepo.WriteJsonFile(experience);
    }
}