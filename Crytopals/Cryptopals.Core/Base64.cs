using System;

namespace Cryptopals.Core {
    public class Base64
    {
        public readonly string Text;
        public readonly Buffer Buffer;

        public Base64(string text) {
            Text = text;
            Buffer = Convert.FromBase64String(text);
        }
        
        public Base64(Buffer buffer)
        {
            Text = Convert.ToBase64String(buffer);
            Buffer = buffer;
        }

        
    }
}