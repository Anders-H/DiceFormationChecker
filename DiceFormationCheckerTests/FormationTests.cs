using Winsoft.Gaming.DiceFormationChecker;
using Winsoft.Gaming.DiceFormationChecker.Exceptions;
using Winsoft.Gaming.DiceFormationChecker.FormationNames;
using Xunit;

namespace DiceFormationCheckerTests
{
    public class FormationTests
    {
        [Fact]
        public void CanDetectBadCreation()
        {
            {
                var _ = new FormationChecker(3, 3, 4, 4, 5);
            }

            {
                var _ = new FormationChecker(3, 3, 4, 4, 5, 1);
            }

            Assert.Throws<WrongNumberOfDiceException>(() => _ = new FormationChecker());
            Assert.Throws<WrongNumberOfDiceException>(() => _ = new FormationChecker(1, 2));
            Assert.Throws<WrongNumberOfDiceException>(() => _ = new FormationChecker(4, 1, 2, 3, 3, 1, 2));
            Assert.Throws<WrongDiceValueException>(() => new FormationChecker(1, 2, 5, 6, 7));
            Assert.Throws<WrongDiceValueException>(() => new FormationChecker(0, 1, 2, 5, 6, 2));
        }

        [Fact]
        public void CanDoFiveDiceSum()
        {
            Assert.Equal(17, new FormationChecker(1, 1, 5, 5, 5).CheckFiveDice().DiceSumValue);
            Assert.Equal(2, new FormationChecker(1, 1, 5, 5, 5).CheckFiveDice().SumOne);
            Assert.Equal(0, new FormationChecker(1, 1, 5, 5, 5).CheckFiveDice().SumTwo);
            Assert.Equal(0, new FormationChecker(1, 1, 5, 5, 5).CheckFiveDice().SumThree);
            Assert.Equal(0, new FormationChecker(1, 1, 5, 5, 5).CheckFiveDice().SumFour);
            Assert.Equal(15, new FormationChecker(1, 1, 5, 5, 5).CheckFiveDice().SumFive);
            Assert.Equal(0, new FormationChecker(1, 1, 5, 5, 5).CheckFiveDice().SumSix);
        }

        [Fact]
        public void CanDoSixDiceSum()
        {
            Assert.Equal(19, new FormationChecker(1, 1, 5, 5, 5, 2).CheckSixDice().DiceSumValue);
            Assert.Equal(2, new FormationChecker(1, 1, 5, 5, 5, 2).CheckSixDice().SumOne);
            Assert.Equal(2, new FormationChecker(1, 1, 5, 5, 5, 2).CheckSixDice().SumTwo);
            Assert.Equal(0, new FormationChecker(1, 1, 5, 5, 5, 2).CheckSixDice().SumThree);
            Assert.Equal(0, new FormationChecker(1, 1, 5, 5, 5, 2).CheckSixDice().SumFour);
            Assert.Equal(15, new FormationChecker(1, 1, 5, 5, 5, 2).CheckSixDice().SumFive);
            Assert.Equal(0, new FormationChecker(1, 1, 5, 5, 5, 2).CheckSixDice().SumSix);
        }

        [Fact]
        public void CanDetectFiveDiceFormations()
        {
            Assert.Equal(100, new FormationChecker(3, 3, 3, 3, 3).CheckFiveDice().GetFormation(FormationNameFiveDice.Yatzy).Score);
            Assert.Equal(17, new FormationChecker(3, 4, 4, 3, 3).CheckFiveDice().GetFormation(FormationNameFiveDice.FullHouse).Score);
        }

        [Fact]
        public void CanDetectSixDiceFormations()
        {
            Assert.Equal(100, new FormationChecker(2, 2, 2, 2, 2, 2).CheckSixDice().GetFormation(FormationNameSixDice.MaxiYatzy).Score);
            Assert.Equal(14, new FormationChecker(2, 2, 3, 3, 2, 2).CheckSixDice().GetFormation(FormationNameSixDice.Tower).Score);
            Assert.Equal(15, new FormationChecker(2, 2, 3, 3, 3, 2).CheckSixDice().GetFormation(FormationNameSixDice.Villa).Score);
            Assert.Equal(13, new FormationChecker(2, 1, 3, 3, 3, 2).CheckSixDice().GetFormation(FormationNameSixDice.FullHouse).Score);
        }
    }
}