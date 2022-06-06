using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public int Quantity { get;}
        public decimal Price { get;}
        public Snack Snack { get;}

        private SnackPile() { }
        public SnackPile(Snack snack, int quantity, decimal price) : this()
        {
            if (price % 0.01m > 0)
                throw new InvalidOperationException();
            if(price < 0 )
                throw new InvalidOperationException();
            if (quantity < 0)
                throw new InvalidOperationException();

            Quantity = quantity;
            Price = price;
            Snack = snack;
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return Quantity == other.Quantity 
                && Price == other.Price
                && Snack == other.Snack;
        }

        protected override int GetHashCodeCore()
        {
            var hasCode = Snack.GetHashCode();
            hasCode = (hasCode * 397) ^ Quantity;
            hasCode = (hasCode * 397) ^ Price.GetHashCode();

            return hasCode;
        }

        public SnackPile SubtractOne()
        {
            return new SnackPile(Snack ,(Quantity - 1), Price);
        }
    }
}
