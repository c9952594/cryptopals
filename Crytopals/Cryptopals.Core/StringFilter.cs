using System.Text;

namespace Cryptopals.Core
{
    public class StringFilter
    {
        public readonly string Text;
        public readonly Buffer Buffer;

        public StringFilter(string text)
        {
            Text = text.ToLower();
            Buffer = Encoding.ASCII.GetBytes(text);
        }

        public StringFilter(Buffer buffer)
        {
            Text = Encoding.ASCII.GetString(buffer);
            Buffer = buffer;
        }
    }
}
