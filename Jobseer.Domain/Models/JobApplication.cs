namespace Jobseer.Domain.Models
{
    public class JobApplication : BaseEntity
    {
        public Guid ApplicationUserId { get; set; }
        public Guid JobStatusId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Url { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string? CompanyDescription { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyWebsite { get; set; }

        public JobStatus JobStatus { get; set; } = null!;
        public ICollection<JobNote> JobNotes { get; set; } = null!;
        public ICollection<JobDocument> JobDocuments { get; set; } = null!;
        public ICollection<JobActivity> JobActivities { get; set; } = null!;
    }
}
