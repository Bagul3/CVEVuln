//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CVEVuln.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vulnerabilities
    {
        public int Id { get; set; }
        public string cve_id { get; set; }
        public string cwe_id { get; set; }
        public string summary { get; set; }
        public string cvss_score { get; set; }
        public string exploit_count { get; set; }
        public Nullable<System.DateTime> publish_date { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public string url { get; set; }
        public string service { get; set; }
    }
}
