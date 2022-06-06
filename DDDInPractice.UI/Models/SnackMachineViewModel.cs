using DDDInPractice.Logic;
using DDDInPractice.Logic.Context;
using DDDInPractice.Logic.Interface.Repository;
using DDDInPractice.Logic.Interface.Repository.SnackMachines;
using DDDInPractice.Logic.Repository.SnackMachines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDDInPractice.UI.Models
{
    public class SnackMachineViewModel
    {
        private readonly SnackMachine _SnackMachine;

        public string MoneyInTransaction => _SnackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _SnackMachine.MoneyInside;

        private string _message = "";
        public string Message { 
            get { return _message; }
            private set { _message = value; }
        }
        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _SnackMachine = snackMachine;
        }

        public void InsertMoney(Money money)
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
            _SnackMachine.BuySnack(3);
            Message = "You have bought snack";
        }

        public SnackMachine GetSnackMahine()
        {
            return _SnackMachine;
        }
    }
}
