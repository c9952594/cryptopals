using Cryptopals.Core;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Test
{
    class HexTest
    {
        [TestCase("4d", 1)]
        [TestCase("4d61", 2)]
        [TestCase("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", 48)]
        public void ConvertTextOrByteArray(string text, int length) {
            var hex = new Hex(text);
            hex.Text.ShouldBe(text);
            hex.Buffer.Length.ShouldBe(length);

            var fromHex = new Hex(hex.Buffer);
            fromHex.Text.ShouldBe(hex.Text);
            fromHex.Buffer.ShouldBe(hex.Buffer);
        }
    }
}
