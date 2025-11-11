namespace Jobseer.Domain.Models
{
    public class JobActivity : BaseEntity
    {
        public Guid JobApplicationId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public JobApplication JobApplication { get; set; } = null!;
    }
}
