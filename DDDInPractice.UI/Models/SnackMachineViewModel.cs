using DDDInPractice.Logic;
using DDDInPractice.Logic.Context;
using DDDInPractice.Logic.Interface.Repository;
using DDDInPractice.Logic.Interface.Repository.SnackMachines;
using DDDInPractice.Logic.Repository.SnackMachines;
using DDDInPractice.Logic.Service.SnackMachines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDDInPractice.UI.Models
{
    public class SnackMachineViewModel
    {
        private readonly SnackMachine _SnackMachine;
        private readonly ISnackMachineService _SnackMachineService;

        public string FormattedMoneyInTransaction => _SnackMachine.MoneyInTransaction.ToString();
        public decimal MoneyInTransaction => _SnackMachine.MoneyInTransaction;
        public Money MoneyInside => _SnackMachine.MoneyInside;

        public IReadOnlyCollection<SnackPileViewModel> Piles
        {
            get
            {
                return _SnackMachine.GetAllSnackPiles()
                    .Select(x => new SnackPileViewModel(x))
                    .ToList();
            }
        }

        private string _message = "";
        public string Message { 
            get { return _message; }
            private set { _message = value; }
        }
        public SnackMachineViewModel(ISnackMachineService snackMachineService)
        {
            _SnackMachineService = snackMachineService;
            _SnackMachine = _SnackMachineService.GetById(1);
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

        public void BuySnack(string positionString)
        {
            int position = int.Parse(positionString);
            var error = _SnackMachine.CanBuySnack(position);
            if (error != String.Empty)
            {
                Message = error;
                return;
            }
            _SnackMachine.BuySnack(position);
            _SnackMachineService.Edit(_SnackMachine);
            Message = "You have bought snack";
        }

    }
}
