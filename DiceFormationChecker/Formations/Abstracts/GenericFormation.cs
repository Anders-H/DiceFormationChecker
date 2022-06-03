using Winsoft.Gaming.DiceFormationChecker.Scoring;

namespace Winsoft.Gaming.DiceFormationChecker.Formations.Abstracts;

public abstract class GenericFormation
{
    public List<int> Values { get; }
    public List<FormationNameAndScore> FormationNameAndScore { get; }

    protected GenericFormation()
    {
        Values = new List<int>();
        FormationNameAndScore = new List<FormationNameAndScore>();
    }
}