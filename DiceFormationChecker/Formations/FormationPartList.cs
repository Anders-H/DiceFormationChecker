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