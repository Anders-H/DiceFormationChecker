using System.Windows.Markup;

namespace Winsoft.Gaming.DiceFormationChecker;

public class DiceFormation
{
    public List<int> Values { get; }
    public List<int> DicesInFormationIndices { get; }
    public int Score { get; }
    public FormationName FormationName { get; }

    public int DiceSumValue => Values.Sum();

    public int SumOne => Values.Where(x => x == 1).Sum();
    public int SumTwo => Values.Where(x => x == 2).Sum();
    public int SumThree => Values.Where(x => x == 3).Sum();
    public int SumFour => Values.Where(x => x == 4).Sum();
    public int SumFive => Values.Where(x => x == 5).Sum();
    public int SumSix => Values.Where(x => x == 6).Sum();

    public DiceFormation(int score, FormationName formationName)
    {
        Values = new List<int>();
        DicesInFormationIndices = new List<int>();
        Score = score;
        FormationName = formationName;
    }
}