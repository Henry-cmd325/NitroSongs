using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Common.Common
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ServiceResponse<T> Success(T data)
        {
            return new ServiceResponse<T>
            {
                Data = data,
                IsSuccess = true
            };
        }

        public static ServiceResponse<T> Failure(string errorMessage)
        {
            return new ServiceResponse<T>
            {
                Data = default,
                IsSuccess = false,
                Message = errorMessage
            };
        }
    }
}
