using System.Globalization;
using DiscountCalculator;

Console.WriteLine(
    Logic2.PriceTextFromArgs(args)
        .Map(Logic2.Trim)
        .FlatMap(Logic2.ToDecimal)
        .FlatMap(Logic2.ValidateOverCurried(0))
        .Map(Logic2.MultiplyCurried(0.8m))
        .Map(Logic2.MultiplyCurried(1.25m))
        .Map(Logic2.FormatAmount)
);
return 0;

var priceTextResult = Logic.PriceTextFromArgs(args);
if (!priceTextResult.IsSuccess)
{
    Console.WriteLine(priceTextResult.Error);
    return 1;
}
var priceText = priceTextResult.Value;
string trimmedText = Logic.Trim(priceText);
//----------------------------
var decimalResult =  Logic.ToDecimal(trimmedText);
if (!decimalResult.IsSuccess)
{
    Console.Error.WriteLine(decimalResult.Error);
    return 1;
}
decimal price = decimalResult.Value;
//------_----------------------
var validationResult = Logic.ValidateOver(0, decimalResult.Value);
if (!validationResult.IsSuccess)
{    Console.Error.WriteLine(validationResult.Error);
    return 1;
}
/*if (price <= 0)
{
    Console.Error.WriteLine($"Feil: Prisen må være større enn 0. Verdien var {price}.");
    return 1;
}
*/
//-----------------------------
var validatePrice = validationResult.Value;
//// Trekker fra 20 % rabatt
decimal priceAfterDiscount = Logic.Multiply(0.8m, validatePrice);

//// Legger til 25 % mva
decimal priceWithVat = Logic.Multiply(1.25m, priceAfterDiscount);

string formattedResult = Logic.FormatAmount(priceWithVat);

Console.WriteLine(formattedResult);
return 0;




/*using System.Globalization;
using DiscountCalculator;

var priceTextResult = Logic.PriceTextFromArgs(args); /if (!priceTextResult.IsSuccess)
{
    Console.WriteLine(priceTextResult.Error);
    return 1;
}

var priceText = priceTextResult.Value;

string trimmedText = Logic.Trim(priceText);

var decimalResult = Logic.ToDecimal(trimmedText);
if (!decimalResult.IsSuccess)
{
    Console.Error.WriteLine(decimalResult.Error);
    return 1;
}

var validationResult = Logic.ValidateOver(0, decimalResult.Value);
if (!validationResult.IsSuccess)
{
    Console.Error.WriteLine(validationResult.Error);
    return 1;
}

var validatedPrice = validationResult.Value;


// Trekker fra 20 % rabatt
decimal priceAfterDiscount = Logic.Multiply(0.8m, validatedPrice);

// Legger til 25 % mva
decimal priceWithVat = Logic.Multiply(1.25m, priceAfterDiscount);

string formattedResult = Logic.FormatAmount(priceWithVat);

Console.WriteLine(formattedResult);
return 0;
*/
/*
// IMPERATIVT 

using System.Globalization;

if (args.Length != 1)
{
    Console.Error.WriteLine("Feil: Du må angi en pris");
    return 1;
}

string priceText = args[0];


string trimmedText = priceText.Trim();

if (!decimal.TryParse(trimmedText, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal price))
{
    Console.Error.WriteLine($"Feil: {priceText}' er ikke et gyldig desimaltall.");
    Console.Error.WriteLine($"Innhold: '{trimmedText}'");
    return 1;
}

if (price <= 0)
{
    Console.Error.WriteLine($"Feil: Prisen må være større enn 0. Verdien var {price}.");
    return 1;
}

decimal discountPercent = 20m;
decimal vatPercent = 25m;

//// Trekker fra 20 % rabatt
decimal priceAfterDiscount = price * (1 - discountPercent / 100);

//// Legger til 25 % mva
decimal priceWithVat = priceAfterDiscount * (1 + vatPercent / 100);

string formattedResult = $"{priceWithVat:0.00} kr";

Console.WriteLine(formattedResult);
return 0;
*/