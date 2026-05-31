namespace CurryingAndPartialApplicationIntro;

public class DemoHigherOrder
{
    public static void Run1()
    {
        Console.WriteLine("=== DEMO: Funkcje Wyższego Rzędu ===\n");

        // 1. FUNKCJA WYŻSZEGO RZĘDU - funkcja bierze inną funkcję jako parametr
        Console.WriteLine("1. Funkcja wyższego rzędu (Higher-Order Function):");
        ProcessNumbers(10, (n) => Console.WriteLine($"   Liczba: {n}"));
        Console.WriteLine();

        // 2. APLIKACJA CZĘŚCIOWA - funkcja zwraca nową funkcję z "zapamiętanym" parametrem
        Console.WriteLine("2. Aplikacja częściowa (Partial Application):");
        var multiplyBy5 = MultiplyWithN(5);
        Console.WriteLine($"   5 * 3 = {multiplyBy5(5)}");
        Console.WriteLine($"   5 * 7 = {multiplyBy5(5)}");
        Console.WriteLine();

        // 3. CURRY'ING - funkcja ze Multiple parametrami → łańcuch funkcji jednoparametrowych
        Console.WriteLine("3. Curry'ing (Currying):");
        var curryFunc = CurryAdd();
        var addThen = curryFunc(10);
        var thenMultiply = addThen(5);
        Console.WriteLine($"   ((10 + 5) * 2) = {thenMultiply(2)}");
        Console.WriteLine();
    }

    /// <summary>
    /// Funkcja wyższego rzędu - bierze funkcję callback
    /// </summary>
    private static void ProcessNumbers(int limit, Action<int> callback)
    {
        for (int i = 1; i <= limit; i += 3)
        {
            callback(i);
        }
    }

    /// <summary>
    /// Aplikacja częściowa - zwraca funkcję ze "zapamiętanym" n
    /// </summary>
    private static Func<int, int> MultiplyWithN(int n)
    {
        return m => m * n;
    }

    /// <summary>
    /// Curry'ing - funkcja ze 3 parametrami → 3 zagnieżdżone funkcje jednoparametrowe
    /// </summary>
    private static Func<int, Func<int, Func<int, int>>> CurryAdd()
    {
        return a => b => c => (a + b) * c;
    }
}