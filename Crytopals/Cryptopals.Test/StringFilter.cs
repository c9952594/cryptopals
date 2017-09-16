using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptopals.Core;
using NUnit.Framework;
using Shouldly;

namespace Cryptopals.Test
{
    class StringFilterTest
    {
        [TestCase("ABCD", 1)]
        [TestCase("He qwl qwelqwe ", 2)]
        public void ConvertTextOrByteArray(string text, int length)
        {
            var stringFilter = new StringFilter(text);
            stringFilter.Text.ShouldBe(text);
            stringFilter.Buffer.Length.ShouldBe(length);

            var fromStringFilter = new Base64(stringFilter.Buffer);
            fromStringFilter.Text.ShouldBe(stringFilter.Text);
            fromStringFilter.Buffer.ShouldBe(stringFilter.Buffer);
        }
    }
}
