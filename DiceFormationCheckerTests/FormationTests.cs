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
            Assert.Equal(100, new FormationChecker(3, 3, 3, 3, 3).CheckFiveDice().GetFormation(FormationNameFiveDice.Yatzy)!.Score);
            Assert.Equal(17, new FormationChecker(3, 4, 4, 3, 3).CheckFiveDice().GetFormation(FormationNameFiveDice.FullHouse)!.Score);
            Assert.Equal(20, new FormationChecker(5, 4, 6, 3, 2).CheckFiveDice().GetFormation(FormationNameFiveDice.BigStraight)!.Score);
            Assert.Equal(15, new FormationChecker(5, 1, 4, 3, 2).CheckFiveDice().GetFormation(FormationNameFiveDice.SmallStraight)!.Score);
            Assert.Equal(20, new FormationChecker(5, 3, 5, 5, 5).CheckFiveDice().GetFormation(FormationNameFiveDice.FourOfAKind)!.Score);
            Assert.Equal(15, new FormationChecker(5, 1, 5, 2, 5).CheckFiveDice().GetFormation(FormationNameFiveDice.ThreeOfAKind)!.Score);
            Assert.Equal(10, new FormationChecker(2, 3, 3, 2, 5).CheckFiveDice().GetFormation(FormationNameFiveDice.TwoPairs)!.Score);
            Assert.Equal(6, new FormationChecker(1, 3, 3, 2, 5).CheckFiveDice().GetFormation(FormationNameFiveDice.Pair)!.Score);
            Assert.Equal(0, new FormationChecker(1, 2, 4, 5, 6).CheckFiveDice().GetFormation(FormationNameFiveDice.Nothing)!.Score);
            Assert.Null(new FormationChecker(2, 3, 3, 2, 5).CheckFiveDice().GetFormation(FormationNameFiveDice.FullHouse));
        }

        [Fact]
        public void CanDetectSixDiceFormations()
        {
            var fc = new FormationChecker(2, 2, 2, 2, 2, 2);
            var formations = fc.CheckSixDice();
            var f = formations.GetFormation(FormationNameSixDice.MaxiYatzy);
            Assert.Equal(100, f.Score);



            Assert.Equal(100, new FormationChecker(2, 2, 2, 2, 2, 2).CheckSixDice().GetFormation(FormationNameSixDice.MaxiYatzy)!.Score);
            Assert.Equal(14, new FormationChecker(2, 2, 3, 3, 2, 2).CheckSixDice().GetFormation(FormationNameSixDice.Tower)!.Score);
            Assert.Equal(15, new FormationChecker(2, 2, 3, 3, 3, 2).CheckSixDice().GetFormation(FormationNameSixDice.Villa)!.Score);
            Assert.Equal(13, new FormationChecker(2, 1, 3, 3, 3, 2).CheckSixDice().GetFormation(FormationNameSixDice.FullHouse)!.Score);
            Assert.Equal(21, new FormationChecker(5, 1, 4, 6, 3, 2).CheckSixDice().GetFormation(FormationNameSixDice.FullStraight)!.Score);
            Assert.Equal(20, new FormationChecker(5, 3, 4, 6, 3, 2).CheckSixDice().GetFormation(FormationNameSixDice.BigStraight)!.Score);
            Assert.Equal(15, new FormationChecker(5, 1, 4, 3, 3, 2).CheckSixDice().GetFormation(FormationNameSixDice.SmallStraight)!.Score);
            Assert.Equal(25, new FormationChecker(5, 1, 5, 5, 5, 5).CheckSixDice().GetFormation(FormationNameSixDice.FiveOfAKind)!.Score);
            Assert.Equal(20, new FormationChecker(5, 1, 3, 5, 5, 5).CheckSixDice().GetFormation(FormationNameSixDice.FourOfAKind)!.Score);
            Assert.Equal(15, new FormationChecker(5, 1, 3, 5, 2, 5).CheckSixDice().GetFormation(FormationNameSixDice.ThreeOfAKind)!.Score);
            Assert.Equal(20, new FormationChecker(5, 2, 3, 3, 2, 5).CheckSixDice().GetFormation(FormationNameSixDice.ThreePairs)!.Score);
            Assert.Equal(10, new FormationChecker(6, 2, 3, 3, 2, 5).CheckSixDice().GetFormation(FormationNameSixDice.TwoPairs)!.Score);
            Assert.Equal(6, new FormationChecker(6, 1, 3, 3, 2, 5).CheckSixDice().GetFormation(FormationNameSixDice.Pair)!.Score);
            Assert.Null(new FormationChecker(6, 1, 3, 3, 2, 5).CheckSixDice().GetFormation(FormationNameSixDice.Tower));
        }
    }
}