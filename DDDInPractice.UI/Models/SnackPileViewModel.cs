using DDDInPractice.Logic;

namespace DDDInPractice.UI.Models
{
    public class SnackPileViewModel
    {
        private readonly SnackPile _SnackPile;
        public int Amount => _SnackPile.Quantity;
        public string Price => _SnackPile.Price.ToString("c2");
        public string Image => _SnackPile.Snack.Name + ".png";
        public int ImageWidth => GetImageWidth(_SnackPile.Snack);

        public SnackPileViewModel(SnackPile snackPile)
        {
            _SnackPile = snackPile;
        }

        private int GetImageWidth(Snack snack)
        {
            if (snack == Snack.Chocolate)
                return 120;
            if (snack == Snack.Soda)
                return 70;
            if (snack == Snack.Gum)
                return 70;
            throw new ArgumentException();
        }
    }
}
