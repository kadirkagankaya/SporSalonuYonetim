using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SporSalonuYonetim.Core.DTOs
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public bool Success { get; set; }
        public string? Message { get; set; }

        public static ServiceResponse<T> SuccessResult(T data, int statusCode = 200)
        {
            return new ServiceResponse<T> { Data = data, StatusCode = statusCode, Success = true };
        }

        public static ServiceResponse<T> SuccessResult(int statusCode = 200)
        {
            return new ServiceResponse<T> { Data = default(T), StatusCode = statusCode, Success = true };
        }

        public static ServiceResponse<T> FailResult(string message, int statusCode = 400)
        {
            return new ServiceResponse<T> { Message = message, StatusCode = statusCode, Success = false };
        }

        public static ServiceResponse<T> FailResult(List<string> messages, int statusCode = 400)
        {
            return new ServiceResponse<T> { Message = string.Join(", ", messages), StatusCode = statusCode, Success = false };
        }
    }
}
