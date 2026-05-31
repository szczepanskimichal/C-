namespace _1_PipeAndCompose
{
    internal class IntroPipeDemo
    {
        public static void Run()
        {
            Func<int, int> Add1 = n => n + 1;
            Func<int, int> Double = n => n * 2;
            var input = 7;

            // imperativ versjon
            var tempVariable1 = Add1(input);
            var resultI = Double(tempVariable1);
            Console.WriteLine(resultI);

            // funksjonell versjon med pipe
            var resultPipe = Utils.Pipe(input, Add1, Double);
            Console.WriteLine(resultPipe);

            // funksjonell versjon med compose
            var add1AndDouble = Utils.Compose(Double, Add1);
            var resultCompose = add1AndDouble(input);
            Console.WriteLine(resultCompose);


        }
    }
}
