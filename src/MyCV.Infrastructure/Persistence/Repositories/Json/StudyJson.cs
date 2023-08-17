
using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;
using MyCV.Domain.Repositories;

namespace MyCV.Infrastructure.Persistence.Repositories
{
    public class StudyJson : IStudyRepository
    {
         private readonly ApplicationJsonRepository<Study> JsonRepo ;

        public StudyJson()
        {
           JsonRepo = new ApplicationJsonRepository<Study> ("../MyCV.Infrastructure/Data/Studies.json");
        }

        public async Task<List<Study>?> GetAllAsync() =>  await JsonRepo.ReadJsonFile();

        public async Task<Study?> GetByIdAsync(StudyId id) {
            var experiences = await JsonRepo.ReadJsonFile();
            return experiences.SingleOrDefault(s => s.Id == id);
        }

        public async Task AddAsync(Study experience) => await JsonRepo.WriteJsonFile(experience);


        public Task<Study> UpdateAsync(Study study)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Study study)
        {
            throw new NotImplementedException();
        }

     
    }
}