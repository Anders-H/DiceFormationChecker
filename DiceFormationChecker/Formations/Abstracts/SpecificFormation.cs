using Winsoft.Gaming.DiceFormationChecker.Exceptions;
using Winsoft.Gaming.DiceFormationChecker.FormationNames;
using Winsoft.Gaming.DiceFormationChecker.Scoring;

namespace Winsoft.Gaming.DiceFormationChecker.Formations.Abstracts;

public abstract class SpecificFormation : GenericFormation
{
    public int DiceSumValue { get; }
    public int SumOne { get; }
    public int SumTwo { get; }
    public int SumThree { get; }
    public int SumFour { get; }
    public int SumFive { get; }
    public int SumSix { get; }

    protected SpecificFormation(int diceCount, DiceFormation f)
    {
        if (f.Values.Count != diceCount)
            throw new WrongNumberOfDiceException(f.Values.Count);

        Values.AddRange(f.Values);

        foreach (var formationNameAndScore in f.FormationNameAndScore.Where(formationNameAndScore => Enum.IsDefined(typeof(FormationNameFiveDice), formationNameAndScore.FormationName)))
            FormationNameAndScore.Add(new FormationNameAndScore(formationNameAndScore.Score, formationNameAndScore.FormationName));

        DiceSumValue = f.DiceSumValue;

        SumOne = f.SumOne;
        SumTwo = f.SumTwo;
        SumThree = f.SumThree;
        SumFour = f.SumFour;
        SumFive = f.SumFive;
        SumSix = f.SumSix;
    }
}