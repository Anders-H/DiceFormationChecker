﻿namespace Winsoft.Gaming.DiceFormationChecker
{
    public class FormationChecker
    {
        public readonly List<int> Dices;

        public FormationChecker(List<int> dices)
        {
            Dices = dices;
            CheckDiceList();
        }

        public FormationChecker(params int[] dice)
        {
            Dices = new List<int>();
            Dices.AddRange(dice);
            CheckDiceList();
        }

        public DiceFormation Check()
        {

        }

        public DiceFormationFive CheckFiveDice()
        {
            if (Dices.Count != 5)
                throw new SystemException("Number of dice must be 5.");

            return new DiceFormationFive(Check());
        }

        public DiceFormationSix CheckSixDice()
        {
            if (Dices.Count != 5)
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