using CVEVuln.Extensions;
using CVEVuln.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using CVEVuln.Models.Resources.User;

namespace CVEVulnDA
{
    public class UserRepository : GenericRepository<CVE_VulnEntities, Account>
    {
        public T GetUser<T>(string userName) where T : Userbase
        {
            return GetUser<T>(item => item.username == userName);
        }

        //TODO fix mapper
        private T GetUser<T>(Expression<Func<Account, bool>> predicate) where T : Userbase
        {
            var returnValue = this.FindBy(predicate).SingleOrDefault();
            //var user = this.FindBy(predicate).SingleOrDefault().MapToSingle<T>();
            var user = new UserMembership(){ Email = returnValue.email, Name = returnValue.username.Trim(), Password = returnValue.password.Trim(), UserId = returnValue.accountId };
            return user as T;
        }
    }
}
