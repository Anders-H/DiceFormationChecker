using Winsoft.Gaming.DiceFormationChecker;
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
            Assert.Equal(FormationNameFiveDice.Yatzy, new FormationChecker(3, 3, 3, 3, 3).CheckFiveDice().FormationName);
        }

        [Fact]
        public void CanDetectSixDiceFormations()
        {
            Assert.Equal(FormationNameSixDice.MaxiYatzy, new FormationChecker(2, 2, 2, 2, 2).CheckSixDice().FormationName);
        }
    }
}