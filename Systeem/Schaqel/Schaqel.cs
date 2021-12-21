using AdventInfi.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventInfi.Systeem.Schaqel
{
    public static class IEnumerableExtensies
    {
        public static void DoeVoorElk<T>(this IEnumerable<T> bron, Action<T> aktie) { foreach (T t in bron) aktie(t); }

        public static IEnumerable<T> MaakVastAan<T>(this IEnumerable<T> bron, T nieuweDing) => bron.Append(nieuweDing);

        public static IEnumerable<T> Behalve<T>(this IEnumerable<T> bron, IEnumerable<T> andere) => bron.Except(andere);
        public static IEnumerable<U> Pak<T, U>(this IEnumerable<T> bron, Func<T, U> kiezer) => bron.Select(kiezer);
        public static IEnumerable<U> PakEenHoop<T, U>(this IEnumerable<T> bron, Func<T, IEnumerable<U>> kiezer) => bron.SelectMany(kiezer);
        public static IEnumerable<T> Waar<T>(this IEnumerable<T> bron, Func<T, bool> predikaat) => bron.Where(predikaat);
        public static T NeemDeEerste<T>(this IEnumerable<T> bron) => bron.First();
        public static getal NeemDeHooste<T>(this IEnumerable<T> bron, Func<T, getal> kiezer) => bron.Max(kiezer);

        public static IEnumerable<T> SorteerOp<T, TSleutel>(this IEnumerable<T> bron, Func<T, TSleutel> kriterium) => bron.OrderBy(kriterium);
        public static IEnumerable<T> SorteerAflopendOp<T, TSleutel>(this IEnumerable<T> bron, Func<T, TSleutel> kriterium) => 
            bron.OrderByDescending(kriterium);

        public static OverAccepteerder<T> SlaEr<T>(this IEnumerable<T> bron, int aantal) => new OverAccepteerder<T>(bron.Skip(aantal));

        public static IEnumerable<T> Verschillende<T>(this IEnumerable<T> bron) => bron.Distinct();

        public static rij<T> AlsRij<T>(this IEnumerable<T> bron) => new rij<T>(bron.ToArray());

            public class OverAccepteerder<T>
    {
        private IEnumerable<T> _waarde;
        public OverAccepteerder(IEnumerable<T> waarde) => _waarde = waarde;
        public IEnumerable<T> Over() => _waarde;
    }
    }
}
