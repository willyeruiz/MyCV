
using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyCV.Domain.Repositories;

namespace MyCV.Infrastructure.Persistence.Repositories
{
    public class ExperienceJson : IExperienceRepository
    {
         private readonly ApplicationJsonRepository<Experience> JsonRepo = new ApplicationJsonRepository<Experience> ("../MyCV.Infrastructure/Data/Experiences.json");
      
        public ExperienceJson()
        {
            
        }   
       
        
        public async Task<IEnumerable<Experience>?> GetAllAsync() => await JsonRepo.ReadJsonFile<Experience>();

        public async Task<Experience?> GetByIdAsync(ExperienceId id) {
            var experiences = await JsonRepo.ReadJsonFile<Experience>();
            return experiences.SingleOrDefault(s => s.Id == id);
        }

        public async Task AddAsync(Experience experience) => await JsonRepo.WriteJsonFile<Experience>(experience);
    }
}