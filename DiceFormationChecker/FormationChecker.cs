namespace Winsoft.Gaming.DiceFormationChecker;

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

        var formationName = FormationName.Nothing;
        var score = 0;

        var twoOfSame1 = Occurrences.FindIndex(x => x == 2) + 1;
        var twoOfSame2 = Occurrences.FindIndex(twoOfSame1, x => x == 2) + 1;
        var twoOfSame3 = Occurrences.FindIndex(twoOfSame2, x => x == 2) + 1;
        
        var twoOfSameHighest = new[] { twoOfSame1, twoOfSame2, twoOfSame3 }
            .OrderByDescending(x => x)
            .First();

        var threeOfSame1 = Occurrences.FindIndex(x => x == 3) + 1;
        var threeOfSame2 = Occurrences.FindIndex(threeOfSame1, x => x == 3) + 1;

        var threeOfSameHightest = new[] { threeOfSame1, threeOfSame2 }
            .OrderByDescending(x => x)
            .First();

        var fourOfSame = Occurrences.FindIndex(x => x == 4) + 1;

        var fiveOfSame = Occurrences.FindIndex(x => x == 5) + 1;

        if (Occurrences.Any(x => x == Dices.Count))
        {
            formationName = Dices.Count == 6
                ? FormationName.MaxiYatzy
                : FormationName.Yatzy;

            score = 100;
        }
        else if (twoOfSame1 > 0 && fourOfSame > 0)
        {
            formationName = FormationName.Tower;
            score = twoOfSameHighest * 2 + fourOfSame * 4;
        }
        else if (threeOfSame1 > 0 && threeOfSame2 > 0)
        {
            formationName = FormationName.Villa;
            score = threeOfSame1 * 3 + threeOfSame2 * 3;
        }
        else if (twoOfSame1 > 0 && threeOfSame1 > 0)
        {
            formationName = FormationName.FullHouse;
            score = twoOfSameHighest * 2 + threeOfSameHightest * 3;
        }
        else if (Occurrences.All(x => x == 1))
        {
            formationName = FormationName.FullStraight;
            score = 21;
        }
        else if (Occurrences[1] > 0 && Occurrences[2] > 0 && Occurrences[3] > 0 && Occurrences[4] > 0 && Occurrences[5] > 0)
        {
            formationName = FormationName.BigStraight;
            score = 20;
        }
        else if (Occurrences[0] > 0 && Occurrences[1] > 0 && Occurrences[2] > 0 && Occurrences[3] > 0 && Occurrences[4] > 0)
        {
            formationName = FormationName.SmallStraight;
            score = 15;
        }
        else if (fiveOfSame > 0)
        {
            formationName = FormationName.FiveOfAKind;
            score = fiveOfSame * 5;
        }
        else if (fourOfSame > 0)
        {
            formationName = FormationName.FourOfAKind;
            score = fourOfSame * 4;
        }
        else if ()
        {
            ...
        }

        var formation = new DiceFormation(score, formationName);
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