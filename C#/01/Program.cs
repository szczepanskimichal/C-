Console.WriteLine("Hello, World!");

var p1 = new Person("John", "Doe", new DateOnly(1990, 1, 1));
var p2 = new Person("Mia", "Doe", new DateOnly(1990, 1, 2));
p1.Pets.Add(new Cat("Mija"));
p1.Pets.Add(new Dog("John"));
p2.Pets.Add(new Dog("lsdkalsk"));
p2.Pets.Add(new Cat("Marysia"));

List<Person> people = new() { p1, p2 };
Console.WriteLine(people.Count);
foreach (var person in people)
{
    Console.WriteLine($"{person.First} {person.Last} (born {person.BirthDate:yyyy-MM-dd})");
    if (person.Pets == null || person.Pets.Count == 0)
    {
        Console.WriteLine("  No pets");
        continue;
    }

    foreach (var pet in person.Pets)
    {
        Console.WriteLine($" - {pet.GetType().Name}: {pet.First} => {pet.MakeNoise()}");
    }
}

public class Person
{
    public Person(string firstName, string lastName, DateOnly birthDate)
    {
        First = firstName;
        Last = lastName;
        BirthDate = birthDate;
        Pets = new List<Pet>();
    }

    public string First { get; }
    public string Last { get; }
    public DateOnly BirthDate { get; }
    public List<Pet> Pets { get; }
}

public abstract class Pet
{
    protected Pet(string firstName)
    {
        First = firstName;
    }

    public string First { get; }
    public abstract string MakeNoise();
}

public class Cat : Pet
{
    public Cat(string firstName) : base(firstName) { }

    public override string MakeNoise() => "Meow!";
}

public class Dog : Pet
{
    public Dog(string firstName) : base(firstName)
    {
    }

    public override string MakeNoise() => "Woof!";
}

