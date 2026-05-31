namespace CurryingAndPartialApplicationIntro;

public static class Oppgaver
{
    public static void Run()
    {
        Console.WriteLine("Oppgave 1:");
        // Basic lambdas: single-argument transforms and predicates.
        Func<int, int> doubleNumber = x => x * 2;
        Console.WriteLine(doubleNumber(5));

        Console.WriteLine("Oppgave 2:");
        Func<string, int> textLength = text => text.Length;
        Console.WriteLine(textLength("Hei"));

        Console.WriteLine("Oppgave 3:");
        Func<int, bool> isEven = x => x % 2 == 0;
        Console.WriteLine(isEven(2));

        Console.WriteLine("Oppgave 4:");
        // Higher-order function: pass behavior (Action) into another method.
        Execute(() => Console.WriteLine("Hello"));

        Console.WriteLine("Oppgave 5:");
        var numbers = new List<int> { 5, 12, 20, 3 };
        var filtered = Filter(numbers, n => n > 10);
        Console.WriteLine(string.Join(", ", filtered));

        Console.WriteLine("Oppgave 6:");
        Func<string, string> toUppercase = text => text.ToUpper();
        Console.WriteLine(ApplyFormatter("hei", toUppercase));

        Console.WriteLine("Oppgave 7:");
        Console.WriteLine(Add(2, 3));

        // Currying: function that returns another function.
        Func<int, Func<int, int>> addCurried = x => y => x + y;
        Console.WriteLine(addCurried(2)(3));

        Console.WriteLine("Oppgave 8:");
        // Partial application: freeze first argument (multiply by 2).
        Func<int, Func<int, int>> multiply = x => y => x * y;
        var doubleAgain = multiply(2);
        Console.WriteLine(doubleAgain(5));

        Console.WriteLine("Oppgave 9:");
        Func<int, Func<int, bool>> isAbove = limit => value => value > limit;
        var isAdult = isAbove(18);
        Console.WriteLine(isAdult(20));
        Console.WriteLine(isAdult(15));

        Console.WriteLine("Oppgave 10:");
        Func<decimal, Func<decimal, decimal>> applyDiscount =
            percentage => price => price - (price * percentage / 100);
        var studentDiscount = applyDiscount(20);
        Console.WriteLine(studentDiscount(100));

        Console.WriteLine("Oppgave 11:");
        Func<string, Func<string, string>> addPrefix = prefix => text => prefix + text;
        var warningPrefix = addPrefix("WARNING: ");
        Console.WriteLine(warningPrefix("Disk full"));

        Console.WriteLine("Oppgave 12:");
        Func<int, Func<List<int>, List<int>>> filterAbove =
            limit => list => list.Where(x => x > limit).ToList();
        var filterAdults = filterAbove(18);
        Console.WriteLine(string.Join(", ", filterAdults(new List<int> { 10, 20, 30 })));

        Console.WriteLine("Oppgave 13:");
        Func<string, Action<string>> createLogger =
            prefix => message => Console.WriteLine($"[{prefix}] {message}");
        var errorLogger = createLogger("ERROR");
        errorLogger("Database failed");

        Console.WriteLine("Oppgave 14:");
        Func<int, Func<DateTime, bool>> isAfterHour = hour => time => time.Hour > hour;
        var isAfterOpening = isAfterHour(8);
        Console.WriteLine(isAfterOpening(new DateTime(2026, 1, 1, 7, 0, 0)));
        Console.WriteLine(isAfterOpening(new DateTime(2026, 1, 1, 10, 0, 0)));

        Console.WriteLine("Oppgave 15:");
        Func<decimal, Func<Product, bool>> costsMoreThan =
            limit => product => product.Price > limit;
        var products = new List<Product>
        {
            new("Mouse", 200),
            new("Laptop", 5000),
            new("Keyboard", 800)
        };
        // Reusing a predicate factory in a real-ish domain example.
        var expensiveProducts = products.Where(costsMoreThan(1000)).ToList();
        foreach (var product in expensiveProducts)
        {
            Console.WriteLine(product.Name);
        }

        Console.WriteLine("Oppgave 16:");
        Func<int, Func<Booking, bool>> minimumDuration =
            hours => booking => booking.DurationHours >= hours;
        var longBookings = minimumDuration(2);
        var booking1 = new Booking(new DateTime(2026, 1, 1, 10, 0, 0), new DateTime(2026, 1, 1, 13, 0, 0));
        var booking2 = new Booking(new DateTime(2026, 1, 1, 10, 0, 0), new DateTime(2026, 1, 1, 11, 0, 0));
        Console.WriteLine(longBookings(booking1));
        Console.WriteLine(longBookings(booking2));

        Console.WriteLine("Oppgave 17:");
        Func<decimal, Func<decimal, decimal>> addVat =
            vatPercentage => price => price + (price * vatPercentage / 100);
        var norwegianVat = addVat(25);
        Console.WriteLine(norwegianVat(100));

        Console.WriteLine("Oppgave 18:");
        Func<string, Func<string, bool>> containsText =
            searchText => text => text.Contains(searchText);
        var containsError = containsText("ERROR");
        Console.WriteLine(containsError("ERROR: Something failed"));
        Console.WriteLine(containsError("All good"));

        Console.WriteLine("Oppgave 19:");
        Func<int, Func<int, bool>> isDivisibleBy =
            divisor => number => number % divisor == 0;
        var isEvenAgain = isDivisibleBy(2);
        Console.WriteLine(isEvenAgain(10));
        Console.WriteLine(isEvenAgain(7));

        Console.WriteLine("Oppgave 20:");
        // Function factory: returns formatter configured by start/end tags.
        var htmlFormatter = CreateFormatter("<b>", "</b>");
        Console.WriteLine(htmlFormatter("Hei"));
    }

    private static void Execute(Action action)
    {
        // Simple pipeline around callback execution.
        Console.WriteLine("Starting...");
        action();
        Console.WriteLine("Done.");
    }

    private static List<int> Filter(List<int> numbers, Func<int, bool> predicate)
    {
        return numbers.Where(predicate).ToList();
    }

    private static string ApplyFormatter(string text, Func<string, string> formatter)
    {
        return formatter(text);
    }

    private static int Add(int x, int y)
    {
        return x + y;
    }

    private static Func<string, string> CreateFormatter(string start, string end)
    {
        // Captures start/end in closure and returns reusable formatter.
        return text => start + text + end;
    }

    private record Product(string Name, decimal Price);

    private record Booking(DateTime Start, DateTime End)
    {
        public double DurationHours => (End - Start).TotalHours;
    }
}