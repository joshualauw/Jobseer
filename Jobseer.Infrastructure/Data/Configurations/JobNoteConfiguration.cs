using Jobseer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobseer.Infrastructure.Data.Configurations
{
    public class JobNoteConfiguration : IEntityTypeConfiguration<JobNote>
    {
        public void Configure(EntityTypeBuilder<JobNote> builder)
        {
            builder.HasKey(jn => jn.Id);

            builder.Property(jn => jn.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(jn => jn.Content)
                .IsRequired();

            builder.HasOne(jn => jn.JobApplication)
                .WithMany(ja => ja.JobNotes)
                .HasForeignKey(jn => jn.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
