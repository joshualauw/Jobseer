namespace Jobseer.Domain.Models
{
    public class JobStatus : BaseEntity
    {
        public Guid ApplicationUserId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
