/*
string[] names= {"Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };
for (int i = names.Length -1; i >= 0; i--)
{
    //Console.WriteLine(i);
    Console.WriteLine($"{i}: {names[i]}");
}

string[] names2 = { "Alex", "Eddie", "David", "Michael" };
for (int i = names2.Length - 1; i >= 0; i--)
{
    Console.WriteLine(names2[i]);
}
*/
/*
string[] names = { "Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };
//foreach (var name in names)
for (int i = 0; i < names.Length; i++)

    if (names[i] == "Gregor") names[i] = "mija";
    foreach (var name in names )
    {
        Console.WriteLine(name);
    }
    */
    
for (int i = 1; i < 101; i++)
{
    if((i%3==0) && (i%5==0))
        Console.WriteLine("FizzBuzz");
    else if (i%3==0)
        Console.WriteLine("Fizz");
    else if (i%5==0)
        Console.WriteLine("Buzz");
    else
        Console.WriteLine(i);
}