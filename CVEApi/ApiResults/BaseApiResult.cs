using System.Collections.Generic;
using CVEVuln.Models;

namespace CVEApi
{
    public class BaseApiResult : Resource
    {
        public bool IsSuccess { get; internal set; }

        public string Message { get; set; }

        public static BaseApiResult Create(string message, bool isSuccess)
        {
            return new BaseApiResult { IsSuccess = isSuccess, Message = message };
        }
    }
}
