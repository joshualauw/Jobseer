namespace Jobseer.Application.Common
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();

        protected BaseResponse(bool success, string message = "", List<string>? errors = null)
        {
            Success = success;
            Message = message;

            if (errors != null)
            {
                Errors = errors;
            }
        }
    }
}
