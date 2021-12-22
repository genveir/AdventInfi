using AdventInfi.Systeem.Schaqel;
using AdventInfi.Types;

namespace AdventInfi
{
    class MogelijkeTasInvulling
    {
        public getal pakjesDieNogMoetenPassen;
        public getal ruimteOver;
        public rij<karakt> pakjes;

        public MogelijkeTasInvulling(rij<karakt> pakjes, getal ruimteOver, getal pakjesDieNogMoetenPassen)
        {
            this.pakjes = pakjes;
            this.ruimteOver = ruimteOver;
            this.pakjesDieNogMoetenPassen = pakjesDieNogMoetenPassen;
        }

        public MogelijkeTasInvulling Volgende(karakt pakje, getal volume)
        {
            return new MogelijkeTasInvulling(
                pakjes: pakjes
                    .MaakVastAan(pakje)
                    .SorteerOp(c => c)
                    .AlsRij(),
                ruimteOver: ruimteOver - volume,
                pakjesDieNogMoetenPassen: pakjesDieNogMoetenPassen - 1
            );
        }

        public sliert AlsSliert() => $"{sliert.AanElkaar("", pakjes)} ({pakjesDieNogMoetenPassen} / {ruimteOver})";

        public override string ToString() => AlsSliert().ToString();
    }
}
