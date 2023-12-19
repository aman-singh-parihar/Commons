namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Calculate<string>();
            //Calculate(3,4);

            GenericOne<string>.Calculate(3, 4);
            GenericOne<int>.Calculate(3, 4);
        }
        static void Calculate<T>(T a, T b) 
        {
            Console.WriteLine($"value of a: {a} & value of b: {b}");
        }
        static void Calculate<T>()
        {
            Console.WriteLine($"Type of a: {typeof(T)}");
        }
    }
    public class GenericOne<T>
    {
        public static void Calculate<U>(U a, U b)
        {
            Console.WriteLine($"value of a: {a} & value of b: {b}");
        }
        public static void Calculate<U>(U a)
        {
            Console.WriteLine($"value of a: {a}");
        }
        public static void Calculate(T a, T b)
        {
            Console.WriteLine($"Type of a: {typeof(T)}");
        }
    }
}

