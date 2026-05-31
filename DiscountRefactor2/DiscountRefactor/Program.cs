using DiscountRefactor;

while (true)
{
    Console.WriteLine("Trykk på en tast!");
    var key = Console.ReadKey(true).Key;
    Console.WriteLine($"Du trykket på {key}");
    try
    {
        A.Run();
    }
    catch (InvalidCodeAppliedException e)
    {
        Console.WriteLine($"Ugyldig kode! {e.Message}");
    }
    catch (SomethingElseException)
    {

    }
}

