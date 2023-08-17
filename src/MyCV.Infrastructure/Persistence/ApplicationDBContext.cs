using Microsoft.EntityFrameworkCore;
using MyCV.Application.Data;
using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Entities;
using MediatR;

namespace MyCV.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        public DbSet<Experience> Experiences { get ; set; }
        public DbSet<Skill> Skills { get ; set; }
        public DbSet<Study> Studies { get ; set; }

        public ApplicationDBContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new System.ArgumentNullException(nameof(publisher));

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(x => x.Entity)
                .Where(x => x.DomainEvents.Any())
                .SelectMany(e => e.DomainEvents);

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

    }
}