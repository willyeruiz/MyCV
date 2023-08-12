using MyCV.Domain.Entities;
using MyCV.Domain.Identificators;
using MyCV.Domain.Repositories;

namespace MyCV.Infrastructure.Persistence.Repositories
{
    public class SkillJson: ISkillRepository
    {
        private readonly ApplicationJsonRepository<Skill> JsonRepo = new ApplicationJsonRepository<Skill>(".../MyCV.Infrastructure/Data/Skills.json");
      
        public SkillJson()
        {
            
        }   
       
        
        public async Task<IEnumerable<Skill>?> GetAllAsync() => await JsonRepo.ReadJsonFile<Skill>();

        public async Task<Skill?> GetByIdAsync(SkillId id) {
            var skills = await JsonRepo.ReadJsonFile<Skill>();
            return skills.SingleOrDefault(s => s.Id == id);
        }

        public async Task AddAsync(Skill skill) => await JsonRepo.WriteJsonFile<Skill>(skill);
    }
}