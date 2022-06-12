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

        protected Slot()
        {

        }
        public Slot(int position ,SnackMachine snackMachine) : this()
        {
            Position = position;
            SnackPile = SnackPile.Empty;
            SnackMachine = snackMachine;
        }

    }
}
