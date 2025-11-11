namespace Jobseer.Domain.Models
{
    public class JobNote : BaseEntity
    {
        public Guid JobApplicationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public JobApplication JobApplication { get; set; } = null!;
    }
}
