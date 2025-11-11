using Jobseer.Application.Common;

namespace Jobseer.Application.Helpers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T? Data { get; set; }

        public ServiceResponse(bool success, T? data, string message = "", List<string>? errors = null)
            : base(success, message, errors)
        {
            Data = data;
        }

        public static ServiceResponse<T> Success(T data, string message = "Operation successful")
        {
            return new ServiceResponse<T>(true, data, message);
        }

        public static ServiceResponse<T> Failed(string message, List<string>? errors = null)
        {
            return new ServiceResponse<T>(false, default, message, errors);
        }
    }
}
