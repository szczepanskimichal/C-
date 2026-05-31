namespace KlasserStatic;

public class Person
{
    //public static string _name { get; }
    //public static int _age { get; }
    private readonly string _name;
    private readonly int _age;
    private static int _personCount=0;
    public Person(string name, int age)
    {
        _name = name;
        _age = age;
        _personCount++;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Age: {_age}");
        Console.WriteLine($"Person Count: {_personCount}");
    }
}