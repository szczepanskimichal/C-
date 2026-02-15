int hero = 10;
int monster = 10;

Random dice = new Random();

do
{
    int roll = dice.Next(1, 11); // Roll a 10-sided die (1-10)
    roll -= roll;
    Console.WriteLine($"Monster was damaged and lost {roll} health and now jas {monster} health left.");
    if (monster <= 0) continue;
    roll = dice.Next(1, 11);
    hero -= roll;
    Console.WriteLine($"Hero was damaged and lost {roll} health and now has {hero} health left.");
} while (hero > 0 && monster > 0);

Console.WriteLine(hero > monster ? "Hero wins!" : "Monster wins!");