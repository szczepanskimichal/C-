namespace DiscountRefactor
{
    internal class A
    {
        public static void Run()
        {
            Console.WriteLine("Start A.Run()");
            B.Run();
            Console.WriteLine("Fullført A.Run()");
        }
    }

    internal class B
    {
        public static void Run()
        {
            Console.WriteLine("Start B.Run()");
            //try
            //{
                C.Run();
            //}
            //catch
            //{
            //    Console.WriteLine("C.Run() feilet");
            //}

            Console.WriteLine("Fullført B.Run()");
        }
    }

    internal class C
    {
        public static void Run()
        {
            Console.WriteLine("Start C.Run()");
            try
            {
                throw new IOException(); // Tenk at dette er kode som bare feiler av og til, ikke alltid
            }
            catch(IOException e)
            {
                throw new InvalidCodeAppliedException("Kode XYZ er ugyldig");
            }

            Console.WriteLine("Fullført C.Run()");

        }
    }
}
