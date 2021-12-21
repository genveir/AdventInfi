using AdventInfi.Types;
using NUnit.Framework;

namespace AdventInfi.Tests
{
    class Fixture
    {
        [TestCase(example, 18)]
        public void Test1(string input, int output)
        {
            var sol = new Oplossing(input, 3);

            Assert.AreEqual((getal)output, sol.BerekenDeel1());
        }

        [TestCase(example, "FZZ")]
        public void Test2(string input, string output)
        {
            var sol = new Oplossing(input, 3);

            Assert.AreEqual((sliert)output, sol.BerekenDeel2());
        }

        public const string example = @"46 onderdelen missen
Zoink: 9 Oink, 5 Dink
Floep: 2 Blap, 4 Dink
Blap: 4 Oink, 3 Dink";
    }
}
