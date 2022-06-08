using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class DtoForAttribute : Attribute
    {
        public DtoForAttribute(Type _EntityClass)
        {
            this.EntityClass = _EntityClass;
        }

        public DtoForAttribute()
        {

        }
        public Type EntityClass { get; set; }

    }
}
