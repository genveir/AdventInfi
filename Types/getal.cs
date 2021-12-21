using System;

namespace AdventInfi.Types
{
    public class getal : IComparable<getal>, IComparable
    {
        private int _getal;
        private getal(int getal) => _getal = getal;

        public static implicit operator getal(int s) => new getal(s);
        public static implicit operator int(getal g) => g._getal;

        public static bool operator ==(getal getal, getal ander) => getal._getal == ander._getal;
        public static bool operator !=(getal getal, getal ander) => getal._getal != ander._getal;

        public static getal operator +(getal getal, getal erbij) => new getal(getal._getal + erbij._getal);
        public static getal operator -(getal getal, getal erbij) => new getal(getal._getal - erbij._getal);
        public static getal operator *(getal getal, getal erbij) => new getal(getal._getal * erbij._getal);
        public static bool operator <(getal getal, getal erbij) => getal._getal < erbij._getal;
        public static bool operator >(getal getal, getal erbij) => getal._getal > erbij._getal;

        public static bool ProbeerTeParseren(sliert bron, out getal uitkomst)
        {
            bool success = int.TryParse(bron.ToString(), out int waarde);
            uitkomst = new getal(waarde);

            return success;
        }

        public override int GetHashCode() => _getal;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as getal;
            if (ReferenceEquals(other, null)) return false;
            return _getal.Equals(other._getal);
        }
        public override string ToString() => _getal.ToString();

        public int CompareTo(getal other)
        {
            return _getal.CompareTo(other._getal);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(this, obj)) return 0;

            if (obj is int) return _getal.CompareTo(obj);

            var other = obj as getal;
            if (ReferenceEquals(other, null)) return _getal.CompareTo(other);
            else return CompareTo(other);
        }
    }
}
