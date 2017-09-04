using System;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Test
{
    public class Class1
    {
        [TestCase("4d", ExpectedResult = "TQ==")]
        [TestCase("4d61", ExpectedResult = "TWE=")]
        [TestCase("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", ExpectedResult = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public string HexToBase64(string hex) => hex.ToByteArray().ToBase64();

        [TestCase("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", ExpectedResult = "49276D206B696C6C696E6720796F757220627261696E206C696B65206120706F69736F6E6F7573206D757368726F6F6D")]
        public string HexAndBackAgain(string hex) => hex.ToByteArray().ToHex();

        [Test]
        public void Challenge2() {
            var value1 = "1c0111001f010100061a024b53535009181c".ToByteArray();
            var value2 = "686974207468652062756c6c277320657965".ToByteArray();
            var qwe = value1.Xor(value2).ToHex().ToLower();
            qwe.ShouldBe("746865206b696420646f6e277420706c6179");
        }

    }

    public static class StringExtensions {
        public static byte[] ToByteArray(this string hex) => SoapHexBinary.Parse(hex).Value;
        public static string ToBase64(this byte[] bytes) => Convert.ToBase64String(bytes);
        public static string ToHex(this byte[] bytes) => BitConverter.ToString(bytes).Replace("-", string.Empty);
        public static byte[] Xor(this byte[] value1, byte[] value2) => value1.Zip(value2, (v1, v2) => (byte) (v1 ^ v2)).ToArray();
    }
}
