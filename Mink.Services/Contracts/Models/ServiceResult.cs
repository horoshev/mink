namespace Mink.Services.Contracts.Models
{
    public class ServiceResult
    {
        public static ServiceResult<T> Success<T>(T result, string message = "")
        {
            return new()
            {
                IsSuccess = true,
                Result = result,
                Message = message,
            };
        }

        public static ServiceResult<T> Fail<T>(string because = "")
        {
            return new()
            {
                IsSuccess = false,
                Message = because,
            };
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public bool IsSuccess { get; protected internal init; }
        public T? Result { get; protected internal init; }
        public string? Message { get; protected internal init; }

        protected internal ServiceResult()
        {
        }

        protected internal ServiceResult(bool isSuccess, T result, string message)
        {
            IsSuccess = isSuccess;
            Result = result;
            Message = message;
        }

        public static ServiceResult<T> Success(T result, string message = "")
        {
            return new()
            {
                IsSuccess = true,
                Result = result,
                Message = message,
            };
        }

        public static ServiceResult<T> Fail(string because = "")
        {
            return new()
            {
                IsSuccess = false,
                Message = because,
            };
        }
    }
}