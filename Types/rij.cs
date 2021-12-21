using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventInfi.Types
{
    public class rij<T> : IEnumerable<T>
    {
        private T[] _rij;
        public rij(params T[] rij) => _rij = rij;

        public T this[int index] => _rij[index];

        public int Lengte => _rij.Length;

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_rij).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _rij.GetEnumerator();

        public static rij<T> Leeg() => new rij<T>(Array.Empty<T>());

        public override string ToString()
        {
            return $"[{string.Join(",", _rij)}]";
        }
    }
}
