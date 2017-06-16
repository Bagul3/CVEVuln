using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVEVuln.Models;

namespace CVEApi
{
    public class VulnApiResult : BaseApiResult
    {
        public Vulnerability Vulnerability { get; set; }
    }
}
