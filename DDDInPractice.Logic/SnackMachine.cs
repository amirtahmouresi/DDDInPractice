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
        private IList<Slot> _slots;
        public IEnumerable<Slot> Slots => _slots.ToList();

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = 0;
            //_slots = new List<Slot>();
            //AddSlot(1);
            //AddSlot(2);
            //AddSlot(3);
        }

        private void AddSlot(int position)
        {
            _slots.Add(new Slot(position, null));
        }

        public SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public IReadOnlyCollection<SnackPile> GetAllSnackPiles()
        {
            return _slots
                .OrderBy(x => x.Position)
                .Select(x => x.SnackPile)
                .ToList();
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

        public string CanBuySnack(int position)
        {
            SnackPile snackPile = GetSnackPile(position);

            if (snackPile.Quantity == 0)
                return "The snack pile is empty";

            if (MoneyInTransaction < snackPile.Price)
                return "Not enough money";

            if (MoneyInside.CanAllocate(MoneyInTransaction - snackPile.Price) == false)
                return "Not enough change";

            return String.Empty;
        }

        public void BuySnack(int position)
        {
            var error = CanBuySnack(position);
            if (error != String.Empty)
                throw new InvalidOperationException();

            var slot = GetSlot(position);
            slot.SnackPile = slot.SnackPile.SubtractOne();

            var change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);

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
