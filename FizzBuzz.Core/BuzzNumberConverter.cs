using System;

namespace FizzBuzz.Core
{
    internal sealed class BuzzNumberConverter : NumberConverterBase
    {
        protected override INumberConverter NextConverter => new JazzNumberConverter();
        protected override string Result => "Buzz";
        protected override Func<int, bool> CanConvert => (value) => value % 5 == 0;
    }
}