using DDDInPractice.Logic;
using DDDInPractice.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DDDInPractice.UI.Controllers
{
    public class HomeController : Controller
    {
  
        private readonly SnackMachineViewModel _SnackMachineVM;

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
            switch (amount)
            {
                case "onecent":
                    _SnackMachineVM.InsertCent(Money.OneCent);
                    break;
                case "tencent":
                    _SnackMachineVM.InsertCent(Money.TenCent);
                    break;
                case "quarter":
                    _SnackMachineVM.InsertCent(Money.Quarter);
                    break;
                case "dollar":
                    _SnackMachineVM.InsertCent(Money.Dollar);
                    break;
                case "fivedollar":
                    _SnackMachineVM.InsertCent(Money.FiveDollar);
                    break;
                case "twentydollar":
                    _SnackMachineVM.InsertCent(Money.TwentyDollar);
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

        public IActionResult BuySnack()
        {
            _SnackMachineVM.BuySnack();
            return View("Index", _SnackMachineVM);
        }
    }
}