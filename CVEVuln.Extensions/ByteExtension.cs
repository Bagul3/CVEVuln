using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Extensions
{
    public static class ByteExtension
    {
        public static string AsString(this byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
