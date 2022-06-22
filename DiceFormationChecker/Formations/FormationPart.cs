namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class FormationPart
{
    public int Dice { get; }
    public int Count { get; internal set; }

    internal FormationPart(int dice, int count)
    {
        Dice = dice;
        Count = count;
    }

    public int Score =>
        Dice * Count;

    public int PairScore =>
        Count < 2
            ? Dice * 2
            : 0;
}