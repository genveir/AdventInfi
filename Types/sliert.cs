using AdventInfi.Systeem.Schaqel;
using System;
using System.Linq;

namespace AdventInfi.Types
{
    public enum SliertOpsplitsOpties { VerwijderLegeInzendingen }
    public class sliert
    {
        private string _sliert;
        private sliert(string sliert) => _sliert = sliert;
        public sliert(rij<karakt> karakters)
        {
            _sliert = new string(karakters.Pak(k => (char)k).ToArray());
        }

        public static implicit operator sliert(string s) => new sliert(s);

        public static sliert AanElkaar<T>(sliert doeErTussen, rij<T> elementen) => string.Join(doeErTussen._sliert, elementen);

        public rij<sliert> Splits(karakt splitsOp, SliertOpsplitsOpties _) => Splits(new rij<karakt>(splitsOp), _);
        public rij<sliert> Splits(rij<karakt> splitsOp, SliertOpsplitsOpties _) =>
            _sliert
                .Split(splitsOp.Pak(k => (char)k).ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .En().Pak(s => new sliert(s)).AlsRij();

        public getal AlsGetal() => (getal)int.Parse(_sliert);

        public rij<karakt> Letters => _sliert.ToCharArray().Pak(c => (karakt)c).AlsRij();

        public override int GetHashCode() => GetDeterministicHashCode(_sliert);
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as sliert;
            if (other == null) return false;
            else return _sliert.Equals(other._sliert);
        }
        public override string ToString() => _sliert;

        // https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/
        public static int GetDeterministicHashCode(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}
