namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Calculate<string>();
            //Calculate(3,4);
            //Scenario 1
            GenericOne<string>.Calculate(3, 4);
            GenericOne<int>.Calculate(3, 4);

            //Scenario 2
            var products = new List<Product>
            {
                new Product { Id = 1,Color = Color.Green, Size = Size.M, Discount = Discount.MoreThan70 },
                new Product { Id = 2,Color = Color.Red, Size = Size.L, Discount = Discount.MoreThan70 },
                new Product { Id = 3,Color = Color.Green, Size = Size.M, Discount = Discount.MoreThan70 }
            };

            var filter = new ProductFilter();
            filter.Filter(products, new ColorSpecification(Color.Green));
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
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Discount Discount { get; set; }
    }
    internal enum Color
    {
        Green, Red
    }
    internal enum Size { M, L }
    internal enum Discount { MoreThan70, MoreThan80 }
}

