using Winsoft.Gaming.DiceFormationChecker.FormationNames;

namespace Winsoft.Gaming.DiceFormationChecker.Scoring;

public class FormationNameAndScore
{
    public int Score { get; }
    public FormationName FormationName { get; }

    public FormationNameAndScore(int score, FormationName formationName)
    {
        Score = score;
        FormationName = formationName;
    }
}