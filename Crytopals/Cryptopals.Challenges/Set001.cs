﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Buffer = Cryptopals.Core.Buffer;

namespace Cryptopals.Challenges
{
    class Set001 {
        [Test]
        public void Challenge001() {
            var fromHex =
                Buffer.FromHex(
                    "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");
            var toBase64 = fromHex.ToBase64();
            toBase64.ShouldBe("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t");
        }

        [Test]
        public void Challenge002() {
            var buffer1 = Buffer.FromHex("1c0111001f010100061a024b53535009181c");
            var buffer2 = Buffer.FromHex("686974207468652062756c6c277320657965");

            var xorBuffer = buffer1 ^ buffer2;
            var hex = xorBuffer.ToHex();

            hex.ShouldBe("746865206b696420646f6e277420706c6179");
        }

        [Test]
        public void Challenge003() {
            var buffer = Buffer.FromHex("1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736");
            var scored = buffer.Score(text => text.Count(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
            scored.Item2.ShouldBe("Cooking MC's like a pound of bacon");
        }

        [Test]
        public void Challenge004() {
            var lines = File.ReadAllLines(@"C:\Users\c9952\OneDrive\Documents\GitHub\cryptopals\Crytopals\Cryptopals.Challenges\Set001Challenge004.txt");

            var bestMessage = "";
            var bestScore = 0;

            foreach (var line in lines) {
                var buffer = Buffer.FromHex(line);
                var scored = buffer.Score(text => text.Count(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
                if (scored.Item1 <= bestScore) continue;
                bestMessage = scored.Item2;
                bestScore = scored.Item1;
            }
            
            bestMessage.Trim().ShouldBe("Now that the party is jumping");
        }

        [Test]
        public void Challenge005() {
            var toEncrypt = "Burning 'em, if you ain't quick and nimble\n" +
                            "I go crazy when I hear a cymbal";
            var buffer = Buffer.FromText(toEncrypt) ^ "ICE";
            var asHex = buffer.ToHex();

            asHex.ShouldBe("0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272" + 
                           "a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f");
        }
    }
}
