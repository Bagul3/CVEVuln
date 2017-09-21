using System.Threading.Tasks;
using CVEVuln.Extensions;
using CVEVuln.Models.Resources.User;
using CVEVuln.Security;
using CVEVulnDA;

namespace CVEVulnService
{
    public class UserService
    {
        private readonly UserRepository _userResRepository;

        public UserService()
        {
            _userResRepository = new UserRepository();
        }

        public bool AddUser(UserResource user)
        {
            user.Password = AesEncrypt.Encrypt(user.Password.ToByteArray(), user.Password.ToByteArray());
            return _userResRepository.AddUserAsync(user);
        }
    }
}
