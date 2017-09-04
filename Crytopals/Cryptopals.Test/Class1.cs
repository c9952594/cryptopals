using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using NUnit.Framework;

namespace Cryptopals.Test
{
    public class Class1
    {
        [TestCase("4d", ExpectedResult = "TQ==")]
        [TestCase("4d61", ExpectedResult = "TWE=")]
        [TestCase("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", ExpectedResult = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public string HexToBase64(string hex)
        {
            return Convert.ToBase64String(SoapHexBinary.Parse(hex).Value);

            //var hexByteArray = new byte[hex.Length / 2];
            //using (var hexStream = new MemoryStream(hexByteArray))
            //{
            //    for (var index = 0; index < hex.Length; index += 2) {
            //        var value = _hexCode[hex[index]];
            //        value <<= 4;
            //        value |= _hexCode[hex[index + 1]];
            //        hexStream.WriteByte(value);
            //    }
            //}

            //var builder = new StringBuilder();
            //using (var base64Stream = new MemoryStream(hexByteArray))
            //{
            //    while (base64Stream.Position != base64Stream.Length)
            //    {
            //        var buffer = new byte[3];
            //        var numberOfBytesRead = (byte)base64Stream.Read(buffer, 0, 3);
            //        builder.Append(_base64Code[(buffer[0] & 252) >> 2]);
            //        builder.Append(_base64Code[((buffer[0] & 3) << 4) + ((buffer[1] & 240) >> 4)]);
            //        builder.Append(numberOfBytesRead < 2 ? '=' : _base64Code[((buffer[1] & 15) << 2) + ((buffer[2] & 192) >> 6)]);
            //        builder.Append(numberOfBytesRead < 3 ? '=' : _base64Code[buffer[2] & 63]);
            //    }
            //}
            //return builder.ToString();
        }

        readonly Dictionary<char, byte> _hexCode = new Dictionary<char, byte>
        {
            ['0'] = 0,
            ['1'] = 1,
            ['2'] = 2,
            ['3'] = 3,
            ['4'] = 4,
            ['5'] = 5,
            ['6'] = 6,
            ['7'] = 7,
            ['8'] = 8,
            ['9'] = 9,
            ['a'] = 10,
            ['b'] = 11,
            ['c'] = 12,
            ['d'] = 13,
            ['e'] = 14,
            ['f'] = 15,
        };

        readonly char[] _base64Code = new char[]
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z',
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '+',
            '/'
        };



    }
}
