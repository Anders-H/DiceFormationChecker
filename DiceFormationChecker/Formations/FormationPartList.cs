namespace Winsoft.Gaming.DiceFormationChecker.Formations;

public class FormationPartList : List<FormationPart>
{
    public void Add(int dice, int count) =>
        base.Add(new FormationPart(dice, count));
}