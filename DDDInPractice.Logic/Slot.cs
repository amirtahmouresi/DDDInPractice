using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic
{
    public sealed class Slot : Entity
    {
        public int Position { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Snack Snack { get; set; }
        public SnackMachine SnackMachine { get; set; }

        public Slot(int position, int quantity, decimal price, Snack snack, SnackMachine snackMachine)
        {
            Position = position;
            Quantity = quantity;
            Price = price;
            Snack = snack;
            SnackMachine = snackMachine;
        }
    }
}
