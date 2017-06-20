using CVEVuln.Extensions;

namespace CVEVuln.Models
{
    public enum CveEndpoints
    {
        [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=51&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=7")]
        Ubuntu,
        [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=23&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        Debian,
        [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=26&product_id=23546&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        WindowsServer2012,
        [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=345&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        McAfee,
        [StringValue("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=45&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        Apache,
        [StringValue("http://cvedetails.com/json-feed.php?numrows=30&vendor_id=25&product_ide=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        RedHat,
        [StringValue("http://cvedetails.com/json-feed.php?numrows=30&vendor_id=26&product_id=11366&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        WindowsServer2008,
        [StringValue("http://cvedetails.com/json-feed.php?numrows=30&vendor_id=93&product_id=19116&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        JavaJdk,
        [StringValue("http://cvedetails.com/json-feed.php?numrows=30&vendor_id=93&product_id=19117&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        JavaJre,
        [StringValue("http://cvedetails.com/json-feed.php?numrows=30&vendor_id=94288&product_id=16695&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=0")]
        GeoServer
    }
}
