using System.Collections;

namespace CustomEnumerables
{
    internal class GenericEnumerable<T> : IEnumerable<T> where T : IEmployee
    {
        private T[] _emumerables;
        public GenericEnumerable(T[] enumerables)
        {
            _emumerables = enumerables;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
             return new GenericEnumerator<T>(_emumerables);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
