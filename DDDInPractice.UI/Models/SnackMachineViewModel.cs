using DDDInPractice.Logic;
using DDDInPractice.Logic.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDDInPractice.UI.Models
{
    public class SnackMachineViewModel
    {
        private readonly ApplicationDBContext _context;
        private readonly SnackMachine _SnackMachine;
        public string MoneyInTransaction => _SnackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _SnackMachine.MoneyInside;

        private string _message = "";
        public string Message { 
            get { return _message; }
            private set { _message = value; }
        }
        public SnackMachineViewModel(ApplicationDBContext context)
        {
            _context = context;
            _SnackMachine = context.Set<SnackMachine>().FirstOrDefault();
        }

        public void InsertCent(Money money)
        {
            _SnackMachine.InsertMoney(money);
            Message = "You have inserted: " + money;
        }

        public void ReturnMoney()
        {
            _SnackMachine.ReturnMoney();
            Message = "Money was returned";
        }

        public void BuySnack()
        {
            _SnackMachine.BuySnack(1);
            _context.SaveChanges();
            DetachAll();
            Message = "You have bought snack";
        }

        private void DetachAll()
        {
            EntityEntry[] entityEntries = _context.ChangeTracker.Entries().ToArray();

            foreach (EntityEntry entityEntry in entityEntries)
            {
                entityEntry.State = EntityState.Detached;
            }
        }
    }
}
