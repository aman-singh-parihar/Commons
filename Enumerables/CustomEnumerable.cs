using Enumerables;
public class CustomEnumerable<T> : IEnumerable<T> where T : ICustomTypes
{
    public T[] data { get; set; }
    private const int defaultSize = 10;
    public CustomEnumerable()
    {
        data = new T[defaultSize];
    }
    public IEnumerator<T> GetEnumerator()
    {
        return new GeneralEnumerator<T>(data);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}