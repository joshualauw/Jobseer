namespace Jobseer.Application.Common
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
        public T? Data { get; set; }

        protected BaseResponse(bool success, string message, T? data = default, List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Data = data;

            if (errors != null)
            {
                Errors = errors;
            }
        }

        public static BaseResponse<T> SuccessResponse(T data, string message = "Operation successful")
            => new BaseResponse<T>(true, message, data);

        public static BaseResponse<T> FailResponse(string message, List<string>? errors = null)
            => new BaseResponse<T>(false, message, default, errors);
    }
}
