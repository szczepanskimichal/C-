/*
 
Console.WriteLine("Signed integral types:");

Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Unsigned integral types:");

Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
*/
/*
//int[] data;
int[] data = new int[5];

System.Console.WriteLine($"{data.Length}");

string shortenedString = "Hello World!";
Console.WriteLine(shortenedString);

int val_A = 2;
int val_B = val_A;
val_B = 5;

Console.WriteLine("--Value Types--");
Console.WriteLine($"val_A: {val_A}");
Console.WriteLine($"val_B: {val_B}");

int[] cos = new int[1];
cos[0] = 2;
int[] noweCos = cos;
noweCos[0] = 7;

Console.WriteLine("--Reference Types--");
Console.WriteLine($"ref_A[0]: {cos[0]}");
Console.WriteLine($"ref_B[0]: {noweCos[0]}");
*/
/*
int first = 2;
string second = "4";
int result = first + int.Parse(second);
string result2 = first + second;
System.Console.WriteLine($"Result: {result}");
System.Console.WriteLine($"Result2: {result2}");
*/
/*
decimal myDecimal = 3.14m;
System.Console.WriteLine($"myDecimal: {myDecimal}");

int myInt = (int)myDecimal;
System.Console.WriteLine($"myInt: {myInt}");

decimal myDecimal2 = 1.23456789m;
float myFloat = (float)myDecimal2;

Console.WriteLine($"Decimal: {myDecimal2}");
Console.WriteLine($"Float  : {myFloat}");

int first = 5;
int second = 7;
string message = first.ToString() + second.ToString();
Console.WriteLine(message);
*/
/*
//string value = "102";
string value = "abc";
int result = 0;
if (int.TryParse(value, out result))
{
  Console.WriteLine($"Parsed value: {result}");
}
else
{
  Console.WriteLine("Failed to parse value.");
}
if (result <= 0)
  Console.WriteLine($"Measurement (w/ offset): {50 + result}");
*/
/*
string[] values = { "12.3", "45", "ABC", "11", "DEF" };

decimal total = 0m;
string message = "";

foreach (var value in values)
{
  decimal number; // stores the TryParse "out" value
  if (decimal.TryParse(value, out number))
  {
    total += number;
  }
  else
  {
    message += value;
  }
}

Console.WriteLine($"Message: {message}");
Console.WriteLine($"Total: {total}");
*/

using System.Diagnostics.Contracts;

int value1 = 11;
decimal value2 = 6.2m;
float value3 = 4.3f;

// Your code here to set result1
// Hint: You need to round the result to nearest integer (don't just truncate)
int result1 = Convert.ToInt32(Math.Round(value1 / value2));
Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

// Your code here to set result2
decimal result2 = value2 / (decimal)value3;
Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

// Your code here to set result3
float result3 = value3 / value1;
Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");