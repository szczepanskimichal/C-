namespace CurryingAndPartialApplicationIntro;

/// <summary>
/// Przykłady curry'ingu i aplikacji częściowej
/// </summary>
public class DemoCurryingAndPartialApplication
{
    public static void Run1()
    {
        // Curry'ing: funkcja z 2 parametrami → łańcuch funkcji jednoparametrowych
        Func<int, Func<int, int>> add = x => y => x + y;

        var add2 = add(2);      // Zwraca funkcję która doda 2
        var result = add2(3);   // Zwraca 5
        
        Console.WriteLine($"Curry Add: 2 + 3 = {result}");
    }
}