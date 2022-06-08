# Dice Formation Checker

A class that checks the formation of five or six dice for .NET 6.

```
Install-Package Winsoft.Gaming.DiceFormationChecker
```

## Five dice example

```
var formationCheckerFive = new FormationChecker(3, 3, 4, 4, 4);

foreach (var f in formationCheckerFive.CheckFiveDice().FormationNameAndScore)
{
    Console.WriteLine(f.FormationName);
    Console.WriteLine(f.Score);
}
```

Output:

```
FullHouse
18
ThreeOfAKind
12
Pair
6
```

## Six dice example

```
var formationCheckerSix = new FormationChecker(3, 3, 3, 4, 4, 4);

foreach (var f in formationCheckerSix.CheckSixDice().FormationNameAndScore)
{
    Console.WriteLine(f.FormationName);
    Console.WriteLine(f.Score);
}
```

Output:

```
Villa
21
ThreeOfAKind
12
```