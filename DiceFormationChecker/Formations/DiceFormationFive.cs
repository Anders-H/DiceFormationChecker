using Winsoft.Gaming.DiceFormationChecker.FormationNames;
using Winsoft.Gaming.DiceFormationChecker.Formations.Abstracts;
using Winsoft.Gaming.DiceFormationChecker.Scoring;

namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class DiceFormationFive : SpecificFormation
{
    internal DiceFormationFive(DiceFormation f) : base(5, f)
    {
    }

    public FormationNameAndScore? GetFormation(FormationNameFiveDice name) =>
        GetFormation((FormationName)name);
}