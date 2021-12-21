using System;
using System.Collections.Generic;

namespace AdventInfi.Types
{
    public class Woordenboek<Sleutel, Waarde>
    {
        public Dictionary<Sleutel, Waarde> _woordenboek;

        public Woordenboek() => _woordenboek = new Dictionary<Sleutel, Waarde>();

        public ToeAccepteerder Voeg(Sleutel sleutel, Waarde waarde) =>
            new ToeAccepteerder(() => _woordenboek.Add(sleutel, waarde));

        public OpTeHalenAccepteerder Probeer(Sleutel sleutel) =>
            new OpTeHalenAccepteerder(sleutel, _woordenboek);

        public Waarde this[Sleutel sleutel]
        {
            get => _woordenboek[sleutel];
            set => _woordenboek[sleutel] = value;
        }

        public class OpTeHalenAccepteerder
        {
            public Dictionary<Sleutel, Waarde> _woordenboek;
            public Sleutel _sleutel;

            public OpTeHalenAccepteerder(Sleutel sleutel, Dictionary<Sleutel, Waarde> woordenboek)
            {
                _woordenboek = woordenboek;
                _sleutel = sleutel;
            }

            public bool OpTeHalen(out Waarde waarde) =>
                _woordenboek.TryGetValue(_sleutel, out waarde);
        }

        public class ToeAccepteerder
        {
            Action _uitvoeren;
            public ToeAccepteerder(Action uitvoeren) => _uitvoeren = uitvoeren;
            public void Toe() => _uitvoeren();
        }
    }
}
