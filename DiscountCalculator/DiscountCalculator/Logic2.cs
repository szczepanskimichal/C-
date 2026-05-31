namespace DiscountCalculator;

public class Logic2
{
    public static Func<string[], Result<string>> PriceTextFromArgs { get; }
    public static Func<string, string> Trim { get; }
    public static Func<string, Result<decimal>> ToDecimal { get; }
    public static Func<decimal, Func<decimal, Result<decimal>>> ValidateOverCurried { get; }
    public static Func<decimal, decimal, Result<decimal>> ValidateOver { get; }
    public static Func<decimal, Func<decimal, decimal>> MultiplyCurried { get; }
    public static Func<decimal, decimal, decimal> Multiply { get; }
    public static Func<decimal, string> FormatAmount { get; }

    static Logic2()
    {

        PriceTextFromArgs = args => args.Length != 1
            ? Result<string>.Failure("Feil: Du må angi en pris")
            : Result<string>.Success(args[0]);
        Trim = text => text.Trim();
        ToDecimal = numberText => !decimal.TryParse(numberText, out decimal price)
            ? Result<decimal>.Failure(
                $"Feil: {numberText}' er ikke et gyldig desimaltall.\n" +
                $"Innhold: '{numberText}'")
            : Result<decimal>.Success(price);

        ValidateOverCurried = limit => number => number <= limit
            ? Result<decimal>.Failure($"Feil: Verdien må være større enn {limit}. Verdien var {number}.")
            : Result<decimal>.Success(number);

        ValidateOver = (limit, number) =>
            number <= limit
                ? Result<decimal>.Failure($"Feil: Verdien må være større enn {limit}. Verdien var {number}.")
                : Result<decimal>.Success(number);

        MultiplyCurried = factor => value => factor * value;

        Multiply = (factor, value) => factor * value;

        FormatAmount = amount => $"{amount:0.00} kr";
    }
}

//lkdnsakdns