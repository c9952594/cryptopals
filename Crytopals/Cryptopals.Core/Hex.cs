using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Cryptopals.Core
{
    public class Hex
    {
        public readonly string Text;
        public readonly Buffer Buffer;

        public Hex(string text) {
            Text = text.ToLower();
            Buffer = SoapHexBinary.Parse(text).Value;
        }
        
        public Hex(Buffer buffer) {
            Text = BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower();
            Buffer = buffer;
        }
    }
}
