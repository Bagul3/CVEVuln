using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{
    internal abstract class AuthenicatorBase
    {
        public UserMembership User { get; protected set; }

        public bool Authenicate(out string errorMessage)
        {
            return this.AuthenicateInternal(out errorMessage);
        }

        protected abstract bool AuthenicateInternal(out string errorMessage);
    }
}
