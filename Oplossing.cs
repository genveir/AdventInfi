using Systeem;
using Systeem.Schaqel;
using Systeem.Verzamelingen.Algemeen;
using static Systeem.waarheid;

namespace AdventInfi
{
    public class Oplossing
    {
        getal hetAantalPakjes;

        getal alGevuldeRuimte;
        Lijst<Onderdeel> fabrikaten;

        public Oplossing() : this(DeEchteSpeelgoedLijst, 20) { }
        public Oplossing(sliert speelgoedLijst, getal aantalPakjes)
        {
            hetAantalPakjes = aantalPakjes;

            (alGevuldeRuimte, fabrikaten) = Ontleder.ProbeerDeSpeelgoedLijstTeOntleden(speelgoedLijst);
        }

        Woordenboek<(getal, getal), (waarheid, rij<karakt>)> bezocht;
        rij<(karakt eersteLetter, getal grootte)> speelgoed;
        (waarheid succes, rij<karakt> result) VindIngepakteCadeaus(MogelijkeTasInvulling toestand)
        {
            if (bezocht
                .Probeer((toestand.ruimteOver, toestand.pakjesDieNogMoetenPassen))
                .OpTeHalen(out (waarheid succes, rij<karakt> pakketjes) resultaat)) return resultaat;
            else
            {
                resultaat = (ONWAAR, rij<karakt>.Leeg());
                if (toestand.ruimteOver == 0 && toestand.pakjesDieNogMoetenPassen == 0) resultaat = (WAAR, toestand.pakjes);
                else if (toestand.ruimteOver < 0 || toestand.pakjesDieNogMoetenPassen < 0) resultaat = (ONWAAR, rij<karakt>.Leeg());
                else
                {
                    for (getal n = 0; n < speelgoed.Lengte; n++)
                    {
                        MogelijkeTasInvulling nieuweState = toestand.Volgende(speelgoed[n].eersteLetter, speelgoed[n].grootte);

                        (waarheid succes, rij<karakt> pakketjes) subResultaat = VindIngepakteCadeaus(nieuweState);

                        if (subResultaat.succes)
                        {
                            resultaat = subResultaat;
                            break;
                        }
                    }
                }
            }

            bezocht[(toestand.ruimteOver, toestand.pakjesDieNogMoetenPassen)] = resultaat;
            return resultaat;
        }

        public getal BerekenDeel1()
        {
            getal antwoord = fabrikaten.NeemDeHooste(o => o.TotaalAantalDelen());

            Venster.SchrijfRegel(antwoord);

            return antwoord;
        }

        public sliert BerekenDeel2()
        {
            var accusOfIjzer = fabrikaten
                .PakEenHoop(o => o.Onderdelen)
                .Pak(o => o.type)
                .Verschillende();

            speelgoed = fabrikaten
                .Behalve(accusOfIjzer)
                .SorteerAflopendOp(o => o.TotaalAantalDelen())
                .Pak(o => (o.Naam.Letters.NeemDeEerste(), o.TotaalAantalDelen()))
                .AlsRij();

            var beginToestand = new MogelijkeTasInvulling(
                pakjes: rij<karakt>.Leeg(),
                ruimteOver: alGevuldeRuimte,
                pakjesDieNogMoetenPassen: hetAantalPakjes);

            bezocht = new Woordenboek<(getal, getal), (waarheid, rij<karakt>)>();
            rij<karakt> pakketjes = VindIngepakteCadeaus(beginToestand).result;

            sliert antwoord = new(pakketjes);

            Venster.SchrijfRegel(antwoord);

            return antwoord;
        }

        public static sliert DeEchteSpeelgoedLijst => @"522610 onderdelen missen
Lightsaber: 73 Batterij, 41 Unobtanium
HandheldComputer: 59 Batterij, 79 Printplaat, 5 Plastic
ElectrischeRacebaan: 73 AutoChassis, 97 Printplaat, 7 Plastic, 59 Batterij, 41 Wiel
QuadDrone: 19 Accu, 89 Plastic, 89 Printplaat
PikachuPlushy: 47 Batterij
Trampoline: 5 Schokdemper, 29 IJzer
BatmobileReplica: 47 BatmobileChassis, 61 Schokdemper, 41 Unobtanium, 5 Wiel
DanceDanceRevolutionMat: 47 Schokdemper, 3 Batterij
Printplaat: 79 Hars, 59 Koper, 43 Chip, 43 Led
Accu: 5 Batterij
Schokdemper: 23 IJzer, 17 Staal
Batterij: 83 Staal
BatmobileChassis: 31 AutoChassis, 13 Staal
AutoChassis: 53 IJzer
Wiel: 47 Rubber, 23 IJzer
Unobtanium: 19 IJzer, 71 Kryptonite";
    }
}