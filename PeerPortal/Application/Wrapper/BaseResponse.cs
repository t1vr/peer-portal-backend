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

        public BaseResponse() { }

        public BaseResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public BaseResponse(bool succeded,T data,string message=null) 
        { 
            Succeeded = succeded;
            Message = message;
            Data = data;
        }
        

    }
}
