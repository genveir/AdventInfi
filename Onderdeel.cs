using AdventInfi.Types;

namespace AdventInfi
{
    class Onderdeel
    {
        public sliert Naam;
        public Lijst<(getal aantal, Onderdeel type)> Onderdelen;

        public Onderdeel(sliert naam)
        {
            Naam = naam;
            Onderdelen = new Lijst<(getal aantal, Onderdeel type)>();
        }

        getal _totaalAantal = 0;
        public getal TotaalAantalDelen()
        {
            if (_totaalAantal == 0)
            {
                if (Onderdelen.Telling == 0) _totaalAantal = 1;
                else
                {
                    foreach (var onderdeel in Onderdelen) _totaalAantal += onderdeel.aantal * onderdeel.type.TotaalAantalDelen();
                }
            }
            return _totaalAantal;
        }
    }
}
