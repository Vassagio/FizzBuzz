using System;

namespace FizzBuzz.Core
{
    internal sealed class JazzNumberConverter : NumberConverterBase
    {
        protected override INumberConverter NextConverter => new FinalNumberConverter();
        protected override string Result => "Jazz";
        protected override Func<int, bool> CanConvert => value => value % 7 == 0;
    }
}