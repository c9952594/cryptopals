using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Core
{
    public class Buffer
    {
        readonly byte[] _value;
        public readonly int Length;

        public Buffer(params byte[] value) {
            _value = value;
            Length = value.Length;
        }

        public static implicit operator Buffer(byte[] value) 
            => new Buffer(value);
        public static implicit operator byte[] (Buffer value) 
            => value._value;

        public static Buffer operator ^ (Buffer left, Buffer right) 
            => left._value.Zip(right._value, (v1, v2) => (byte)(v1 ^ v2)).ToArray();

        public static Buffer operator ^ (Buffer left, byte right)
            => left._value.Select(v => (byte) (v ^ right)).ToArray();
    }
}
