namespace _1_PipeAndCompose
{
    internal class Utils
    {
        public static Func<TInput, TOutput> Compose<TInput, TMiddle, TOutput>(
            Func<TMiddle, TOutput> f1,
            Func<TInput, TMiddle> f2)
        {
            return input => f1(f2(input));
        }

        public static Func<T1, T4> Compose<T1,T2,T3,T4>(
            Func<T3, T4> f3,
            Func<T2, T3> f2,
            Func<T1, T2> f1)
        {
            return input => f3(f2(f1(input)));
        }

        public static TOutput Pipe<TInput, TMiddle, TOutput>(
            TInput input,
            Func<TInput, TMiddle> f1,
            Func<TMiddle, TOutput> f2)
        {
            return f2(f1(input));
        }

        public static T4 Pipe<T1, T2, T3, T4>(
            T1 input,
            Func<T1, T2> f1,
            Func<T2, T3> f2,
            Func<T3, T4> f3)
        {
            return f3(f2(f1(input)));
        }

        public static T5 Pipe<T1, T2, T3, T4, T5>(
            T1 input,
            Func<T1, T2> f1,
            Func<T2, T3> f2,
            Func<T3, T4> f3,
            Func<T4, T5> f4)
        {
            return f4(f3(f2(f1(input))));
        }

        public static T6 Pipe<T1, T2, T3, T4, T5, T6>(
            T1 input,
            Func<T1, T2> f1,
            Func<T2, T3> f2,
            Func<T3, T4> f3,
            Func<T4, T5> f4,
            Func<T5, T6> f5)
        {
            return f5(f4(f3(f2(f1(input)))));
        }
    }
}
