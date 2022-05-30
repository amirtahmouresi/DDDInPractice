using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set; }
        public IList<Slot> Slots { get; private set; }

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = None;
            Slots = new List<Slot>
            {
                new Slot(1, 0, 0m, null, null),
                new Slot(2, 0, 0m, null, null),
                new Slot(3, 0, 0m, null, null),
            };
        }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { OneCent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack(int position)
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
            Slots.Single(x => x.Position == position).Quantity--;
        }

        public void LoadSnack(int position, Snack snack, int quantity, decimal price)
        {
            var slot = Slots.Single(x => x.Position == position);
            slot.Quantity = quantity;
            slot.Price = price;
            slot.Snack = snack;
        }

    }
}
