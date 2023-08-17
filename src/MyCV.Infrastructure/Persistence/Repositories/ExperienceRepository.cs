
using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyCV.Domain.Repositories;

namespace MyCV.Infrastructure.Persistence.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDBContext _context;

        public ExperienceRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Experience experience) => await _context.Experiences.AddAsync(experience);

        public async Task<List<Experience>?> GetAllAsync() => await _context.Experiences.ToListAsync();

        public  async Task<Experience?> GetByIdAsync(ExperienceId id) =>  await _context.Experiences.SingleOrDefaultAsync(e => e.Id == id);

         public Task<bool> DeleteAsync(Experience experience)
         {
            throw new NotImplementedException();
        }


        public Task<Experience> UpdateAsync(Experience experience)
        {
            throw new NotImplementedException();
        }
    }
}