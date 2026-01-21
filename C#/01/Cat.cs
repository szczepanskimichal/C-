namespace _01
{
    public class Cat : Pet
    {
        public Cat(string firstName) : base(firstName) { }
        public override string MakeNoise() => "Meow!";
    }
}
