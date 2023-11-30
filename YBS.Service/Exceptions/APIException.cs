using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace YBS.Service.Exceptions
{
    public class APIException : Exception
    {
        public string Message { get; set; }
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public APIException(string Message)
        {
            this.Message = Message;
        }

    }
}