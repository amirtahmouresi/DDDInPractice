using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class MapFromAttribute : Attribute
    {
        public MapFromAttribute()
        {

        }

        public MapFromAttribute(string _PropertyName)
        {
            this.PropertyName = _PropertyName;
        }
        public string PropertyName { get; set; }

    }
}
