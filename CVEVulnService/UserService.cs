using System.Collections.Generic;
using System.Linq;
using CVEVuln.Extensions;
using CVEVuln.Models;
using CVEVuln.Models.Resources.User;
using CVEVuln.Security;
using CVEVulnDA;

namespace CVEVulnService
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly RolesRepository _rolesRepository;
        private readonly AccountInRolesRepository _accountInRolesRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _rolesRepository = new RolesRepository();
            _accountInRolesRepository = new AccountInRolesRepository();
        }

        public bool AddUser(UserResource user)
        {
            if (!ValidateUser(user))
                return false;
            user.Password = AesEncrypt.Encrypt(user.Password.ToByteArray());
            var userId = _userRepository.AddUser(user);
            AddUserRoles(userId, user.Roles);
            return true;
        }

        private void AddUserRoles(int userId, string[] roles)
        {
            var roleIds = GetRoleIds(roles);
            var accountInRoles = roleIds.Select(roleId => new AccountInRoles() {accountId = userId, roleId = roleId}).ToList();
            _accountInRolesRepository.AddUserRoles(accountInRoles);
        }

        private IEnumerable<int> GetRoleIds(string[] roles)
        {
            return _rolesRepository.GetRoleIds(roles);
        }

        private bool ValidateUser(UserResource user)
        {
            return _userRepository.ValidateUser(user.Username);
        }
    }
}
