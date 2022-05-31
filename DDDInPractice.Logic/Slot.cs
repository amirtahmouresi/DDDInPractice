using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic
{
    public sealed class Slot : Entity
    {
        public int Position { get; private set; }

        public SnackPile SnackPile { get; set; }
        public SnackMachine SnackMachine { get; private set; }

        public Slot(int position ,SnackMachine snackMachine)
        {
            Position = position;
            SnackPile = new SnackPile(null, 0, 0m);
            SnackMachine = snackMachine;
        }
    }
}
