using DDDInPractice.Logic;
using DDDInPractice.Logic.Service.SnackMachines;
using DDDInPractice.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DDDInPractice.UI.Controllers
{
    public class HomeController : Controller
    {
  
        private SnackMachineViewModel _SnackMachineVM;
        private readonly ISnackMachineService _SnackMachineService;

        public HomeController(ISnackMachineService snackMachineService)
        {
            _SnackMachineService = snackMachineService;
            var snackMachine = _SnackMachineService.Get();
            _SnackMachineVM = new SnackMachineViewModel(snackMachine);
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
                    _SnackMachineVM.InsertMoney(Money.OneCent);
                    break;
                case "tencent":
                    _SnackMachineVM.InsertMoney(Money.TenCent);
                    break;
                case "quarter":
                    _SnackMachineVM.InsertMoney(Money.Quarter);
                    break;
                case "dollar":
                    _SnackMachineVM.InsertMoney(Money.Dollar);
                    break;
                case "fivedollar":
                    _SnackMachineVM.InsertMoney(Money.FiveDollar);
                    break;
                case "twentydollar":
                    _SnackMachineVM.InsertMoney(Money.TwentyDollar);
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
            _SnackMachineService.Edit(_SnackMachineVM.GetSnackMahine());
            return View("Index", _SnackMachineVM);
        }
    }
}