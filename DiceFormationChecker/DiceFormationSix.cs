namespace Winsoft.Gaming.DiceFormationChecker;

public class DiceFormationSix
{
    public List<int> Values { get; }
    public List<int> DicesInFormationIndices { get; }
    public int Score { get; }
    public FormationNameSixDice FormationName { get; }
    public int DiceSumValue { get; }
    public int SumOne { get; }
    public int SumTwo { get; }
    public int SumThree { get; }
    public int SumFour { get; }
    public int SumFive { get; }
    public int SumSix { get; }

    public DiceFormationSix(DiceFormation f)
    {
        if (f.Values.Count != 6 || f.DicesInFormationIndices.Count > 6)
            throw new WrongNumberOfDiceException(f.Values.Count);

        var formationName = (FormationNameSixDice)f.FormationName;

        if (!Enum.IsDefined(typeof(FormationNameSixDice), formationName))
            throw new SystemException("Unexpected formation.");

        Values = new List<int>();
        Values.AddRange(f.Values);

        DicesInFormationIndices = new List<int>();
        DicesInFormationIndices.AddRange(f.DicesInFormationIndices);

        DiceSumValue = f.DiceSumValue;

        SumOne = f.SumOne;
        SumTwo = f.SumTwo;
        SumThree = f.SumThree;
        SumFour = f.SumFour;
        SumFive = f.SumFive;
        SumSix = f.SumSix;

        Score = f.Score;

        FormationName = (FormationNameSixDice)f.FormationName;
    }
}