using AdventInfi.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventInfi.Tests.Neenheid
{
    public static class Stel
    {
        public static void ZijnGelijk(getal verwacht, object feitelijk) => Assert.AreEqual(verwacht, feitelijk);
        public static void ZijnGelijk(sliert verwacht, object feitelijk) => Assert.AreEqual(verwacht, feitelijk);
    }
}
