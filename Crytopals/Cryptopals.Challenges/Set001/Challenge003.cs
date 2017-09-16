using System;
using System.Collections.Generic;
using System.Linq;
using Cryptopals.Core;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Challenges.Set001
{
    public class Challenge003
    {
        [Test]
        public void SingleByteXORCipher() {
            var messageBuffer = new Hex("1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736").Buffer;

            var message = Enumerable.Range(0, 256).Select(m => (byte)m).Select(xorByte => {
                var text = new StringFilter(messageBuffer ^ xorByte);
                var count = text.Text.Count(Char.IsLetter);
                return new {text, count};
            }).OrderByDescending(m => m.count).First().text.Text;
            
            message.ShouldBe("Cooking MC's like a pound of bacon");
        }
    }
}
