using Microsoft.EntityFrameworkCore;
using MyCV.Domain.Entities;

namespace MyCV.Application.Data
{

    public interface IApplicationDBContext
    {
        DbSet<Experience> Experiences { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
       //DbSet<Skill> Skills { get; set; }

        //DbSet<Study> Studies { get; set; }



    }

}

