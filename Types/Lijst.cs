using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventInfi.Types
{
    public class Lijst<Waarde> : IEnumerable<Waarde>
    {
        public List<Waarde> _lijst;

        public Lijst() => _lijst = new List<Waarde>();

        public ToeAccepteerder Voeg(Waarde waarde) => new ToeAccepteerder(() => _lijst.Add(waarde));

        public getal Telling => _lijst.Count;

        public IEnumerator<Waarde> GetEnumerator() => ((IEnumerable<Waarde>)_lijst).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_lijst).GetEnumerator();

        public class ToeAccepteerder
        {
            Action _uitvoeren;
            public ToeAccepteerder(Action uitvoeren) => _uitvoeren = uitvoeren;
            public void Toe() => _uitvoeren();
        }
    }
}
