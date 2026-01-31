//Random random = new Random(); // Create a Random object to generate random numbers
//int daysUntilExpiration = random.Next(5); // Generate a random number between 0 and 119
int daysUntilExpiration = 12;
int discountPercentage = 8; // Initialize discount percentage

if (daysUntilExpiration == 0)
{
    Console.WriteLine("Your subscription has expired.");
}
else if (daysUntilExpiration == 1)
{
    Console.WriteLine("Your subscription expires within a day!");
    discountPercentage = 20;
} 
else if (daysUntilExpiration <= 5)
{
    Console.WriteLine($"Tour subscription expires in {daysUntilExpiration}");
    discountPercentage = 10;
}
else if (daysUntilExpiration <= 10)
{
    Console.WriteLine("Tour subscription expires soon. Renew now!");
}
if (discountPercentage > 0)
{
    Console.WriteLine($"Renew your subscription today and save {discountPercentage}%!");
}