string[][] userEnteredValues = new string[][]
{
    // Tablica wejść: trzy zestawy wartości do przetworzenia
    // 1: wszystkie poprawne (1,2,3)
    // 2: zawiera niepoprawny tekst "two" -> powinien wywołać FormatException w Process1
    // 3: zawiera "0" -> powinien wywołać DivideByZeroException w Process1
    new string[] { "1", "2", "3"},
    new string[] { "1", "two", "3"},
    new string[] { "0", "1", "2"}
};

try
{
    // Wywołujemy główną procedurę, która iteruje przez powyższe zestawy
    Workflow1(userEnteredValues);
    // Jeśli żaden DivideByZeroException nie wypłynie poza Workflow1, to trafimy tutaj
    Console.WriteLine("'Workflow1' completed successfully.");

}
catch (DivideByZeroException ex)
{
    // Tu łapiemy tylko DivideByZeroException, czyli błąd zgłaszany w Process1 gdy napotka 0
    // Ten wyjątek przepływa poza Workflow1 (bo Workflow1 łapie tylko FormatException wewnątrz pętli)
    Console.WriteLine("An error occurred during 'Workflow1'.");
    Console.WriteLine(ex.Message);
}

static void Workflow1(string[][] userEnteredValues)
{
    // Workflow1 przechodzi po każdym wierszu danych (każdy wiersz to tablica stringów)
    foreach (string[] userEntries in userEnteredValues)
    {
        try
        {
            // Dla każdego wiersza wywołujemy Process1 — tu wykonywane są testy parsowania i dzielenia
            Process1(userEntries);
            // Jeśli Process1 nie rzuci wyjątku, raportujemy sukces dla tej próbki
            Console.WriteLine("'Process1' completed successfully.");
            Console.WriteLine();
        }
        catch (FormatException ex)
        {
            // Jeśli Process1 napotka niepoprawny format (np. "two"), rzuci FormatException
            // Tutaj go łapiemy i informujemy użytkownika, ale nie przerywamy całej Workflow1
            Console.WriteLine("'Process1' encountered an issue, process aborted.");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            // Ważne: nie przerywamy pętli — Workflow1 kontynuuje kolejne wiersze danych
        }
        // Uwaga: DivideByZeroException NIE jest tu łapany, więc jeśli Process1 ją rzuci,
        // to przepłynie ona poza Workflow1 do bloku try/catch w głównym kodzie (patrz wyżej).
    }
}

static void Process1(String[] userEntries)
{
    // Process1 sprawdza kazdy string w podanym wierszu:
    // - czy można go sparsować na int (int.TryParse)
    // - czy sparsowana wartość nie jest 0 (bo następuje dzielenie 4 / value)

    int valueEntered;

    foreach (string userValue in userEntries)
    {
        // int.TryParse próbuje przekonwertować userValue na int
        // Zwraca true i ustawia valueEntered jeśli konwersja się powiodła, inaczej false
        bool integerFormat = int.TryParse(userValue, out valueEntered);

        if (integerFormat == true)
        {
            // Jeśli mamy prawidłowy integer, sprawdzamy, czy to nie jest zero
            if (valueEntered != 0)
            {
                // "checked" wymusza rzucenie OverflowException gdy dochodzi do przepełnienia.
                // Tutaj nie jest spodziewane, ale jest to zgodne z przykładem: wykonujemy dzielenie testowe
                checked
                {
                    int calculatedValue = 4 / valueEntered; // operacja arytmetyczna do testu poprawności
                }
            }
            else
            {
                // Gdy wartość to zero, nie chcemy kontynuować — rzucamy DivideByZeroException
                // To jest specjalny wyjątek, który propaguje się poza Workflow1 (ponieważ tam go nie łapiemy)
                throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
            }
        }
        else
        {
            // Jeśli parsowanie się nie powiodło (np. "two"), rzucamy FormatException
            // Workflow1 ma blok catch(FormatException) i dzięki temu obsługujemy ten błąd lokalnie
            throw new FormatException("Invalid data. User input values must be valid integers.");
        }
    }
}