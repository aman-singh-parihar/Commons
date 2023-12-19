using System.Diagnostics;

namespace CustomEnumerables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployee[] employee =
            {
                new Developer() {Id =1, Name="Web-Developer" },
                new Tester(){Id =2, Name="Web-Tester" }
            }; 

            var enumerable = new GenericEnumerable<IEmployee>(employee);
            
            var enumerator = enumerable.GetEnumerator();
            var generic = (GenericEnumerator<IEmployee>)enumerator;

            while (enumerator.MoveNext())
            {
                Console.WriteLine($"Name of the employee: {enumerator.Current.Name}");
                //var y = enumerator[0];
                var x = generic.Current;
                var t = generic[0];
            }

            var random = new Random();
            var numbers = Enumerable.Range(0, 10).ToList();

            var gridPositions = numbers.Where(x =>
            {
                Task.Delay(1000).Wait();
                return true;
            });
            gridPositions.Take(4);
            var watch = new Stopwatch();
            watch.Start();
            foreach (var number in gridPositions)
            {
                Console.WriteLine(number);
            }
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds}");
        }
    }
    public class BasicStack<T>
    {
        private T[] elements;
        const int DEFAULT_SIZE = 10;
        private int index;
        BasicStack()
        {
            index = 0;
            elements = new T[DEFAULT_SIZE];
        }
        public void Push(T element)
        {
            if (index > DEFAULT_SIZE)
            {
                T[] updated = new T[DEFAULT_SIZE * 2];
                Array.Copy(elements, 0, updated, 0, index);
                elements = updated;
            }
            elements[index] = element;
            index++;
        }
        public T Pop()
        {
            var element = elements[index];
            index--;
            return element;
        }
        public T Peek()
        {
            return elements[index];
        }
    }
}
