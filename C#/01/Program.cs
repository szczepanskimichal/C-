using _01;

Console.WriteLine("Hello, World!");

var people = ExercisesData.GetSampleData();

Console.WriteLine(people.Count);
foreach (var person in people)
{
    Console.WriteLine(person);
    if (person.Pets.Count == 0)
    {
        Console.WriteLine("  No pets");
        continue;
    }

    foreach (var pet in person.Pets)
    {
        Console.WriteLine($" - {pet}");
    }
}
