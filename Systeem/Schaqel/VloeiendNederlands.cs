using System.Collections.Generic;

namespace AdventInfi.Systeem.Schaqel
{
    // vloeiendheid extensie voor Nederlands
    public static class VloeiendNederlands
    {
        public static IEnumerable<T> En<T>(this IEnumerable<T> bron) => bron;
        public static IEnumerable<T> Dan<T>(this IEnumerable<T> bron) => bron;
    }
}
