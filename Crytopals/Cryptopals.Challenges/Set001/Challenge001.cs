using Cryptopals.Core;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Challenges.Set001
{
    public class Challenge001
    {
        [Test]
        public void ConvertHexToBase64() {
            var hex = new Hex("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");
            var base64 = new Base64(hex.Buffer);
            base64.Text.ShouldBe("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t");
        }
    }
}
