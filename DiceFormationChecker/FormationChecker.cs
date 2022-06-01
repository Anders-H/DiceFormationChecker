namespace Winsoft.Gaming.DiceFormationChecker
{
    public class FormationChecker
    {
        private readonly List<int> Occurrences;
        public readonly List<int> Dices;

        public FormationChecker(List<int> dices)
        {
            Occurrences = new List<int>();
            Dices = dices;
            CheckDiceList();
        }

        public FormationChecker(params int[] dice)
        {
            Occurrences = new List<int>();
            Dices = new List<int>();
            Dices.AddRange(dice);
            CheckDiceList();
        }

        public DiceFormation Check()
        {
            if (Dices.Count < 5 || Dices.Count > 6)
                throw new SystemException("Number of dice must be 5 or 6.");

            for (var i = 1; i <= 6; i++)
                Occurrences.Add(Dices.Count(x => x == i));
            




            var formation = new DiceFormation(0, FormationName.Nothing);
            formation.Values.AddRange(Dices);

            return formation;
        }

        public DiceFormationFive CheckFiveDice()
        {
            if (Dices.Count != 5)
                throw new SystemException("Number of dice must be 5.");

            return new DiceFormationFive(Check());
        }

        public DiceFormationSix CheckSixDice()
        {
            if (Dices.Count != 6)
                throw new SystemException("Number of dice must be 6.");

            return new DiceFormationSix(Check());
        }

        private void CheckDiceList()
        {
            if (Dices.Count is < 5 or > 6)
                throw new WrongNumberOfDiceException(Dices.Count);

            if (Dices.Any(dice => dice is < 1 or > 6))
                throw new WrongDiceValueException();
        }
    }
}