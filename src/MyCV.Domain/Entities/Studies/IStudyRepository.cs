using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;
namespace MyCV.Domain.Repositories;

public interface IStudyRepository
{
    Task<List<Study>?> GetAllAsync();

    Task<Study> GetByIdAsync(StudyId id);
    
    Task AddAsync(Study study);

    Task<Study> UpdateAsync(Study study);

    Task<bool> DeleteAsync(Study study);
}
