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

        if (diceCount == 5)
        {
            foreach (
                var formationNameAndScore
                in f.FormationNameAndScore
                    .Where(
                        formationNameAndScore =>
                            Enum.IsDefined(typeof(FormationNameFiveDice), (FormationNameFiveDice)formationNameAndScore.FormationName)
                    )
            )
                FormationNameAndScore.Add(new FormationNameAndScore(formationNameAndScore.Score, formationNameAndScore.FormationName));
        }
        else if (diceCount == 6)
        {
            foreach (
                var formationNameAndScore
                in f.FormationNameAndScore
                    .Where(
                        formationNameAndScore =>
                            Enum.IsDefined(typeof(FormationNameSixDice), (FormationNameSixDice)formationNameAndScore.FormationName)
                    )
            )
                FormationNameAndScore.Add(new FormationNameAndScore(formationNameAndScore.Score, formationNameAndScore.FormationName));
        }

        DiceSumValue = f.DiceSumValue;

        SumOne = f.SumOne;
        SumTwo = f.SumTwo;
        SumThree = f.SumThree;
        SumFour = f.SumFour;
        SumFive = f.SumFive;
        SumSix = f.SumSix;
    }

    public FormationNameAndScore? GetFormation(FormationName name) =>
        FormationNameAndScore
            .OrderByDescending(x => x.Score)
            .FirstOrDefault(formationNameAndScore => formationNameAndScore.FormationName == name);
}