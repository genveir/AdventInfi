using AdventInfi.Systeem.Schaqel;
using AdventInfi.Types;

namespace AdventInfi
{
    static class Begrijper
    {
        public static (getal alGevuldeRuimte, Lijst<Onderdeel> fabrikaten) ProbeerDeSpeelgoedLijstTeBegrijpen(sliert speelgoedLijst)
        {
            rij<sliert> regels = speelgoedLijst
                .Splits(new rij<karakt>('\n', '\r'), SliertOpsplitsOpties.VerwijderLegeInzendingen)
                .AlsRij();

            getal alGevuldeRuimte = regels[0]
                .Splits(' ', SliertOpsplitsOpties.VerwijderLegeInzendingen)
                .En().NeemDeEerste().AlsGetal();

            var alleOnderdelen = new Woordenboek<sliert, Onderdeel>();

            rij<sliert> alleSoortenSpullen = regels
                .SlaEr(1).Over()
                .En().PakEenHoop(l => l
                    .Splits(new rij<karakt>(' ', ',', ':'), SliertOpsplitsOpties.VerwijderLegeInzendingen)
                    .Waar(s => !getal.ProbeerTeParseren(s, out _)))
                .Verschillende()
                .AlsRij();

            alleSoortenSpullen.DoeVoorElk(soortDing => alleOnderdelen.Voeg(soortDing, new Onderdeel(soortDing)).Toe());

            var fabrikaten = new Lijst<Onderdeel>();

            regels
                .SlaEr(1).Over()
                .En().DoeVoorElk(regel =>
                {
                    rij<sliert> inStukjes = regel
                        .Splits(new rij<karakt>(' ', ',', ':'), SliertOpsplitsOpties.VerwijderLegeInzendingen);

                    var halfFabrikaat = alleOnderdelen[inStukjes[0]];

                    for (getal i = 1; i < inStukjes.Lengte; i += 2)
                    {
                        halfFabrikaat.Onderdelen
                            .Voeg((inStukjes[i].AlsGetal(), alleOnderdelen[inStukjes[i + 1]])).Toe();
                    }
                    fabrikaten.Voeg(halfFabrikaat).Toe();
                });

            return (alGevuldeRuimte, fabrikaten);
        }
    }
}
