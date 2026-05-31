namespace Emne3._1;

public class Oppgave315A
{
    public static void Run()
    {
        Console.WriteLine("Guess the number");
        var random = new Random();
        var number = random.Next(1, 100);
        bool isCorrect = false;

        while (isCorrect!=true)
        {
            isCorrect = IsCorrect(number, isCorrect);
        }
        
        
    }

    private static bool IsCorrect(int number, bool isCorrect)
    {
        string input=Console.ReadLine();
        int numberToGuess = int.Parse(input);
        if (numberToGuess>number)
        {
            Console.WriteLine("The number is to high");
        }
        else if(numberToGuess < number)
        {
            Console.WriteLine("The number is to low");
        }
        else
        {
            Console.WriteLine("You guessed the number");
            isCorrect=true;
        }

        return isCorrect;
    }
}