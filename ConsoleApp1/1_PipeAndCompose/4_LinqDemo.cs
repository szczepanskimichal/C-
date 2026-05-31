using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1_PipeAndCompose
{
    internal class LinqDemo
    {
        public static void Run()
        {
            var numbers = new int[] { 90, 30, 45, 20, 13, 37 };
            // "imperativ versjon"
            //var a = number + 7;
            //var b = a * 3;
            //var c = Math.Clamp(b, 40, 100);
            //Console.WriteLine($"{number} => {a} => {b} => {c}");
            //var newNumbers = numbers
            //    .Select(n => n + 7)
            //    .Select(n => n * 3)
            //    .Select(n => Math.Clamp(n, 40, 100));

            // curried versjoner av operasjonen
            Func<int, Func<int, int>> Add = numberA => numberB => numberA + numberB;
            Func<int, Func<int, int>> Multiply = numberA => numberB => numberA * numberB;
            Func<int, int, Func<int, int>> Clamp = (min, max) => number => Math.Clamp(number, min, max);

            // funksjonell versjon
            var newNumbers = numbers.Select(
                Utils.Compose(Clamp(40, 100), Multiply(3), Add(7))
            );

            //var newNumbers = numbers
            //    .Select(Add(7))
            //    .Select(Multiply(3))
            //    .Select(Clamp(40, 100));
        }
    }
}
