using Tests.Neenheid;
using NUnit.Framework;

namespace AdventInfi.Tests
{
    class Armatuur
    {
        [Test]
        public void Test1()
        {
            var oplossing = new Oplossing(voorbeeld, 3);

            Stel.ZijnGelijk(18, oplossing.BerekenDeel1());
        }

        [Test]
        public void Test2()
        {
            var oplossing = new Oplossing(voorbeeld, 3);

            Stel.ZijnGelijk("FZZ", oplossing.BerekenDeel2());
        }

        public const string voorbeeld = @"46 onderdelen missen
Zoink: 9 Oink, 5 Dink
Floep: 2 Blap, 4 Dink
Blap: 4 Oink, 3 Dink";
    }
}
