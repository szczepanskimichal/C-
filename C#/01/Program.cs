// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// string name = "Alice";
// string greeting = $"Hello, {name}!";
// Console.WriteLine(greeting);
// string firstName = "John";
// string secondName = "      Doe.     ";
// secondName=secondName.TrimStart();
// string fullGreeting = $"Hello, {firstName} {secondName.TrimEnd()}!";
// Console.WriteLine(fullGreeting);
// Console.WriteLine("hello " + name + " " + secondName);

// int a = 5;
// int b = 1;
// // int sum = checked(a + b);
// // System.Console.WriteLine(sum);
// int c = a+b;
// bool test = c > 10;
// if(test)
// {
//   System.Console.WriteLine("Sum is greater than 10");
// } 
// else
// {
//   System.Console.WriteLine("Sum is 10 or less");
// }

// int conunter = 0;
// while (conunter < 5)
// {
//   conunter++;
//   System.Console.WriteLine("Counter: " + conunter);
// }

// for (int i=0; i <5; i++)
// {
//   System.Console.WriteLine("Iteration: " + i);
// }

// for (int row=1; row<11; row++)
// {
//   for (char column = 'a'; column < 'k' + 10; column++) 
//   {
//     System.Console.Write($"The cell is ({row}, {column}) ");
    
//   }
// }
// var names = new List<string> { "<name>", "Bob", "Charlie" };
// names.Add("Diana");
// names.Add("Eve");
// names.Remove("<name>");
// foreach(var name in names)
// {
//   System.Console.WriteLine($"Hello, {name.ToUpper()}!");
// }

// WorkingWithIntegers();
// WorkingWithIntegers();
// ShowTupleExample();

// void WorkingWithIntegers()
// {
//     int a = 18;
//     int b = 6;

//     // addition
//     int sum = a + b;
//     System.Console.WriteLine($" {a} + {b} = {sum} ");

//     // subtraction
//     int difference = a - b;
//     System.Console.WriteLine($" {a} - {b} = {difference} ");

//     // multiplication
//     int product = a * b;
//     System.Console.WriteLine($" {a} * {b} = {product} ");

//     // division
//     int quotient = a / b;
//     System.Console.WriteLine($" {a} / {b} = {quotient} ");

//     // modulus
//     int remainder = 19 % b;
//     System.Console.WriteLine($" 19 % {b} = {remainder} ");
// }

// void ShowTupleExample()
// {
//     var point = (X: 1, Y: 2);
//     var slope = (double)point.Y / point.X;
//     System.Console.WriteLine($"{point} The slope is {slope}");
// }

var names = new List<string> { "Cziczi", "Bob", "Charlie" };

// names = [..names, "Diana", "Eve"]; 
names.Sort();


foreach(var name in names)
{
    System.Console.WriteLine($"Hello, {name.ToUpper()}!");
}
// names.Add("Diana");
// names.Add("Eve");
// names.Remove("Cziczi");
// names[0] = "Mija";
// System.Console.WriteLine(names[2]);
// System.Console.WriteLine(names[0]);
// System.Console.WriteLine(names[^2]);
// System.Console.WriteLine(names.Count);
// System.Console.WriteLine(names.Count - 1);