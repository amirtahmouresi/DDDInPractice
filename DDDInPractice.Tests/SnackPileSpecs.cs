using DDDInPractice.Logic;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static DDDInPractice.Logic.Snack;

namespace DDDInPractice.Tests
{
    public class SnackPileSpecs
    {

        [Theory]
        [InlineData(-1)]
        [InlineData(0.001)]
        [InlineData(0.0001)]
        public void Snack_could_not_have_undefined_price(decimal price)
        {
            var snackMachine = new SnackMachine();
            Action action = () => snackMachine.LoadSnack(1, new SnackPile(Chocolate, 10, price));

            action.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(-1)]
        public void Snack_could_not_have_negative_quantity(int quantity)
        {
            var snackMachine = new SnackMachine();
            Action action = () => snackMachine.LoadSnack(1, new SnackPile(Chocolate, quantity, 1));

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
