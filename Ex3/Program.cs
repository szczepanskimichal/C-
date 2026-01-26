using System;

class Program
{
    static void Main()
    {
        Random dice = new Random();
        int roll1= dice.Next();
        int roll2 = dice.Next(101);
        int roll3 = dice.Next(50, 101);
        Console.WriteLine(roll1);
        Console.WriteLine(roll2);
        Console.WriteLine(roll3);
    }
}
















