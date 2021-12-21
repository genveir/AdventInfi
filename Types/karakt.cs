using System;

namespace AdventInfi.Types
{
    public class karakt : IComparable<karakt>, IComparable
    {
        private char _karakt;
        private karakt(char karakt) => _karakt = karakt;

        public static implicit operator karakt(char c) => new karakt(c);
        public static explicit operator char(karakt k) => k._karakt;

        public override int GetHashCode() => _karakt.GetHashCode();
        public override bool Equals(object obj) => _karakt.Equals(obj);
        public override string ToString() => _karakt.ToString();

        public int CompareTo(karakt other)
        {
            return _karakt.CompareTo(other._karakt);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(this, obj)) return 0;

            if (obj is char) return _karakt.CompareTo(obj);

            var other = obj as karakt;
            if (ReferenceEquals(other, null)) return _karakt.CompareTo(other);
            else return CompareTo(other);
        }
    }
}
