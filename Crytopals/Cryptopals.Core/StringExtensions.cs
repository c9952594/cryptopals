using System.Linq;

namespace Cryptopals.Core
{
    public static class StringExtensions {
        public static int HammingDistance(this Buffer left, Buffer right) {
            var buffer = left ^ right;
            return buffer.Sum(current => (current >> 0 & 1) +
                                         (current >> 1 & 1) +
                                         (current >> 2 & 1) +
                                         (current >> 3 & 1) +
                                         (current >> 4 & 1) +
                                         (current >> 5 & 1) +
                                         (current >> 6 & 1) +
                                         (current >> 7 & 1));
        }

        public static int HammingDistance(this string left, string right) 
            => HammingDistance(Buffer.FromText(left), Buffer.FromText(right));
    }
}
