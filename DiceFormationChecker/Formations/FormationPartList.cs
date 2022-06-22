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

    public FormationNameAndScore? GetBestFullHouse()
    {
        var threes1 = GetCount(3);

        if (threes1 == null)
            return null;

        var twos1 = GetCount(3, threes1.Dice) ?? GetCount(2, threes1.Dice);

        if (twos1 == null)
            return null;

        var result1 = new FormationNameAndScore(threes1.Dice * 3 + twos1.Dice * 2, FormationName.FullHouse);

        var threes2 = GetCount(3, threes1.Dice);

        if (threes2 == null)
            return result1;

        var twos2 = GetCount(3, threes2.Dice) ?? GetCount(2, threes2.Dice);

        if (twos2 == null)
            return result1;

        var result2 = new FormationNameAndScore(threes2.Dice * 3 + twos2.Dice * 2, FormationName.FullHouse);

        return result1.Score > result2.Score ? result1 : result2;
    }

    public FormationNameAndScore? GetBestTwoPairs()
    {
        var twos1 = GetByPairScore();

        if (twos1 == null)
            return null;

        var twos2 = GetByPairScore(twos1.Dice);

        return twos2 == null ? null : new FormationNameAndScore(twos1.PairScore + twos2.PairScore, FormationName.TwoPairs);
    }

    private FormationPart? GetCount(int count) =>
        this.Where(x => x.Count == count)
            .OrderByDescending(x => x.Score)
            .FirstOrDefault();

    private FormationPart? GetCount(int count, int notDice) =>
        this.Where(x => x.Count == count && x.Dice != notDice)
            .OrderByDescending(x => x.Score)
            .FirstOrDefault();

    private FormationPart? GetByPairScore() =>
        this.Where(x => x.Count >= 2)
            .OrderByDescending(x => x.PairScore)
            .FirstOrDefault();

    private FormationPart? GetByPairScore(int notDice) =>
        this.Where(x => x.Count >= 2 && x.Dice != notDice)
            .OrderByDescending(x => x.PairScore)
            .FirstOrDefault();
}