namespace Application.Wrapper
{
    /// <summary>
    /// Base Response class for every http response
    /// </summary>
    /// <typeparam name="T">Generic parameter of type class</typeparam>
    public class BaseResponse<T> where T : class
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }
        public int StatusCode { get; set; }

        /// <summary>
        /// parameterless constructor
        /// </summary>
        public BaseResponse() { }

        /// <summary>
        /// Single parameter constructor
        /// </summary>
        /// <param name="message"></param>
        public BaseResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }

        /// <summary>
        /// double parameter constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public BaseResponse(int statusCode, string message)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = message;
        }

        /// <summary>
        /// Three parameter constructor
        /// </summary>
        /// <param name="succeded"></param>
        /// <param name="data">Generic type data</param>
        /// <param name="message"></param>
        public BaseResponse(bool succeded,T data,string message) 
        { 
            Succeeded = succeded;
            Message = message;
            Data = data;
        }
    }
}
