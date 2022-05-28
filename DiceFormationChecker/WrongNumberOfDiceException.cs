namespace Winsoft.Gaming.DiceFormationChecker;

public class WrongNumberOfDiceException : SystemException
{
    internal WrongNumberOfDiceException(int actualNumber) : base($"Expected 5 or 6 dice, got {actualNumber}.")
    {
    }
}