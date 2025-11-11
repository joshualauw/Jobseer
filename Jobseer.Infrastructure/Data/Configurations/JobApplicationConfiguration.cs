using Jobseer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobseer.Infrastructure.Data.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasKey(ja => ja.Id);
            
            builder.Property(ja => ja.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ja => ja.Description)
                .IsRequired();

            builder.Property(ja => ja.CompanyName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(ja => ja.Url)
                .HasMaxLength(500);

            builder.Property(ja => ja.CompanyDescription)
                .HasMaxLength(1000);

            builder.Property(ja => ja.CompanyAddress)
                .HasMaxLength(300);

            builder.Property(ja => ja.CompanyWebsite)
                .HasMaxLength(200);

            builder.HasOne(ja => ja.JobStatus)
                .WithMany(js => js.JobApplications)
                .HasForeignKey(ja => ja.JobStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ja => ja.JobNotes)
                .WithOne(jn => jn.JobApplication)
                .HasForeignKey(jn => jn.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ja => ja.JobDocuments)
                .WithOne(jd => jd.JobApplication)
                .HasForeignKey(jd => jd.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ja => ja.JobActivities)
                .WithOne(ja => ja.JobApplication)
                .HasForeignKey(ja => ja.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
