using Cryptopals.Core;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Challenges.Set001
{
    public class Challenge002
    {
        [Test]
        public void FixedXOR() {
            var hex1 = new Hex("1c0111001f010100061a024b53535009181c");
            var hex2 = new Hex("686974207468652062756c6c277320657965");

            var buffer = hex1.Buffer ^ hex2.Buffer;
            var afterXOR = new Hex(buffer);

            afterXOR.Text.ShouldBe("746865206b696420646f6e277420706c6179");
        }
    }
}
