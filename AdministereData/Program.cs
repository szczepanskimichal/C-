string? readResult;
bool validEntry = false;
int numericValue = 0;
bool validNumber = false;

Console.WriteLine("Read a string");


do
{
    readResult=Console.ReadLine()?.Trim();
    if (string.IsNullOrEmpty(readResult))
    {
            Console.WriteLine("Invalid input, please try again");


        if (readResult.Length >= 3)
        {
            validEntry = true;
        }
        else
        {
            Console.WriteLine("Invalid input, please try again");
        }
        if (int.TryParse(readResult,  out numericValue))
        {
            validNumber = true;
       //     validEntry = true;
            Console.WriteLine($"Parsing successful, the number is {numericValue}");
        }
    }
} while (readResult == null);

