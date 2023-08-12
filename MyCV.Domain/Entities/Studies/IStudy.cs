using MyCV.Domain.Identificators;
using MyCV.Domain.Entities;
namespace MyCV.Domain.Repositories;

public interface IStudy
{
    Task<Study> GetAllAsync(StudyId id);

    Task<Study> GetByIdAsync(StudyId id);
    
    Task<Study> AddAsync(Study study);

    Task<Study> UpdateAsync(Study study);

    Task<bool> DeleteAsync(Study study);
}
