using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using NUnit.Framework;

namespace Cryptopals.Test
{
    public class Class1
    {
        [TestCase("4d", ExpectedResult = "TQ==")]
        [TestCase("4d61", ExpectedResult = "TWE=")]
        [TestCase("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", ExpectedResult = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public string HexToBase64(string hex) => Convert.ToBase64String(SoapHexBinary.Parse(hex).Value);
        
    }
}
