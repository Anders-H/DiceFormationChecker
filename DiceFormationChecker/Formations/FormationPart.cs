namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class FormationPart
{
    public int Dice { get; }
    public int Count { get; internal set; }
    public int Score => Dice * Count;

    internal FormationPart(int dice, int count)
    {
        Dice = dice;
        Count = count;
    }
}