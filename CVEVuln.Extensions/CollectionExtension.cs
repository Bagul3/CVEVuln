using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Extensions
{
    public static class CollectionExtension
    {
        public static IEnumerable<T> CollectionOrEmpty<T>(this IEnumerable<T> obj)
        {
            return obj ?? Enumerable.Empty<T>();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj, Func<T, bool> predicate = null)
        {
            return obj == null || !obj.Any(predicate ?? (t => true));
        }
    }
}
