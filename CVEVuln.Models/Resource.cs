using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public class Resource<T>
    {
        private T _value;

        public T Value { get { return _value; } set { _value = value; } }

        public static implicit operator T (Resource<T> value)
        {
            return value.Value;
        }

        public static implicit operator Resource<T>(T value)
        {
            return new Resource<T> { Value = value };
        }
    }
}
