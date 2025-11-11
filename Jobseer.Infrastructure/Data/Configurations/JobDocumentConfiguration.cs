using Jobseer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobseer.Infrastructure.Data.Configurations
{
    public class JobDocumentConfiguration : IEntityTypeConfiguration<JobDocument>
    {
        public void Configure(EntityTypeBuilder<JobDocument> builder)
        {
            builder.HasKey(jd => jd.Id);

            builder.Property(jd => jd.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(jd => jd.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(jd => jd.JobApplication)
                .WithMany(ja => ja.JobDocuments)
                .HasForeignKey(jd => jd.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
