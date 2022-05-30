using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic
{
    public sealed class Snack : Entity
    {
        public string Name { get; private set; }

        public Snack(string name)
        {
            Name = name;
        }
    }
}
