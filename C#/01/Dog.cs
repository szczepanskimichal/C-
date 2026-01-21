namespace _01
{
    public class Dog : Pet
    {
        public Dog(string firstName) : base(firstName) { }
        public override string MakeNoise() => "Woof!";
    }
}
