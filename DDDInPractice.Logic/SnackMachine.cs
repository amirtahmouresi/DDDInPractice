using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : AggregateRoot
    {
        public Money MoneyInside { get; private set; }
        public decimal MoneyInTransaction { get; private set; }
        protected IList<Slot> Slots { get; private set; }

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = 0;
            Slots = new List<Slot>
            {
                new Slot(1, null),
                new Slot(2, null),
                new Slot(3, null)
            };
        }

        public SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { OneCent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInside += money;
            MoneyInTransaction += money.Amount;
        }

        public void ReturnMoney()
        {
            var moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public void BuySnack(int position)
        {
            var slot = GetSlot(position);
            if (slot.SnackPile.Price > MoneyInTransaction)
                throw new InvalidOperationException();
            slot.SnackPile = slot.SnackPile.SubtractOne();

            var change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            if (change.Amount < (MoneyInTransaction - slot.SnackPile.Price))
                throw new InvalidOperationException();
            MoneyInside -= change;

            MoneyInTransaction = 0;
        }

        public void LoadSnack(int position, SnackPile snackPile)
        {
            var slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

    }
}
