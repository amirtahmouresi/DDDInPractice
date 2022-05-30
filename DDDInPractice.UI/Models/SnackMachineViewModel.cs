using DDDInPractice.Logic;

namespace DDDInPractice.UI.Models
{
    public class SnackMachineViewModel
    {
        private readonly SnackMachine _SnackMachine;
        public string MoneyInTransaction => _SnackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _SnackMachine.MoneyInside + _SnackMachine.MoneyInTransaction;

        private string _message = "";
        public string Message { 
            get { return _message; }
            private set { _message = value; }
        }
        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _SnackMachine = snackMachine;
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
            _SnackMachine.BuySnack();
            Message = "You have bought snack";
        }
    }
}
