using Winsoft.Gaming.DiceFormationChecker.FormationNames;
using Winsoft.Gaming.DiceFormationChecker.Formations.Abstracts;
using Winsoft.Gaming.DiceFormationChecker.Scoring;

namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class DiceFormationSix : SpecificFormation
{
    public DiceFormationSix(DiceFormation f) : base(6, f)
    {
    }

    public FormationNameAndScore? GetFormation(FormationNameSixDice name) =>
        base.GetFormation((FormationName)name);
}