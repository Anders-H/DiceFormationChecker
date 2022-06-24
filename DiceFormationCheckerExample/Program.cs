using Winsoft.Gaming.DiceFormationChecker;

var formationCheckerFive = new FormationChecker(3, 3, 4, 4, 4);

foreach (var f in formationCheckerFive.CheckFiveDice().FormationNameAndScore.OrderByDescending(x => x.Score))
{
    Console.WriteLine(f.FormationName);
    Console.WriteLine(f.Score);
}

Console.WriteLine();

var formationCheckerSix = new FormationChecker(3, 3, 3, 4, 4, 4);

foreach (var f in formationCheckerSix.CheckSixDice().FormationNameAndScore.OrderByDescending(x => x.Score))
{
    Console.WriteLine(f.FormationName);
    Console.WriteLine(f.Score);
}