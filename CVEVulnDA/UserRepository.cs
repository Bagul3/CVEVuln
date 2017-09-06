using CVEVuln.Extensions;
using CVEVuln.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CVEVulnDA
{
    public class UserRepository : GenericRepository<CVE_VulnEntities, Account>
    {
        public T GetUser<T>(string userName) where T : Userbase
        {
            return GetUser<T>(item => item.username == userName);
        }

        private T GetUser<T>(Expression<Func<Account, bool>> predicate) where T : Userbase
        {
            var user = this.FindBy(predicate).SingleOrDefault().MapToSingle<T>();
            return user;
        }
    }
}
