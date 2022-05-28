namespace Winsoft.Gaming.DiceFormationChecker;

public class DiceFormation
{
    public List<int> DicesInFormationIndices { get; }
    public int DiceSumValue { get; internal set; }
    public int Score { get; internal set; }
    public FormationName FormationName { get; internal set; }
}