using CVEVuln.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CVEVuln.Models.Resources.User;

namespace CVEVulnDA
{
    public class UserRepository : GenericRepository<CVE_VulnEntities, Account>
    {
        public T GetUser<T>(string userName) where T : Userbase
        {
            return GetUser<T>(item => item.username == userName);
        }

        public T GetUser<T>(int userId) where T : Userbase
        {
            return GetUser<T>(item => item.accountId == userId);
        }

        public bool AddUserAsync<T>(T user) where T : UserResource
        {
            var account = new AutoMapperBase().Mapper.Map<Account>(user);
            this.Add(account);
            this.Save();
            return true;
        }

        private T GetUser<T>(Expression<Func<Account, bool>> predicate) where T : Userbase
        {
            var user = this.FindBy(predicate).SingleOrDefault();
            return new AutoMapperBase().Mapper.Map<UserMembership>(user) as T;
        }
    }
}
