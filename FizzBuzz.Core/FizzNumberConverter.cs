using System;

namespace FizzBuzz.Core
{
    internal sealed class FizzNumberConverter : NumberConverterBase
    {
        protected override INumberConverter NextConverter => new BuzzNumberConverter();
        protected override string Result => "Fizz";
        protected override Func<int, bool> CanConvert => (value) => value % 3 == 0;
    }
}