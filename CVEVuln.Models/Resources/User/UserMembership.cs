using System;

namespace CVEVuln.Models.Resources.User
{
    public class UserMembership : Userbase
    {
        public int FailedPasswordAttemptCount { get; set; }

        public DateTime LastPasswordChnagedDate { get; set; }
    }
}
