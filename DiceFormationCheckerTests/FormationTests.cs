using Winsoft.Gaming.DiceFormationChecker;
using Xunit;

namespace DiceFormationCheckerTests
{
    public class FormationTests
    {
        [Fact]
        public void CanDetectBadCreation()
        {
            var _ = new FormationChecker(3, 3, 4, 4, 5);
            _ = new FormationChecker(3, 3, 4, 4, 5, 1);
            Assert.Throws<WrongNumberOfDiceException>(() => _ = new FormationChecker());
            Assert.Throws<WrongNumberOfDiceException>(() => _ = new FormationChecker(1, 2));
            Assert.Throws<WrongNumberOfDiceException>(() => _ = new FormationChecker(4, 1, 2, 3, 3, 1, 2));
            Assert.Throws<WrongDiceValueException>(() => new FormationChecker(1, 2, 5, 6, 7));
            Assert.Throws<WrongDiceValueException>(() => new FormationChecker(0, 1, 2, 5, 6, 2));
        }

        [Fact]
        public void CanDetectFiveDiceFormations()
        {
            Assert.Equal(new FormationChecker(3, 3, 3, 3, 3).CheckFiveDice().FormationName == FormationNameFiveDice.Yatzy);
        }

        [Fact]
        public void CanDetectSixDiceFormations()
        {
            Assert.Equal(new FormationChecker(2, 2, 2, 2, 2).CheckSixDice().FormationName == FormationNameSixDice.MaxiYatzy);
        }
    }
}