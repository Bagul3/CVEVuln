﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVEVuln.Extensions;

namespace CVEApi
{
    public static class CveEndpoints
    {
        /*    public static string Ubuntu => "http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=51&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=7";
            public static string Debian => "http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=23&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string WindowsServer2012 => "http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=26&product_id=23546&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string McAfee => "http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=345&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string Apache => "http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=45&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string RedHat => "http://cvedetails.com/json-feed.php?numrows=30&vendor_id=25&product_ide=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string WindowsServer2008 => "http://cvedetails.com/json-feed.php?numrows=30&vendor_id=26&product_id=11366&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string JavaJdk => "http://cvedetails.com/json-feed.php?numrows=30&vendor_id=93&product_id=19116&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string JavaJre => "http://cvedetails.com/json-feed.php?numrows=30&vendor_id=93&product_id=19117&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";
            public static string GeoServer => "http://cvedetails.com/json-feed.php?numrows=30&vendor_id=94288&product_id=16695&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0";*/
        public enum Service
        {
            [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=51&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=7")]
            Ubuntu,
            [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=23&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
            Debian,
            [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=26&product_id=23546&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
            WindowsServer2012
        }
    }
}
