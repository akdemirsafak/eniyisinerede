using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SharedLibrary.Dtos
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ApiResponse<T> Success(T data, int statusCode=200)
        {
            return new ApiResponse<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }
        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T>
            {
                Data = default,
                StatusCode = statusCode
            };
        }
        public static ApiResponse<T> Fail(List<string> errors, int statusCode)
        {
            return new ApiResponse<T>
            {
                Data= default,
                Errors = errors,
                StatusCode = statusCode
            };
        }
        public static ApiResponse<T> Fail(string error, int statusCode)
        {
            return new ApiResponse<T>
            {
                Data=default,
                Errors = new List<string>() { error },
                StatusCode = statusCode
            };
        }

    }
}
