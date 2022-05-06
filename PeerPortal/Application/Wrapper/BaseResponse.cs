using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrapper
{
    public class BaseResponse<T> where T : class
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }

        BaseResponse() { }
        BaseResponse(T data,string message=null) 
        { 
            Succeeded = true;
            Message = message;
            Data = data;
        }
        BaseResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }

    }
}
