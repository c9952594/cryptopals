using System;
using System.Text;
using Cryptopals.Core;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Test {
    class Base64Test {
        [TestCase("TQ==", 1)]
        [TestCase("TWE=", 2)]
        [TestCase("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t", 48)]
        public void ConvertTextOrByteArray(string text, int length) {
            var base64 = new Base64(text);
            base64.Text.ShouldBe(text);
            base64.Buffer.Length.ShouldBe(length);
            
            var fromBase64 = new Base64(base64.Buffer);
            fromBase64.Text.ShouldBe(base64.Text);
            fromBase64.Buffer.ShouldBe(base64.Buffer);
        }
    }
}