using Winsoft.Gaming.DiceFormationChecker.Exceptions;
using Winsoft.Gaming.DiceFormationChecker.FormationNames;
using Winsoft.Gaming.DiceFormationChecker.Scoring;

namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class DiceFormationSix
{
    public List<int> Values { get; }
    public List<FormationNameAndScore> FormationNameAndScore { get; }
    public int DiceSumValue { get; }
    public int SumOne { get; }
    public int SumTwo { get; }
    public int SumThree { get; }
    public int SumFour { get; }
    public int SumFive { get; }
    public int SumSix { get; }

    public DiceFormationSix(DiceFormation f)
    {
        if (f.Values.Count != 6)
            throw new WrongNumberOfDiceException(f.Values.Count);

        Values = new List<int>();
        Values.AddRange(f.Values);

        FormationNameAndScore = new List<FormationNameAndScore>();

        foreach (var formationNameAndScore in f.FormationNameAndScore.Where(formationNameAndScore => Enum.IsDefined(typeof(FormationNameSixDice), formationNameAndScore.FormationName)))
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