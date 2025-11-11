using Jobseer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobseer.Infrastructure.Data.Configurations
{
    public class JobActivityConfiguration : IEntityTypeConfiguration<JobActivity>
    {
        public void Configure(EntityTypeBuilder<JobActivity> builder)
        {
            builder.HasKey(ja => ja.Id);

            builder.Property(ja => ja.Type)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ja => ja.Content)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(ja => ja.JobApplication)
                .WithMany(j => j.JobActivities)
                .HasForeignKey(ja => ja.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
