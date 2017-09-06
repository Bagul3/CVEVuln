using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public class UserMembership : Userbase
    {
        public int FailedPasswordAttemptCount { get; set; }

        public DateTime LastPasswordChnagedDate { get; set; }
    }
}
