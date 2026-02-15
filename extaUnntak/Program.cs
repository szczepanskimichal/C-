using System;
Console.Write("enter the lower bound: ");
int lowerBond = int.Parse(Console.ReadLine());

Console.WriteLine("enter the upper bound: ");
int upperBond = int.Parse(Console.ReadLine());

decimal averageValue=0;
bool exit = false;

// calculating the average of even numbers between lowerBond and upperBond
//averageValue= AverageOfEvenNumbers(lowerBond, upperBond);
// displaying the result
//Console.WriteLine($"the average of even numbers between {lowerBond} and {upperBond} is: {averageValue}");

//Console.ReadLine();


do
{
    try
    {
        averageValue= AverageOfEvenNumbers(lowerBond, upperBond);
        Console.WriteLine($"The average of even numbers between {lowerBond} and {upperBond} is {averageValue}.");
        exit = true;
    }
    catch (ArgumentOutOfRangeException exception)
    {
        Console.WriteLine("an error occurred: " + exception.Message);
        Console.WriteLine(exception.Message);
        Console.WriteLine($"the upper bound must be greater than {lowerBond}");
        Console.Write("enter a new upper or enter Exit to quit");
        string userResponse = Console.ReadLine();
        if (userResponse != null && userResponse.ToLower().Contains("exit"))
        {
            exit = true;
        }
        else
        {
            upperBond=int.Parse(userResponse);
            exit = false;
        }
        
    }
} while (exit == false);

Console.Read();


static decimal AverageOfEvenNumbers(int lowerBond, int upperBond)
{
    if (lowerBond >= upperBond)
    {
        throw new ArgumentOutOfRangeException("upperBound", "ArgumentOutOfRangeException: upper bound must be greater than lower bound.");
    }
    int sum = 0;
    int count = 0;
    decimal average = 0;
    for(int i = lowerBond; i <= upperBond; i++)
    {
        if(i %2 == 0)
        {
            sum += i;
            count++;
        }

    
    }
    average = (decimal)sum / count;
    return average;
}