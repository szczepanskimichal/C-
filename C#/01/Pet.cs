using System;

namespace _01
{
    public abstract class Pet
    {
        protected Pet(string firstName)
        {
            First = firstName;
        }

        public string First { get; }
        public abstract string MakeNoise();

        public override string ToString() => $"{GetType().Name}: {First} => {MakeNoise()}";
    }
}
