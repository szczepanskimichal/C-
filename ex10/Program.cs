/*
Console.WriteLine("a" == "a");
Console.WriteLine("a" == "A");
Console.WriteLine(1 == 2);

string myValue = "a";
Console.WriteLine(myValue == "a");

string value1="a";
string value2="A ";
Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());*/
/*
string pangram = "The quick brown fox jumps over the lazy dog";
Console.WriteLine(pangram.Contains("fox")==false);
Console.WriteLine(pangram.Contains("cat"));*/

using System.Collections.Concurrent;
/*
Random coin = new Random();
//int flip=coin.Next(0,2);
//Console.WriteLine((flip==0)?"heads":"tails");
Console.WriteLine((coin.Next(0, 2)==0) ? "heads" : "tails");
*/
string perrmision ="Admin | Manager";
int level = 135;
if (perrmision.Contains("Admin"))
{
    if (level==55)
    {
        Console.WriteLine("Welcomen SUPER Admin with full access");
    }
    else
    {
        Console.WriteLine("Welcome Admin");
    }
}
else if (perrmision.Contains("Manager"))
{
    if(level>=20)
    {
        Console.WriteLine("Contact an Admin for access.");
    }
    else
    {
        Console.WriteLine("You do not have sufficient privileges.");
    }
}
else
{
    Console.WriteLine("You do not have sufficient privileges.");
}