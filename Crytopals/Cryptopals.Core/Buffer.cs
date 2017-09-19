using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace Cryptopals.Core
{

    public class Buffer : IEnumerable<byte>
    {
        readonly byte[] _value;



        public Buffer(byte[] value) {
            _value = value;
        }
        


        public static Buffer FromHex(string hex) 
            => new Buffer(SoapHexBinary.Parse(hex).Value);

        public string ToHex() 
            => BitConverter.ToString(_value).Replace("-", string.Empty).ToLower();
        


        public static Buffer FromBase64(string base64) 
            => new Buffer(Convert.FromBase64String(base64));

        public string ToBase64() 
            => Convert.ToBase64String(_value);
        


        public static Buffer FromText(string text) 
            => new Buffer(Encoding.ASCII.GetBytes(text));

        public string ToText() 
            => Encoding.ASCII.GetString(_value);

        

        public (int Score, string Text) Score(Func<string, int> scoreFunction)
        {
            (int Score, string Text) best = (0, "");
            
            for (var singleByte = 0; singleByte < 256; singleByte++)
            {
                var text = (this ^ (byte)singleByte).ToText();
                var score = scoreFunction(text);

                if (score <= best.Score) continue;

                best = (score, text);
            }

            return best;
        }



        public static implicit operator byte[](Buffer buffer) 
            => buffer._value;

        

        static Buffer Xor(byte[] left, byte[] right)
        {
            var newBytes = new byte[left.Length];

            for (var index = 0; index < left.Length; index++)
                newBytes[index] = (byte) (left[index] ^ right[index % right.Length]);

            return new Buffer(newBytes);
        }

        public static Buffer operator ^ (Buffer left, Buffer right) 
            => Xor(left, right);

        public static Buffer operator ^ (Buffer left, string right) 
            => Xor(left, FromText(right)._value);
        
        public static Buffer operator ^ (Buffer left, byte right) 
            => Xor(left, new[] { right });




        public IEnumerator<byte> GetEnumerator() 
            => ((IEnumerable<byte>) _value).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();
    }
}
