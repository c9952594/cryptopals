using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Core
{
    public class Buffer
    {
        readonly byte[] _value;


        Buffer(byte[] value) {
            _value = value;
        }
        

        public static Buffer FromHex(string hex) => new Buffer(SoapHexBinary.Parse(hex).Value);
        public string ToHex() => BitConverter.ToString(_value).Replace("-", string.Empty).ToLower();


        public static Buffer FromBase64(string base64) => new Buffer(Convert.FromBase64String(base64));
        public string ToBase64() => Convert.ToBase64String(_value);


        public static Buffer FromText(string text) => new Buffer(Encoding.ASCII.GetBytes(text));
        public string ToText() => Encoding.ASCII.GetString(_value);


        public Tuple<int,string> Score(Func<string, int> scoreFunction) {
            var bestText = "";
            var bestScore = 0;

            for (var singleByte = 0; singleByte < 256; singleByte++)
            {
                var text = (this ^ singleByte).ToText();
                var score = scoreFunction(text);

                if (score <= bestScore) continue;

                bestText = text;
                bestScore = score;
            }

            return Tuple.Create(bestScore, bestText);
        }



        public static Buffer operator ^ (Buffer left, Buffer right) {
            var newBytes = new byte[left._value.Length];
            for (var index = 0; index < left._value.Length; index++) {
                newBytes[index] = (byte)(left._value[index] ^ right._value[index]);
            }
            return new Buffer(newBytes);
        }

        public static Buffer operator ^ (Buffer left, string right) {
            var bytes = FromText(right)._value;
            
            var newBytes = new byte[left._value.Length];
            for (var index = 0; index < left._value.Length; index++) {
                newBytes[index] = (byte)(left._value[index] ^ bytes[index % bytes.Length]);
            }

            return new Buffer(newBytes);
        }

        public static Buffer operator ^(Buffer left, int right) => left ^ (byte)right;

        public static Buffer operator ^ (Buffer left, byte right) {
            var newBytes = new byte[left._value.Length];
            for (var index = 0; index < left._value.Length; index++)
            {
                newBytes[index] = (byte)(left._value[index] ^ right);
            }
            return new Buffer(newBytes);
        }
       
    }
}
