using Winsoft.Gaming.DiceFormationChecker.FormationNames;

namespace Winsoft.Gaming.DiceFormationChecker.Scoring;

public class FormationNameAndScoreList : List<FormationNameAndScore>
{
    public void Add(int score, FormationName formationName) =>
        Add(new FormationNameAndScore(score, formationName));

    public void AddIfNotNull(FormationNameAndScore? f)
    {
        if (f != null)
            Add(f);
    }
}