using Winsoft.Gaming.DiceFormationChecker.FormationNames;
using Winsoft.Gaming.DiceFormationChecker.Scoring;

namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class FormationPartList : List<FormationPart>
{
    public void Add(int dice, int count) =>
        Add(new FormationPart(dice, count));

    public FormationNameAndScore? GetBestTower()
    {
        var four = GetCount(4);

        if (four == null)
            return null;

        var two = GetCount(2, four.Dice);

        return two == null
            ? null
            : new FormationNameAndScore(four.Score + two.Score, FormationName.Tower);
    }

    public FormationNameAndScore? GetBestVilla()
    {
        var threes1 = GetCount(3);

        if (threes1 == null)
            return null;

        var threes2 = GetCount(3, threes1.Dice);

        return threes2 == null
            ? null
            : new FormationNameAndScore(threes1.Score + threes2.Score, FormationName.Villa);
    }

    public FormationNameAndScore? GetBestThreeOfSame()
    {
        var threes = GetCount(3);

        return threes == null
            ? null
            : new FormationNameAndScore(threes.Score, FormationName.ThreeOfAKind);
    }

    private FormationPart? GetCount(int count) =>
        this.Where(x => x.Count == count)
            .OrderByDescending(x => x.Score)
            .FirstOrDefault();

    private FormationPart? GetCount(int count, int notDice) =>
        this.Where(x => x.Count == count && x.Dice != notDice)
            .OrderByDescending(x => x.Score)
            .FirstOrDefault();
}