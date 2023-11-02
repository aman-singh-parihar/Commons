public class CustomEnumerator<T> : IEnumerator<T> where T : ICustomTypes
{
    private readonly T[] _generalData;
    private int index = 0;
    public CustomEnumerator(T[] generalData)
    {
        _generalData = generalData;
    }
    public object Current => _generalData[index];

    //StudentEnumerable IEnumerator<StudentEnumerable>.Current => (StudentEnumerable)Current;

    T IEnumerator<T>.Current => _generalData[index];

    public void Dispose()
    {
        
    }

    public bool MoveNext()
    {
        index++;
        return index < _generalData.Length;
    }

    public void Reset()
    {
        index = 0;
    }
}