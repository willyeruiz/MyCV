using MyCV.Domain.Identificators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCV.Domain.Entities;

namespace MyCV.Infrastructure.Persistence.Configuration
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable ("Experiences");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasConversion(
                ExperienceId => ExperienceId.value,value => new ExperienceId(value)
            );
            builder.Property(e => e.Company).HasMaxLength(100).IsRequired();
            builder.Property(e => e.From).HasMaxLength(100).IsRequired();
            builder.Property(e => e.To).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Position).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(1000).IsRequired();

        }
    }
}