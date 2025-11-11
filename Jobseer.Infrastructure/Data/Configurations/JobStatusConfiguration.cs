using Jobseer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobseer.Infrastructure.Data.Configurations
{
    internal class JobStatusConfiguration : IEntityTypeConfiguration<JobStatus>
    {
        public void Configure(EntityTypeBuilder<JobStatus> builder)
        {
            builder.HasKey(js => js.Id);

            builder.Property(js => js.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(js => js.JobApplications)
                .WithOne(ja => ja.JobStatus)
                .HasForeignKey(ja => ja.JobStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
