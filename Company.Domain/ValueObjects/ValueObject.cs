using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.ValueObjects
{
    public abstract class ValueObject<T>
    {
        public T Value { get; protected set; }
        public abstract bool IsValid();
    }
}
