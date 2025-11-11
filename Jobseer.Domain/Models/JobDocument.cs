namespace Jobseer.Domain.Models
{
    public class JobDocument : BaseEntity
    {
        public Guid JobApplicationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public JobApplication JobApplication { get; set; } = null!;
    }
}
