using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Response
{
    public class GenericResponse<T>
    {
        public GenericResponse(T data, string message, int statusCode)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }
        public bool Success => StatusCode == 200;
        public string Message { get; private set; }
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
    }
}
