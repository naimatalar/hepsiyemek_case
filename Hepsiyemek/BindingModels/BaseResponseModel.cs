using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.BindingModels
{
    public class BaseResponseModel
    {
        public BaseResponseModel(int statusCode, string message, object? result=null)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
