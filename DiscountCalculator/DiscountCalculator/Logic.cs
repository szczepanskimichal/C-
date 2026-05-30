using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace DiscountCalculator;

public class Logic
{
    public static Result<string> PriceTextFromArgs(string[] args)
    {
        return args.Length != 1
            ? Result<string>.Failure("Feil: Du må angi en pris")
            : Result<string>.Success(args[0]);
    }

    public static string Trim(string text)
    {
        return text.Trim();
    }

    public static Result<decimal> ToDecimal(string numberText)
    {
        if (!decimal.TryParse(numberText, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal price))
        {
            return Result<decimal>.Failure(
                $"Feil: {numberText}' er ikke et gyldig desimaltall.\n" +
                $"Innhold: '{numberText}'");
        }

        return Result<decimal>.Success(price);
    }

    public static Result<decimal> ValidateOver(decimal limit, decimal number)
    {
    if(number <= limit)
    {
       return Result<decimal>.Failure($"feil: Prisen må være større en {limit}. Verdien var {number}");
    }
     return   Result<decimal>.Success(number);
    }


    public static decimal Multiply(decimal factor, decimal number)
    {
        return factor * number;
    }
    public static string FormatAmount(decimal amount)
    {
        return $"{amount:0.00} kr";
    }
}
