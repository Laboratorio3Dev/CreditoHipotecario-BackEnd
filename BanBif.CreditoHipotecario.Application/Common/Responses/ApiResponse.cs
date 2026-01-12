using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Result { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>
            {
                Result = true,
                Data = data
            };
        }

        public static ApiResponse<T> Failure()
        {
            return new ApiResponse<T>
            {
                Result = false,
                Data = default
            };
        }
    }
}
