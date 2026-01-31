//string[] fraudulentOrderIDs = new string[3]; // Array to hold fraudulent order IDs
//fraudulentOrderIDs[0] = ;
//fraudulentOrderIDs[1] = ;
//fraudulentOrderIDs[2] =;
//fraudulentOrderIDs[3] = "D789";
/*
string[] fraudulentOrderIDs=["A121", "B456", "C789"];
Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "A000MijaCziczi";
Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");
*/
/*
string[] names = {"Alice", "Bob", "Charlie"};
foreach (string name in names)
{
    Console.WriteLine(name);
}
*/
/*
int[] inventory = {200, 450, 700, 175, 250};
int sum = 0;
int bin = 0;
foreach (int items in inventory)
{
    sum += items;
    bin++;
    Console.WriteLine($"Bin: {bin}: {items} items (Running Total: {sum})");
}

Console.WriteLine($"We have {sum} items in inventory.");
*/
string[] orderIDs = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };
foreach (var orderID in orderIDs)
{
    if (orderID.StartsWith("B"))
    {
        Console.WriteLine(orderID);
    }
}
