using DDDInPractice.Logic;
using DDDInPractice.Logic.Service.SnackMachines;
using DDDInPractice.UI.Extensions;
using DDDInPractice.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DDDInPractice.UI.Controllers
{
    public class HomeController : Controller
    {
  
        private SnackMachineViewModel _SnackMachineVM;

        public HomeController(SnackMachineViewModel snackMachineVM)
        {
            _SnackMachineVM = snackMachineVM;
        }

        public IActionResult Index()
        {
            
            return View(_SnackMachineVM);
        }

        public IActionResult InsertMoney([FromQuery]string amount)
        {
            AssignMoneyInTransaction();

            switch (amount)
            {
                case "onecent":
                    _SnackMachineVM.InsertMoney(Money.OneCent);
                    TempData.Put("MoneyInTransaction", _SnackMachineVM.MoneyInside.Allocate(_SnackMachineVM.MoneyInTransaction));
                    break;
                case "tencent":
                    _SnackMachineVM.InsertMoney(Money.TenCent);
                    TempData.Put("MoneyInTransaction", _SnackMachineVM.MoneyInside.Allocate(_SnackMachineVM.MoneyInTransaction));
                    break;
                case "quarter":
                    _SnackMachineVM.InsertMoney(Money.Quarter);
                    TempData.Put("MoneyInTransaction", _SnackMachineVM.MoneyInside.Allocate(_SnackMachineVM.MoneyInTransaction));
                    break;
                case "dollar":
                    _SnackMachineVM.InsertMoney(Money.Dollar);
                    TempData.Put("MoneyInTransaction", _SnackMachineVM.MoneyInside.Allocate(_SnackMachineVM.MoneyInTransaction));
                    break;
                case "fivedollar":
                    _SnackMachineVM.InsertMoney(Money.FiveDollar);
                    TempData.Put("MoneyInTransaction", _SnackMachineVM.MoneyInside.Allocate(_SnackMachineVM.MoneyInTransaction));
                    break;
                case "twentydollar":
                    _SnackMachineVM.InsertMoney(Money.TwentyDollar);
                    TempData.Put("MoneyInTransaction", _SnackMachineVM.MoneyInside.Allocate(_SnackMachineVM.MoneyInTransaction));
                    break;
                default:
                    return View("Index", _SnackMachineVM);
            }
            return View("Index", _SnackMachineVM);

        }



        public IActionResult ReturnMoney()
        {
            _SnackMachineVM.ReturnMoney();
            return View("Index", _SnackMachineVM);
        }

        public IActionResult BuySnack(string position)
        {
            AssignMoneyInTransaction();
            _SnackMachineVM.BuySnack(position);
            return View("Index", _SnackMachineVM);
        }


        #region private methods
        private void AssignMoneyInTransaction()
        {
            var tempMoneyInTransaction = TempData.Get<Money>("MoneyInTransaction");
            if (tempMoneyInTransaction != null && tempMoneyInTransaction.Amount > 0)
            {
                if (tempMoneyInTransaction.OneCentCount > 0)
                    while (tempMoneyInTransaction.OneCentCount > 0)
                    {
                        _SnackMachineVM.InsertMoney(Money.OneCent);
                        tempMoneyInTransaction -= Money.OneCent;
                    }
                if (tempMoneyInTransaction.TenCentCount > 0)
                    while (tempMoneyInTransaction.TenCentCount > 0)
                    {
                        _SnackMachineVM.InsertMoney(Money.TenCent);
                        tempMoneyInTransaction -= Money.TenCent;
                    }
                if (tempMoneyInTransaction.QuarterCount > 0)
                    while (tempMoneyInTransaction.QuarterCount > 0)
                    {
                        _SnackMachineVM.InsertMoney(Money.Quarter);
                        tempMoneyInTransaction -= Money.Quarter;
                    }
                if (tempMoneyInTransaction.OneDollarCount > 0)
                    while (tempMoneyInTransaction.OneDollarCount > 0)
                    {
                        _SnackMachineVM.InsertMoney(Money.Dollar);
                        tempMoneyInTransaction -= Money.Dollar;
                    }
                if (tempMoneyInTransaction.FiveDollarCount > 0)
                    while (tempMoneyInTransaction.FiveDollarCount > 0)
                    {
                        _SnackMachineVM.InsertMoney(Money.FiveDollar);
                        tempMoneyInTransaction -= Money.FiveDollar;
                    }
                if (tempMoneyInTransaction.TwentyDollarCount > 0)
                    while (tempMoneyInTransaction.TwentyDollarCount > 0)
                    {
                        _SnackMachineVM.InsertMoney(Money.TwentyDollar);
                        tempMoneyInTransaction -= Money.TwentyDollar;
                    }
            }
        }
        #endregion
    }
}