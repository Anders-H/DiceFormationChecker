using Winsoft.Gaming.DiceFormationChecker.Formations.Abstracts;

namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class DiceFormation : GenericFormation
{
    public int DiceSumValue => Values.Sum();

    public int SumOne => Values.Where(x => x == 1).Sum();
    public int SumTwo => Values.Where(x => x == 2).Sum();
    public int SumThree => Values.Where(x => x == 3).Sum();
    public int SumFour => Values.Where(x => x == 4).Sum();
    public int SumFive => Values.Where(x => x == 5).Sum();
    public int SumSix => Values.Where(x => x == 6).Sum();
}