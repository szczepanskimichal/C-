/*
string[] pallets = ["B14", "A11", "B12", "A13"];
System.Console.WriteLine("");

Array.Clear(pallets, 0, 2);
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
  Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Array.Resize(ref pallets, 10);
Console.WriteLine($"Resizing 10 ... count: {pallets.Length}");

pallets[4] = "C01";
pallets[5] = "C02";

foreach (var pallet in pallets)
{
  Console.WriteLine($"-- {pallet}");
}

System.Console.WriteLine("");
Array.Resize(ref pallets, 3);
System.Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
  Console.WriteLine($"-- {pallet}");
}
*/
/*
string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
string result = string.Join(",", valueArray);
Console.WriteLine(result);

string[] items = result.Split(",");
foreach (var item in items)
{
  Console.WriteLine($"-- {item}");
}*/
/*
string pangram = "The quick brown fox jumps over the lazy dog";
string[] message = pangram.Split(" "); // message[0] = "The", message[1] = "quick", message[2] = "brown" ...
string[] newMwssage = new string[message.Length]; // newMessage[0] = "ehT", newMessage[1] = "kciuq", newMessage[2] = "nworb" ...
//Array.Reverse(message); // message[0] = "dog", message[1] = "lazy", message[2] = "the" ...
for (int i = 0; i < message.Length; i++) // message.Length = 9
{
  char[] lattters = message[i].ToCharArray(); // lattters[0] = 'T', lattters[1] = 'h', lattters[2] = 'e' ...
  Array.Reverse(lattters); // lattters[0] = 'e', lattters[1] = 'h', lattters[2] = 'T' ...
  newMwssage[i] = new string(lattters); // newMessage[0] = "ehT", newMessage[1] = "kciuq", newMessage[2] = "nworb" ...
}

string result = string.Join(" ", newMwssage); // result = "ehT kciuq nworb xof spmuj revo eht yzal god"
Console.WriteLine(result); // Output: "ehT kciuq nworb xof spmuj revo eht yzal god"
*/
/*
string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
string[] items = orderStream.Split(",");
Array.Sort(items);

foreach (var item in items)
{
  if (item.Length == 4)
  {
    Console.WriteLine($"-- {item}");
  }
  else
  {
    Console.WriteLine($"    {item}\t- Error");
  }
}*/
/*
string first = "Hello";
string second = "World";
string[] greetings = new string[2] { first, second };
Console.WriteLine($"Greetings: {string.Join(" ", greetings)}");
string result = string.Format("{0} {1}", first, second);
Console.WriteLine(result);
Console.WriteLine("{0} {0} {0}!", first, second);
decimal price = 123.45m;
int discount = 50;
System.Console.WriteLine($"Price: {price:C} (Save {discount:C})");
*/
/*
decimal measurement = 123456.78912m;
Console.WriteLine($"Measurement: {measurement:N} units");
Console.WriteLine($"Measurement: {measurement:N2} units");
decimal tax = .36785m;
Console.WriteLine($"Tax rate: {tax:P2}");


decimal price = 67.55m;
decimal salePrice = 59.99m;

string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);

yourDiscount += $"A discount of {((price - salePrice) / price):P2}!"; //inserted
Console.WriteLine(yourDiscount);
*/

int invoiceNumber = 1201;
decimal productShares = 25.4568m;
decimal subtotal = 2750.00m;
decimal taxPercentage = .15825m;
decimal total = 3185.18m;

System.Console.WriteLine($"Invoice Number: {invoiceNumber}");
System.Console.WriteLine($"    Shares: {productShares:N2}");
System.Console.WriteLine($"    Shares: {productShares:N3}");
System.Console.WriteLine($"    Subtotal: {subtotal:C2}");
System.Console.WriteLine($"    Tax Percentage: {taxPercentage:P2}");
System.Console.WriteLine($"    Total Billed: {total:C2}");
