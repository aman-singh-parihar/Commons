using System.Collections;

namespace CustomEnumerables
{
    internal class GenericEnumerator<_T> : IEnumerator<_T> where _T: IEmployee
    {
        private readonly _T[] _enumerables;
        private int index = -1;
        public _T this[int i] 
        {
            get { return _enumerables[i]; }
            set { _enumerables[i] = value; }
        }
        public GenericEnumerator(_T[] enumerables)
        {
            this._enumerables = enumerables;
        }
        public _T Current => _enumerables[index];

        object IEnumerator.Current => _enumerables[index];

        public void Dispose()
        {

        }

        public bool MoveNext() 
        {
            index++;
            return index < _enumerables.Length ? true : false;
        } 


        public void Reset()
        {
            index = 0;
        }
    }
}
