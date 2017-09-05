using System.Collections.Generic;
using CVEVuln.Models;

namespace CVEApi
{
    public class BaseApiResult : Resource
    {
        public bool IsSuccess { get; internal set; }

        public virtual string Message { get; internal set;  }

        public static BaseApiResult Create(string message, bool isSuccess)
        {
            return new BaseApiResult { IsSuccess = isSuccess, Message = message };
        }
    }
}
