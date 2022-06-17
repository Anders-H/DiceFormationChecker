using Winsoft.Gaming.DiceFormationChecker.Exceptions;
using Winsoft.Gaming.DiceFormationChecker.FormationNames;
using Winsoft.Gaming.DiceFormationChecker.Formations;
using Winsoft.Gaming.DiceFormationChecker.Scoring;

namespace Winsoft.Gaming.DiceFormationChecker;

public class FormationChecker
{
    private readonly List<int> _occurrences;
    public readonly List<int> Dices;

    public FormationChecker(params int[] dice)
    {
        _occurrences = new List<int>();
        Dices = new List<int>();
        Dices.AddRange(dice);
        CheckDiceList();
    }

    public DiceFormation Check()
    {
        if (Dices.Count < 5 || Dices.Count > 6)
            throw new SystemException("Number of dice must be 5 or 6.");

        for (var i = 1; i <= 6; i++)
            _occurrences.Add(Dices.Count(x => x == i));

        var formationParts = new FormationPartList();

        var twoOfSame1 = _occurrences.FindIndex(x => x >= 2) + 1;
        if (twoOfSame1 > 0)
            formationParts.Add(twoOfSame1, 2);

        var twoOfSame2 = _occurrences.FindIndex(twoOfSame1, x => x >= 2) + 1;
        if (twoOfSame2 > 0)
            formationParts.Add(twoOfSame2, 2);

        var twoOfSame3 = _occurrences.FindIndex(twoOfSame2, x => x >= 2) + 1;
        if (twoOfSame3 > 0)
            formationParts.Add(twoOfSame3, 2);

        var threeOfSame1 = _occurrences.FindIndex(x => x >= 3) + 1;
        if (threeOfSame1 > 0)
            formationParts.Add(threeOfSame1, 3);

        var threeOfSame2 = _occurrences.FindIndex(threeOfSame1, x => x >= 3) + 1;
        if (threeOfSame2 > 0)
            formationParts.Add(threeOfSame2, 3);

        var fourOfSame = _occurrences.FindIndex(x => x >= 4) + 1;
        if (fourOfSame > 0)
            formationParts.Add(fourOfSame, 4);

        var fiveOfSame = _occurrences.FindIndex(x => x >= 5) + 1;
        if (fiveOfSame > 0)
            formationParts.Add(fiveOfSame, 5);

        var formations = new FormationNameAndScoreList();

        if (_occurrences.Any(x => x == Dices.Count))
            formations.Add(100, Dices.Count == 6 ? FormationName.MaxiYatzy : FormationName.Yatzy);

        formations.AddIfNotNull(formationParts.GetBestTower());

        formations.AddIfNotNull(formationParts.GetBestVilla());

        if (_occurrences.All(x => x == 1))
            formations.Add(21, FormationName.FullStraight);

        if (_occurrences[1] > 0 && _occurrences[2] > 0 && _occurrences[3] > 0 && _occurrences[4] > 0 && _occurrences[5] > 0)
            formations.Add(20, FormationName.BigStraight);

        if (_occurrences[0] > 0 && _occurrences[1] > 0 && _occurrences[2] > 0 && _occurrences[3] > 0 && _occurrences[4] > 0)
            formations.Add(15, FormationName.SmallStraight);

        if (fiveOfSame > 0)
            formations.Add(fiveOfSame * 5, FormationName.FiveOfAKind);

        if (fourOfSame > 0)
            formations.Add(fourOfSame * 4, FormationName.FourOfAKind);

        if (threeOfSame1 > 0)
            formations.AddIfNotNull(formationParts.GetBestThreeOfSame());

        if (twoOfSame1 > 0 && twoOfSame2 > 0 && twoOfSame3 > 0)
            formations.Add(twoOfSame1 * 2 + twoOfSame2 * 2 + twoOfSame3 * 2, FormationName.ThreePairs);

        if (twoOfSame1 > 0 && twoOfSame2 > 0)
            formations.Add(twoOfSame1 * 2 + twoOfSame2 * 2, FormationName.TwoPairs);

        if (twoOfSame1 > 0 && twoOfSame2 > 0)
            formations.Add(twoOfSame1 * 2 + twoOfSame2 * 2, FormationName.TwoPairs);

        if (twoOfSame1 > 0)
            formations.Add(twoOfSame1 * 2, FormationName.Pair);

        formations.AddIfNotNull(formationParts.GetBestFullHouse());

        if (formations.Count <= 0)
            formations.Add(0, FormationName.Nothing);

        var formation = new DiceFormation();
        formation.Values.AddRange(Dices);
        formation.FormationNameAndScore.AddRange(formations);
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