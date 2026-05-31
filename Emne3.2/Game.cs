namespace Emne3._2;

internal class Game
{
    private bool _isRunning = true;
    private int _userScore;
    private int _round;

    public void Run()
    {
        while (_isRunning)
        {
            Console.Clear();
            Console.WriteLine($"Round - {_round + 1}\nScore - {_userScore}");
            Console.WriteLine("1 - stein\n2 - saks\n3 - papir\n4 - Exit");

            if (!TryReadAnswer(out int answer))
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 4.");
                PauseIfInteractive();
                continue;
            }

            if (answer == 4)
            {
                _isRunning = false;
                Console.WriteLine("Good bye!!!");
                PauseIfInteractive();
                break;
            }

            _round++;

            int computerChoice = Random.Shared.Next(1, 4);
            Console.WriteLine($"You chose {AnswerToString(answer)}, computer chose {AnswerToString(computerChoice)}");

            if (answer == computerChoice)
            {
                Console.WriteLine("It's a draw!!!");
            }
            else if (IsUserWinner(answer, computerChoice))
            {
                _userScore++;
                Console.WriteLine("You won!!!");
            }
            else
            {
                Console.WriteLine("You lost!!!");
            }

            PauseIfInteractive();
        }
    }

    private static bool TryReadAnswer(out int answer)
    {
        Console.Write("Choose an option: ");
        var input = Console.ReadLine();
        return int.TryParse(input, out answer) && answer >= 1 && answer <= 4;
    }

    private static bool IsUserWinner(int answer, int choice)
    {
        return (answer == 1 && choice == 2)
               || (answer == 2 && choice == 3)
               || (answer == 3 && choice == 1);
    }

    private static string AnswerToString(int answer)
    {
        return answer switch
        {
            1 => "Stein",
            2 => "Saks",
            3 => "Papir",
            4 => "Exit",
            _ => "Unknown"
        };
    }

    private static void PauseIfInteractive()
    {
        if (Console.IsInputRedirected)
        {
            return;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }
}
