using Cryptopals.Core;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Test
{
    class BufferTest {
        [Test]
        public void ShouldTakeParamsOfByte() {
            var buffer = new Buffer(1, 2, 3);
            ((byte[])buffer).ShouldBe(new byte[] {1, 2, 3});
        }
        


        [Test]
        public void BufferShouldImplicitlyConvertToAndFromByteArray() {
            byte[] fromArray = {1, 2, 3};

            Buffer buffer = fromArray;
            byte[] toArray = buffer;

            fromArray.ShouldBe(toArray);
        }

        [Test]
        public void ShouldBeAbleToXorByASingleByte() {
            Buffer buffer = new byte[] {0, 1, 2, 3};
            const byte singleByte = 1;

            var xorBuffer = buffer ^ singleByte;
            xorBuffer.ShouldBe(new Buffer(1, 0, 3, 2));

            var andBackAgain = xorBuffer ^ singleByte;
            andBackAgain.ShouldBe(buffer);
        }

        [Test]
        public void AreEqualIfBytesTheSame() {
            var buffer1 = new Buffer(0, 1, 2, 3);
            var buffer2 = new Buffer(0, 1, 2, 2);
            buffer1.ShouldBe(buffer2);
        }

        [Test]
        public void XOR() {
            var hex1 = new Hex("1c0111001f010100061a024b53535009181c");
            var hex2 = new Hex("686974207468652062756c6c277320657965");

            var buffer = hex1.Buffer ^ hex2.Buffer;
            var afterXOR = new Hex(buffer);

            afterXOR.Text.ShouldBe("746865206b696420646f6e277420706c6179");
        }
    }
    
}
