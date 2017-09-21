using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CVEApi;
using CVEApi.ApiResults;
using CVEVuln.Models.Resources.User;

namespace CVEVuln.Controllers
{
    public class UserController : ApiController
    {
        public BaseApiResult CreateUser(UserResource user)
        {
            return new UserApi().AddUser(user);
        }
    }
}
