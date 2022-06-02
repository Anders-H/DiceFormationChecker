namespace Winsoft.Gaming.DiceFormationChecker.Exceptions;

public class WrongDiceValueException : SystemException
{
    internal WrongDiceValueException() : base("At least one dice value is out of range. Should be 1 to 6.")
    {
    }
}