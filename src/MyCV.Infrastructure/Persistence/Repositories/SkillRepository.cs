using MyCV.Domain.Entities;
using MyCV.Domain.Identificators;
using MyCV.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyCV.Infrastructure.Persistence.Repositories
{
    public class SkillRepository: ISkillRepository
    {
        private readonly ApplicationDBContext _context;
      
        public SkillRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }   
       
        
        public async Task<List<Skill>?> GetAllAsync() => await _context.Skills.ToListAsync();

        public async Task<Skill?> GetByIdAsync(SkillId id) => await _context.Skills.SingleOrDefaultAsync(s => s.Id == id);

        public async Task AddAsync(Skill skill) => await _context.Skills.AddAsync(skill);

         public Task<bool> DeleteAsync(Skill experience)
         {
            throw new NotImplementedException();
        }


        public Task<Skill> UpdateAsync(Skill experience)
        {
            throw new NotImplementedException();
        }
    }
}